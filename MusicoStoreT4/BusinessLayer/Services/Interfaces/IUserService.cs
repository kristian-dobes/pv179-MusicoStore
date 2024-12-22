using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;
using BusinessLayer.DTOs.User;
using BusinessLayer.DTOs.User.Admin;
using BusinessLayer.DTOs.User.Customer;
using Shared.DTOs;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserService : IBaseService
    {
        public Task<List<UserSummaryDto>> GetUserSummariesAsync();
        public Task<CustomerSegmentsDto> GetCustomerSegmentsAsync();
        public Task<OrderItemDto?> GetMostFrequentBoughtItemAsync(int userId);
        public Task<bool> ValidateUserAsync(int userId);
        public Task<IEnumerable<UserDto>> GetAllUsersAsync();
        public Task<IEnumerable<UserDetailDto>> GetAllUserDetailsAsync();
        public Task<UserDetailDto?> GetUserByIdAsync(int userId);
        public Task CreateAdminAsync(AdminDto adminDto);
        public Task CreateCustomerAsync(CustomerDto customerDto);
        public Task UpdateAdminAsync(int userId, AdminDto adminDto);
        public Task UpdateCustomerAsync(int userId, CustomerDto customerDto);
        public Task DeleteUserAsync(int userId);
    }
}
