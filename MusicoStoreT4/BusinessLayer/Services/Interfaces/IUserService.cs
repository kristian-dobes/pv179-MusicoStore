﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;
using BusinessLayer.DTOs.User;
using BusinessLayer.DTOs.User.Admin;
using BusinessLayer.DTOs.User.Customer;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserService : IBaseService
    {
        Task<CustomerSegmentsDto> GetCustomerSegmentsAsync();
        Task<OrderItemDto?> GetMostFrequentBoughtItemAsync(int userId);
        Task<bool> ValidateUserAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<IEnumerable<UserDetailDto>> GetAllUserDetailsAsync();
        Task<UserSummaryDTO?> GetUserByIdAsync(int userId);
        Task CreateAdminAsync(AdminDto adminDto);
        Task CreateCustomerAsync(CustomerDto customerDto);
        Task UpdateAdminAsync(int userId, AdminDto adminDto);
        Task UpdateCustomerAsync(int userId, CustomerDto customerDto);
        Task DeleteUserAsync(int userId);
        Task<IEnumerable<UserSummaryDTO>> GetAllUserSummariesAsync();
    }
}
