using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public IQueryable<OrderItem> GetUserOrderItemsQuery(int userId);
        Task<string?> GetIdentityUserIdByUserIdAsync(int userId);
        //Task<List<UserSummaryDto>> GetUserSummariesAsync();
    }
}
