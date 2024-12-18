using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Product;
using BusinessLayer.DTOs.User;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly MyDBContext _dbContext;

        public UserService(MyDBContext dBContext)
            : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<CustomerSegmentsDto> GetCustomerSegmentsAsync()
        {
            var currentDate = DateTime.UtcNow;

            var customers = await _dbContext
                .Users.Where(u => u.Role == Role.Customer)
                .Include(c => c.Orders)
                .Select(u => u as Customer)
                .ToListAsync();

            var highValueCustomers = new List<CustomerDto>();
            var infrequentCustomers = new List<CustomerDto>();

            foreach (var customer in customers)
            {
                if (customer == null || customer.Orders == null)
                {
                    continue;
                }

                var totalExpenditure = await CalculateTotalExpenditureAsync(customer.Id); // Use the async method for total expenditure

                if (totalExpenditure > 1000)
                {
                    highValueCustomers.Add(customer.MapToCustomerDto());
                }

                if (customer.Orders.All(o => (currentDate - o.Date).Days > 180))
                {
                    infrequentCustomers.Add(customer.MapToCustomerDto());
                }
            }

            return new CustomerSegmentsDto
            {
                HighValueCustomers = highValueCustomers,
                InfrequentCustomers = infrequentCustomers
            };
        }

        public async Task<OrderItemDto?> GetMostFrequentBoughtItemAsync(int userId)
        {
            var user = await _dbContext
                .Users.Include(u => u.Orders)
                .ThenInclude(o => o.OrderItems)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null || user.Orders == null)
            {
                return null;
            }

            var mostFrequentItem = user
                .Orders.SelectMany(o => o.OrderItems)
                .GroupBy(oi => oi.ProductId)
                .Select(g => new { ProductId = g.Key, Quantity = g.Sum(oi => oi.Quantity) })
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
            var users = await _dbContext
                .Users.Include(u => u.Orders)
                .ThenInclude(o => o.OrderItems)
                .ToListAsync();

            var userSummaries = new List<UserSummaryDto>();
            foreach (var user in users)
            {
                var totalExpenditure = await CalculateTotalExpenditureAsync(user.Id);

                userSummaries.Add(user.MapToUserSummaryDto(totalExpenditure));
            }

            return userSummaries;
        }

        public async Task<bool> ValidateUserAsync(int userId)
        {
            return await _dbContext.Users.AnyAsync(u => u.Id == userId);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Select(u => u.MapToUserDto());
        }

        public async Task<UserDetailDto?> GetUserByIdAsync(int userId)
        {
            var user = await _dbContext
                .Users.Include(u => (u as Customer).Orders)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return null;

            return user.MapToUserDetailDto();
        }

        public async Task CreateAdminAsync(AdminDto adminDto)
        {
            var admin = adminDto.MapToAdmin();
            await _dbContext.Users.AddAsync(admin);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateCustomerAsync(CustomerDto customerDto)
        {
            var customer = customerDto.MapToCustomer();
            await _dbContext.Users.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAdminAsync(int userId, AdminDto adminDto)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            if (user == null || user.Role != Role.Admin)
                throw new KeyNotFoundException("Admin not found");

            user.Username = adminDto.Username;
            user.Email = adminDto.Email;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(int userId, CustomerDto customerDto)
        {
            var customer = await _dbContext
                .Users.OfType<Customer>()
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (customer == null || customer.Role != Role.Customer)
                throw new KeyNotFoundException("Customer not found");

            customer.Username = customerDto.Username;
            customer.Email = customerDto.Email;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.Address = customerDto.Address;
            customer.City = customerDto.City;
            customer.State = customerDto.State;
            customer.PostalCode = customerDto.PostalCode;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDetailDto>> GetAllUserDetailsAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Select(u => u.MapToUserDetailDto());
        }

        public async Task<decimal> CalculateTotalExpenditureAsync(int userId)
        {
            return await _dbContext
                .Orders.Where(o => o.UserId == userId)
                .SelectMany(o => o.OrderItems)
                .SumAsync(oi => oi.Price * oi.Quantity);
        }
    }
}
