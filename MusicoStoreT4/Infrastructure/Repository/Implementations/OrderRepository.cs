using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyDBContext _context;

        public OrderRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<Order?> AddAsync(Order entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Order added = (await _context.Orders.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return added;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<bool> UpdateAsync(Order entity)
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

        public async Task<IEnumerable<Order>> WhereAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Orders.Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Orders.AnyAsync(predicate);
        }

        public async Task<bool> DeleteByIdsAsync(IEnumerable<int> ids)
        {
            var entities = await _context.Set<Order>()
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();

            if (!entities.Any())
            {
                return false;
            }

            _context.Set<Order>().RemoveRange(entities);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
