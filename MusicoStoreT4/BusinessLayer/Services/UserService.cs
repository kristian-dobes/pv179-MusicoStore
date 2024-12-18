using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Product;
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
                .Select(u => u as Customer)
                .ToListAsync();

            return customers.MapToCustomerSegmentsDto(currentDate);
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

            return users.Select(u => u.MapToUserSummaryDto()).ToList();
        }

        public async Task<bool> ValidateUserAsync(int userId)
        {
            return await _dbContext.Users.AnyAsync(u => u.Id == userId);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _dbContext.Users.ToListAsync();
            return users.Select(u =>
                u.Role == Role.Admin
                    ? new UserDto
                    {
                        UserId = u.Id,
                        UserName = u.Username,
                        CreatedDate = u.Created,
                        Role = u.Role.ToString()
                    }
                    : new CustomerDto
                    {
                        UserId = u.Id,
                        UserName = u.Username,
                        CreatedDate = u.Created,
                        Role = u.Role.ToString(),
                        PhoneNumber = (u as Customer)?.PhoneNumber,
                        Address = (u as Customer)?.Address,
                        City = (u as Customer)?.City,
                        State = (u as Customer)?.State,
                        PostalCode = (u as Customer)?.PostalCode
                    }
            );
        }

        public async Task<UserDetailDto> GetUserByIdAsync(int userId)
        {
            var user = await _dbContext
                .Users.Include(u => (u as Customer).Orders)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return null;

            return new UserDetailDto
            {
                UserId = user.Id,
                UserName = user.Username,
                Role = user.Role.ToString(),
                CustomerDetails =
                    user.Role == Role.Customer
                        ? new CustomerDetailDto
                        {
                            PhoneNumber = (user as Customer)?.PhoneNumber,
                            Address = (user as Customer)?.Address,
                            City = (user as Customer)?.City,
                            State = (user as Customer)?.State,
                            PostalCode = (user as Customer)?.PostalCode,
                            Orders = (user as Customer)
                                ?.Orders.Select(o => new OrderDto
                                {
                                    OrderId = o.Id,
                                    Date = o.Date,
                                    Created = o.Created,
                                    OrderItems = o
                                        .OrderItems.Select(oi => new OrderItemDto
                                        {
                                            Id = oi.Id,
                                            ProductId = oi.ProductId,
                                            Quantity = oi.Quantity,
                                            Price = oi.Price
                                        })
                                        .ToList()
                                })
                                .ToList()
                        }
                        : null
            };
        }

        public async Task CreateAdminAsync(AdminDto adminDto)
        {
            var admin = new User
            {
                Username = adminDto.Name,
                Email = adminDto.Email,
                Role = Role.Admin
            };
            await _dbContext.Users.AddAsync(admin);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateCustomerAsync(CustomerDto customerDto)
        {
            var customer = new Customer
            {
                Username = customerDto.Name,
                Email = customerDto.Email,
                Role = Role.Customer,
                PhoneNumber = customerDto.PhoneNumber,
                Address = customerDto.Address,
                City = customerDto.City,
                State = customerDto.State,
                PostalCode = customerDto.PostalCode
            };
            await _dbContext.Users.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAdminAsync(int userId, AdminDto adminDto)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            if (user == null || user.Role != Role.Admin)
                throw new KeyNotFoundException("Admin not found");

            user.Username = adminDto.Name;
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

            customer.Username = customerDto.Name;
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

        public async Task<MostFrequentItemDto> GetMostFrequentItemAsync(int userId)
        {
            var customer = await _dbContext
                .Users.OfType<Customer>()
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderItems)
                .FirstOrDefaultAsync(c => c.Id == userId);

            if (customer == null)
                return null;

            var mostFrequentItem = customer
                .Orders.SelectMany(o => o.OrderItems)
                .GroupBy(oi => oi.ProductId)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            if (mostFrequentItem == null)
                return null;

            return new MostFrequentItemDto
            {
                ProductId = mostFrequentItem.Key,
                Quantity = mostFrequentItem.Sum(oi => oi.Quantity)
            };
        }
    }
}
