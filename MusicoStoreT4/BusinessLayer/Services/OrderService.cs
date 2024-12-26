using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
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

        public OrderService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _uow = unitOfWork;
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

        public async Task<int> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            if (
                createOrderDto == null
                || createOrderDto.Items == null
                || !createOrderDto.Items.Any()
            )
                throw new ArgumentException("Order must contain at least one item.");

            if (!(await _uow.UsersRep.AnyAsync(u => u.Id == createOrderDto.CustomerId)))
                throw new ArgumentException(
                    $"No such customer with id {createOrderDto.CustomerId}"
                );

            foreach (var orderItemDto in createOrderDto.Items)
            {
                if (!(await _uow.ProductsRep.AnyAsync(p => p.Id == orderItemDto.ProductId)))
                    throw new ArgumentException(
                        $"No such product with id {orderItemDto.ProductId}. Order was not created."
                    );
            }

            var order = new Order
            {
                UserId = createOrderDto.CustomerId,
                Date = DateTime.UtcNow,
                OrderItems =
                    (ICollection<OrderItem>)
                        createOrderDto
                            .Items.Select(async itemDto => new OrderItem
                            {
                                ProductId = itemDto.ProductId,
                                Quantity = itemDto.Quantity,
                                Price = (
                                    await _uow.ProductsRep.GetByIdAsync(itemDto.ProductId)
                                ).Price,
                            })
                            .ToList(),
                OrderStatus = OrderStatus.Pending
            };

            await _uow.OrdersRep.AddAsync(order);

            return 1;
        }

        public async Task<bool> UpdateOrderAsync(int orderId, UpdateOrderDto updateOrderDto)
        {
            var order = await _uow.OrdersRep.GetByIdAsync(orderId);

            if (order == null)
                throw new ArgumentException($"Order with ID {orderId} not found.");

            if (updateOrderDto.OrderDate.HasValue)
                order.Date = updateOrderDto.OrderDate.Value;

            order.OrderItems.Clear();

            foreach (var itemDto in updateOrderDto.OrderItems)
            {
                var product = await _uow.ProductsRep.GetByIdAsync(itemDto.ProductId);

                if (product != null)
                {
                    order.OrderItems.Add(
                        new OrderItem
                        {
                            ProductId = itemDto.ProductId,
                            Quantity = itemDto.Quantity,
                            Price = product.Price
                        }
                    );
                }
            }

            try
            {
                await _uow.SaveAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ArgumentException(
                    $"Failed to update order with ID {orderId} due to concurrency issues."
                );
            }
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await _uow.OrdersRep.GetByIdAsync(orderId);

            if (order == null)
                return false;

            await _uow.OrdersRep.DeleteAsync(order.Id);
            return true;
        }

        public async Task<IEnumerable<OrderDetailDto?>> GetOrdersByUserAsync(int userId)
        {
            var orders = await _uow.OrdersRep.GetOrdersByAsync(userId);

            return orders.Select(o => o.Adapt<OrderDetailDto>()).ToList();
            //return (await _uow.OrdersRep.GetOrdersWithProductsAsync(userId)).Select(o => o.Adapt<OrderDetailDTO>()).ToList();
        }
    }
}
