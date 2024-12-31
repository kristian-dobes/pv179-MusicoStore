using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Cache;
using BusinessLayer.Cache.Interfaces;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;
using BusinessLayer.DTOs.User;
using BusinessLayer.DTOs.User.Admin;
using BusinessLayer.DTOs.User.Customer;
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
    public class UserService : BaseService, IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMemoryCacheWrapper _cacheWrapper;
        private const string USER_LIST_CACHE_KEY = "Users_List";
        private static readonly CacheOptions CacheOptions =
            new(
                AbsoluteExpiration: TimeSpan.FromHours(6),
                SlidingExpiration: TimeSpan.FromMinutes(20)
            );

        public UserService(IUnitOfWork unitOfWork, IMemoryCacheWrapper memoryCacheWrapper)
            : base(unitOfWork)
        {
            _uow = unitOfWork;
            _cacheWrapper = memoryCacheWrapper;
        }

        public async Task<CustomerSegmentsDto> GetCustomerSegmentsAsync()
        {
            var currentDate = DateTime.UtcNow;

            var customers = await _uow.UsersRep.WhereAsync(u => u.Role == Role.Customer);

            var customersWithStats = new List<CustomerSegmentStatsDto>();

            foreach (var customer in customers)
            {
                var orders = await _uow.OrdersRep.WhereAsync(o => o.UserId == customer.Id);
                var orderItems = orders.SelectMany(o => o.OrderItems).ToList();

                var totalExpenditure = orderItems.Sum(oi => oi.Price * oi.Quantity);
                var isInfrequent =
                    orders.Any() && orders.All(o => (currentDate - o.Date).Days > 180);

                customersWithStats.Add(
                    new CustomerSegmentStatsDto
                    {
                        CustomerDTO = (customer as Customer)?.MapToCustomerDto(),
                        TotalExpenditure = totalExpenditure,
                        IsInfrequent = isInfrequent
                    }
                );
            }

            var highValueCustomers = customersWithStats
                .Where(c => c.TotalExpenditure > 1000)
                .Select(c => c.CustomerDTO)
                .ToList();

            var infrequentCustomers = customersWithStats
                .Where(c => c.IsInfrequent)
                .Select(c => c.CustomerDTO)
                .ToList();

            return new CustomerSegmentsDto
            {
                HighValueCustomers = highValueCustomers,
                InfrequentCustomers = infrequentCustomers
            };
        }

        public async Task<OrderItemDto?> GetMostFrequentBoughtItemAsync(int userId)
        {
            var user = await _uow.UsersRep.GetUserWithOrdersAsync(userId);

            if (user == null || !user.Orders.Any())
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

            return new OrderItemDto
            {
                ProductId = mostFrequentItem.ProductId.Value,
                Quantity = mostFrequentItem.Quantity
            };
        }

        public async Task<bool> ValidateUserAsync(int userId)
        {
            return await _uow.UsersRep.AnyAsync(u => u.Id == userId);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _cacheWrapper.GetOrCreateAsync(
                USER_LIST_CACHE_KEY,
                async () => await _uow.UsersRep.GetAllAsync(),
                CacheOptions
            );
            return users.Select(u => u.MapToUserDto());
        }

        public async Task<UserSummaryDTO?> GetUserByIdAsync(int userId)
        {
            var user = await _uow.UsersRep.GetByIdAsync(userId);

            if (user == null)
            {
                return null;
            }

            return user.Adapt<UserSummaryDTO>();
        }

        public async Task CreateAdminAsync(AdminDto adminDto)
        {
            var admin = adminDto.MapToAdmin();
            await _uow.UsersRep.AddAsync(admin);
            await _uow.SaveAsync();
            _cacheWrapper.Invalidate(USER_LIST_CACHE_KEY);
        }

        public async Task CreateCustomerAsync(CustomerDto customerDto)
        {
            var customer = customerDto.MapToCustomer();
            await _uow.UsersRep.AddAsync(customer);
            await _uow.SaveAsync();
            _cacheWrapper.Invalidate(USER_LIST_CACHE_KEY);
        }

        public async Task UpdateAdminAsync(int userId, AdminDto adminDto)
        {
            var user = await _uow.UsersRep.GetByIdAsync(userId);

            if (user == null || user.Role != Role.Admin)
            {
                throw new KeyNotFoundException("Admin not found");
            }

            user.Username = adminDto.Username;
            user.Email = adminDto.Email;
            await _uow.SaveAsync();
            _cacheWrapper.Invalidate(USER_LIST_CACHE_KEY);
        }

        public async Task UpdateCustomerAsync(int userId, CustomerDto customerDto)
        {
            Customer? customer = (Customer?)
                (
                    await _uow.UsersRep.WhereAsync(u => u is Customer && u.Id == userId)
                ).FirstOrDefault();

            if (customer == null || customer.Role != Role.Customer)
            {
                throw new KeyNotFoundException("Customer not found");
            }

            customer.Username = customerDto.Username;
            customer.Email = customerDto.Email;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.Address = customerDto.Address;
            customer.City = customerDto.City;
            customer.State = customerDto.State;
            customer.PostalCode = customerDto.PostalCode;

            await _uow.SaveAsync();
            _cacheWrapper.Invalidate(USER_LIST_CACHE_KEY);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _uow.UsersRep.GetByIdAsync(userId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            await _uow.UsersRep.DeleteAsync(user.Id);
            await _uow.SaveAsync();
            _cacheWrapper.Invalidate(USER_LIST_CACHE_KEY);
        }

        public async Task<IEnumerable<UserDetailDto>> GetAllUserDetailsAsync()
        {
            var users = await _cacheWrapper.GetOrCreateAsync(
                USER_LIST_CACHE_KEY,
                async () => await _uow.UsersRep.GetAllAsync(),
                CacheOptions
            );
            return users.Select(u => u.MapToUserDetailDto());
        }

        public async Task<IEnumerable<UserSummaryDTO>> GetAllUserSummariesAsync()
        {
            var users = await _cacheWrapper.GetOrCreateAsync(
                USER_LIST_CACHE_KEY,
                async () => await _uow.UsersRep.GetAllAsync(),
                CacheOptions
            );
            return users.Select(u => u.Adapt<UserSummaryDTO>());
        }
    }
}
