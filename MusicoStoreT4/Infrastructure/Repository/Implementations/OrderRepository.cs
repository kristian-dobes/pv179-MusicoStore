using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Order?> Add(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
