using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByAsync(int userId);
        IQueryable<Order> GetAllOrdersWithDetailsQuery();
        Task<bool> ExistsAsync(int id);
    }
}
