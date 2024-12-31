﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Order;
using DataAccessLayer.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface IOrderService : IBaseService
    {
        Task<IEnumerable<OrderSummaryDTO>> GetAllOrdersAsync();
        Task<OrderDetailDto?> GetOrderByIdAsync(int id);
        Task<bool> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<bool> UpdateOrderAsync(int orderId, UpdateOrderDto updateOrderDto);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<IEnumerable<OrderDetailDto?>> GetOrdersByUserAsync(int userId);
    }
}
