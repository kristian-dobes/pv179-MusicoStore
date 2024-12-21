using DataAccessLayer.Models;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User?> GetUserWithOrdersAsync(int userId);
        Task<List<UserSummaryDto>> GetUserSummariesAsync();
    }
}
