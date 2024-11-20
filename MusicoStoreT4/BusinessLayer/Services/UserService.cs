using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models.Enums;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Mapper;

namespace BusinessLayer.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly MyDBContext _dbContext;

        public UserService(MyDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<CustomerSegmentsDto> GetCustomerSegmentsAsync()
        {
            var currentDate = DateTime.UtcNow;
            var customers = await _dbContext.Users
                .Where(u => u.Role == Role.Customer)
                .Select(u => u as Customer)
                .ToListAsync();

            return customers.MapToCustomerSegmentsDto(currentDate);
        }

        public async Task<OrderItemDto?> GetMostFrequentBoughtItemAsync(int userId)
        {
            var user = await _dbContext.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.OrderItems)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null || user.Orders == null)
            {
                return null;
            }

            var mostFrequentItem = user.Orders
                .SelectMany(o => o.OrderItems!)
                .GroupBy(oi => oi.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    Quantity = g.Sum(oi => oi.Quantity)
                })
                .OrderByDescending(g => g.Quantity)
                .FirstOrDefault();

            if (mostFrequentItem == null)
            {
                return null;
            }

            return new OrderItem
            {
                ProductId = mostFrequentItem.ProductId,
                Quantity = mostFrequentItem.Quantity
            }.MapToOrderItemDto();
        }

        public async Task<List<UserSummaryDto>> GetUserSummariesAsync()
        {
            var users = await _dbContext.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.OrderItems!)
                .ToListAsync();

            return users.Select(u => u.MapToUserSummaryDto()).ToList();
        }

        public async Task<bool> ValidateUserAsync(int userId)
        {
            return await _dbContext.Users
                .AnyAsync(u => u.Id == userId);
        }
    }
}
