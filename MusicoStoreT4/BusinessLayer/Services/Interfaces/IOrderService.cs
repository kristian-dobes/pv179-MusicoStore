using BusinessLayer.DTOs.Order;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IOrderService : IBaseService
    {
        Task<IEnumerable<OrderDetailDTO>> GetAllOrdersAsync();
        Task<OrderDetailDTO?> GetOrderByIdAsync(int id);
        Task<int> CreateOrderAsync(CreateOrderDto createOrderDto);
        Task<bool> UpdateOrderAsync(int orderId, UpdateOrderDto updateOrderDto);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<IEnumerable<OrderDetailDTO?>> GetOrdersByUserAsync(int userId);
    }
}
