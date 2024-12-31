using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByAsync(int userId);
        IQueryable<Order> GetAllOrdersWithDetailsQuery();
        Task<bool> ExistsAsync(int id);
    }
}
