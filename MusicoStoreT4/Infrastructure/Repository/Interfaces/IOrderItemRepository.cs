using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IOrderItemRepository : IRepository<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
