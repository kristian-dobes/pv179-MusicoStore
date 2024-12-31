using BusinessLayer.Cache;
using BusinessLayer.Cache.Interfaces;
using BusinessLayer.DTOs.Order;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Infrastructure.UnitOfWork;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMemoryCacheWrapper _cacheWrapper;
        private const string CUSTOMER_ORDER_LIST_CACHE_KEY = "Customer_Orders_List";
        private static readonly CacheOptions CacheOptions =
            new(
                AbsoluteExpiration: TimeSpan.FromHours(1),
                SlidingExpiration: TimeSpan.FromMinutes(10)
            );

        public OrderService(IUnitOfWork unitOfWork, IMemoryCacheWrapper memoryCacheWrapper)
            : base(unitOfWork)
        {
            _uow = unitOfWork;
            _cacheWrapper = memoryCacheWrapper;
        }

        public async Task<IEnumerable<OrderSummaryDTO>> GetAllOrdersAsync()
        {
            var orders = await _uow.OrdersRep.GetAllOrdersWithDetailsQuery().ToListAsync();

            // in memory, sum isnt handled well by db
            return orders.Select(o => new OrderSummaryDTO
            {
                OrderId = o.Id,
                Created = o.Created,
                OrderItemsCount = o.OrderItems.Count,
                CustomerId = o.User.Id,
                Email = o.User.Email,
                TotalOrderPrice = o.OrderItems.Sum(oi => oi.Price * oi.Quantity),
                PaymentStatus = MapPaymentStatus(o.OrderStatus)
            });
        }

        private static string MapPaymentStatus(PaymentStatus status)
        {
            return status switch
            {
                PaymentStatus.Pending => "Pending ",
                PaymentStatus.Paid => "Paid",
                PaymentStatus.Failed => "Failed",
                PaymentStatus.Refunded => "Refunded",
                _ => "Unknown Status"
            };
        }

        public async Task<OrderDetailDto?> GetOrderByIdAsync(int id)
        {
            var order = await _uow.OrdersRep.GetByIdAsync(id);
            // in memory, single order only, sum isnt handled well by db
            if (order == null)
                return null;

            return order?.Adapt<OrderDetailDto>();
        }

        public async Task<bool> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            if (createOrderDto == null || createOrderDto.Items == null || !createOrderDto.Items.Any())
                throw new ArgumentException("Order must contain at least one item.", nameof(createOrderDto));

            if (!await _uow.UsersRep.AnyAsync(u => u.Id == createOrderDto.CustomerId))
                throw new ArgumentException($"No such customer with id {createOrderDto.CustomerId}", nameof(createOrderDto.CustomerId));

            // validate products
            var orderItems = new List<OrderItem>();
            var productIds = createOrderDto.Items.Select(i => i.ProductId).ToHashSet();
            var products = await _uow.ProductsRep.GetByIdsAsync(productIds); // Bulk fetch

            foreach (var itemDto in createOrderDto.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == itemDto.ProductId);
                if (product == null)
                    throw new ArgumentException($"No such product with id {itemDto.ProductId}", nameof(itemDto.ProductId));

                orderItems.Add(new OrderItem
                {
                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    Price = product.Price
                });
            }

            // Fetch gift card
            GiftCard? appliedGiftCard = null;
            CouponCode? appliedCouponCode = null;
            if (!string.IsNullOrEmpty(createOrderDto.AppliedGiftCardCode))
            {
                appliedCouponCode = await _uow.CouponCodesRep.GetCouponCodeByCodeAsync(createOrderDto.AppliedGiftCardCode);
                if (appliedCouponCode == null)
                    throw new ArgumentException($"Invalid coupon code: {createOrderDto.AppliedGiftCardCode}", nameof(createOrderDto.AppliedGiftCardCode));

                appliedGiftCard = await _uow.GiftCardsRep.GetGiftCardByCodeAsync(createOrderDto.AppliedGiftCardCode);
                if (appliedGiftCard == null)
                    throw new ArgumentException($"Invalid gift card code: {createOrderDto.AppliedGiftCardCode}", nameof(createOrderDto.AppliedGiftCardCode));
            }

            var order = new Order
            {
                UserId = createOrderDto.CustomerId,
                Date = DateTime.UtcNow,
                OrderItems = orderItems,
                OrderStatus = PaymentStatus.Pending,
                GiftCardId = appliedGiftCard?.Id,
                UsedCouponCode = createOrderDto.AppliedGiftCardCode
            };

            
            // discount
            if (appliedGiftCard != null)
            {
                decimal totalOrderPrice = orderItems.Sum(item => item.Price * item.Quantity);
                decimal remainingDiscount = createOrderDto.DiscountAmount;

                foreach (var item in orderItems)
                {
                    var itemTotalPrice = item.Price * item.Quantity;
                    var itemProportion = itemTotalPrice / totalOrderPrice;

                    // per item
                    var itemDiscount = Math.Min(remainingDiscount, itemProportion * createOrderDto.DiscountAmount);

                    item.Price -= itemDiscount / item.Quantity;

                    if (item.Price < 0) item.Price = 0;

                    remainingDiscount -= itemDiscount;
                }
            }

            await _uow.OrdersRep.AddAsync(order);

            if (appliedCouponCode != null)
            {
                appliedCouponCode.IsUsed = true;
                appliedCouponCode.OrderId = order.Id; // assign order's ID to coupon code
                _uow.CouponCodesRep.UpdateAsync(appliedCouponCode); // Track the change
            }

            try
            {
                await _uow.SaveAsync();
                _cacheWrapper.Invalidate($"{CUSTOMER_ORDER_LIST_CACHE_KEY}_{createOrderDto.CustomerId}");
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateOrderAsync(int orderId, UpdateOrderDto updateOrderDto)
        {
            if (updateOrderDto == null)
            {
                throw new ArgumentNullException(
                    nameof(updateOrderDto),
                    "UpdateOrderDto cannot be null."
                );
            }

            // Fetch the order
            var order = await _uow.OrdersRep.GetByIdAsync(orderId);
            var userId = order?.UserId;
            if (order == null)
            {
                throw new ArgumentException($"Order with ID {orderId} not found.");
            }

            // Update the order date if provided
            if (updateOrderDto.OrderDate.HasValue)
            {
                order.Date = updateOrderDto.OrderDate.Value;
            }

            // Update the payment status if provided
            if (!string.IsNullOrWhiteSpace(updateOrderDto.PaymentStatus))
            {
                if (
                    Enum.TryParse<PaymentStatus>(
                        updateOrderDto.PaymentStatus,
                        true,
                        out var parsedStatus
                    )
                )
                {
                    order.OrderStatus = parsedStatus;
                }
                else
                {
                    // Set to 'Failed' if the payment status string is invalid
                    order.OrderStatus = PaymentStatus.Failed;
                }
            }

            // Remove all existing order items
            order.OrderItems.Clear();

            // bulk fetch
            var productIds = updateOrderDto.OrderItems.Select(item => item.ProductId).Distinct();
            var products = await _uow.ProductsRep.GetByIdsAsync(productIds);

            if (products.Count() != productIds.Count())
                throw new ArgumentException("One or more products in the order are invalid.");

            // Add new order items
            order.OrderItems = updateOrderDto
                .OrderItems.Join(
                    products,
                    itemDto => itemDto.ProductId,
                    product => product.Id,
                    (itemDto, product) =>
                        new OrderItem
                        {
                            ProductId = product.Id,
                            Quantity = itemDto.Quantity,
                            Price = product.Price
                        }
                )
                .ToList();

            try
            {
                await _uow.SaveAsync();
                // await transaction.CommitAsync();
                if (userId.HasValue)
                {
                    _cacheWrapper.Invalidate($"{CUSTOMER_ORDER_LIST_CACHE_KEY}_{userId}");
                }
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _uow.OrdersRep.GetByIdAsync(orderId);

            if (order == null)
            {
                return false;
            }

            await _uow.OrdersRep.DeleteAsync(orderId);
            _cacheWrapper.Invalidate($"{CUSTOMER_ORDER_LIST_CACHE_KEY}_{order.UserId}");
            return true;
        }

        public async Task<IEnumerable<OrderDetailDto?>> GetOrdersByUserAsync(int userId)
        {
            var orders = await _cacheWrapper.GetOrCreateAsync(
                $"{CUSTOMER_ORDER_LIST_CACHE_KEY}_{userId}",
                async () => await _uow.OrdersRep.GetOrdersByAsync(userId),
                CacheOptions
            );

            return orders.Select(o => o.Adapt<OrderDetailDto>()).ToList();
        }
    }
}
