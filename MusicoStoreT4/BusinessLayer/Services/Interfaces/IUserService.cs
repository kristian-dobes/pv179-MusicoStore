using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IUserService : IBaseService
    {
        public Task<List<UserSummaryDto>> GetUserSummariesAsync();
        public Task<CustomerSegmentsDto> GetCustomerSegmentsAsync();
        public Task<OrderItemDto?> GetMostFrequentBoughtItemAsync(int userId);
        public Task<bool> ValidateUserAsync(int userId);
    }
}
