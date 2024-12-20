using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDBContext _context;

        public OrderRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<Order?> Add(Order entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Order added = (await _context.Orders.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return added;
        }

        public async Task<bool> Delete(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetById(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> Update(Order entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingOrder = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == entity.Id);

            if (existingOrder == null)
                return false;

            existingOrder.Date = entity.Date;
            existingOrder.UserId = entity.UserId;

            _context.OrderItems.RemoveRange(existingOrder.OrderItems ?? Enumerable.Empty<OrderItem>());

            if (entity.OrderItems != null)
            {
                foreach (var item in entity.OrderItems)
                {
                    item.OrderId = entity.Id;
                }
                await _context.OrderItems.AddRangeAsync(entity.OrderItems);
            }

            _context.Orders.Update(existingOrder);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
