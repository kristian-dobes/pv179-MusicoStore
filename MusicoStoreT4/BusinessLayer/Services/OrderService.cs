using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Order;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly MyDBContext _dBContext;

        public OrderService(MyDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<ICollection<OrderDetailDTO>> GetOrders()
        {
            IQueryable<Order> orderQuery = _dBContext.Orders;

            // Fetch data into a list
            var orders = await orderQuery.ToListAsync();

            // Map to DTOs
            var orderDTOs = orders.Adapt<ICollection<OrderDetailDTO>>();

            return orderDTOs;
        }

        //public async Task<OrderSummaryDTO?> GetOrderByIdAsync(int orderId)
        //{
        //    var order = await _dBContext.Orders
        //        .SingleOrDefaultAsync(m => m.Id == orderId);

        //    return order?.Adapt<OrderSummaryDTO>();
        //}

        //public async Task<OrderDTO> CreateOrderAsync(OrderNameDTO order)
        //{
        //    var orderEntity = order.Adapt<Order>();

        //    _dBContext.Orders.Add(orderEntity);
        //    await SaveAsync(true);

        //    return orderEntity.Adapt<OrderDTO>();
        //}

        //public async Task<OrderDTO?> UpdateOrderAsync(int orderId, OrderNameDTO orderDto)
        //{
        //    var order = await _dBContext.Orders.FindAsync(orderId);

        //    if (order == null)
        //    {
        //        return null;
        //    }

        //    order = orderDto.Adapt(order);
        //    _dBContext.Orders.Update(order);
        //    await SaveAsync(true);
        //    return order.Adapt<OrderDTO>();
        //}

        //public async Task<bool> ValidateOrderAsync(int orderId)
        //{
        //    return await _dBContext.Orders
        //        .AnyAsync(m => m.Id == orderId);
        //}

        //public async Task DeleteOrderAsync(int orderId)
        //{
        //    var order = await _dBContext.Orders
        //        .Include(c => c.Products)
        //        .FirstOrDefaultAsync(c => c.Id == orderId);

        //    if (order == null)
        //        throw new Exception("Order not found.");

        //    if (order.Products != null && order.Products.Count > 0)
        //        throw new Exception("Order has products, cannot delete.");

        //    _dBContext.Orders.Remove(order);
        //    await SaveAsync(true);
        //}
    }
}
