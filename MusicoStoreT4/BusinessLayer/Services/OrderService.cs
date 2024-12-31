using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using BusinessLayer.Cache;
using BusinessLayer.Cache.Interfaces;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Order;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
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

        public async Task<IEnumerable<OrderDetailDto>> GetAllOrdersAsync()
        {
            var orders = await _uow.OrdersRep.GetAllAsync();

            return orders.Select(o => o.Adapt<OrderDetailDto>()).ToList();
        }

        public async Task<OrderDetailDto?> GetOrderByIdAsync(int id)
        {
            var order = await _uow.OrdersRep.GetByIdAsync(id);

            if (order == null)
                return null;

            return order?.Adapt<OrderDetailDto>();
        }

        public async Task<bool> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            // Validate input
            if (createOrderDto == null || createOrderDto.Items == null || !createOrderDto.Items.Any())
                throw new ArgumentException("Order must contain at least one item.", nameof(createOrderDto));

            // Validate customer existence
            if (!await _uow.UsersRep.AnyAsync(u => u.Id == createOrderDto.CustomerId))
                throw new ArgumentException($"No such customer with id {createOrderDto.CustomerId}", nameof(createOrderDto.CustomerId));

            // Validate product existence and create order items
            var orderItems = new List<OrderItem>();
            var productIds = createOrderDto.Items.Select(i => i.ProductId).ToHashSet();
            var products = await _uow.ProductsRep.GetByIdsAsync(productIds); // bulk fetch

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

            var userId = createOrderDto.CustomerId;

            var order = new Order
            {
                UserId = userId,
                Date = DateTime.UtcNow,
                OrderItems = orderItems,
                OrderStatus = PaymentStatus.Pending
            };

            await _uow.OrdersRep.AddAsync(order);

            try
            {
                await _uow.SaveAsync();
                _cacheWrapper.Invalidate($"{CUSTOMER_ORDER_LIST_CACHE_KEY}_{userId}");
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
                throw new ArgumentNullException(nameof(updateOrderDto), "UpdateOrderDto cannot be null.");

            // Fetch the order
            var order = await _uow.OrdersRep.GetByIdAsync(orderId);
            var userId = order?.UserId;
            if (order == null)
                throw new ArgumentException($"Order with ID {orderId} not found.");

            // Update the order date if provided
            if (updateOrderDto.OrderDate.HasValue)
                order.Date = updateOrderDto.OrderDate.Value;

            // Update the payment status if provided
            if (!string.IsNullOrWhiteSpace(updateOrderDto.PaymentStatus))
            {
                if (Enum.TryParse<PaymentStatus>(updateOrderDto.PaymentStatus, true, out var parsedStatus))
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
            order.OrderItems = updateOrderDto.OrderItems
                .Join(products, itemDto => itemDto.ProductId, product => product.Id,
                    (itemDto, product) => new OrderItem
                    {
                        ProductId = product.Id,
                        Quantity = itemDto.Quantity,
                        Price = product.Price
                    })
                .ToList();

            // Save changes within a transaction
            //using var transaction = await _uow.BeginTransactionAsync();
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
                //await transaction.RollbackAsync();
                throw new ArgumentException($"Failed to update order with ID {orderId} due to concurrency issues.", ex);
            }
        }


        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _uow.OrdersRep.GetByIdAsync(orderId);

            if (order == null)
                return false;

            await _uow.OrdersRep.DeleteAsync(order.Id);
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
            //return (await _uow.OrdersRep.GetOrdersWithProductsAsync(userId)).Select(o => o.Adapt<OrderDetailDTO>()).ToList();
        }
    }
}
