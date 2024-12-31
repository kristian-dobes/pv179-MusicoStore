using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public IQueryable<OrderItem> GetUserOrderItemsQuery(int userId);
        Task<string?> GetIdentityUserIdByUserIdAsync(int userId);
        //Task<List<UserSummaryDto>> GetUserSummariesAsync();
    }
}
