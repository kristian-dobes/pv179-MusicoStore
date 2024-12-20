using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public Task<OrderItem?> Add(OrderItem entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(OrderItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
