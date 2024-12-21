using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Implementations
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly MyDBContext _context;

        public OrderItemRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<OrderItem?> AddAsync(OrderItem entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            OrderItem added = (await _context.OrderItems.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return added;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
                return false;

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem?> GetByIdAsync(int id)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(oi => oi.Id == id);
        }

        public async Task<bool> UpdateAsync(OrderItem entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingOrderItem = await _context.OrderItems.FindAsync(entity.Id);

            if (existingOrderItem == null)
                return false;

            existingOrderItem.OrderId = entity.OrderId;
            existingOrderItem.ProductId = entity.ProductId;
            existingOrderItem.Quantity = entity.Quantity;
            existingOrderItem.Price = entity.Price;

            _context.OrderItems.Update(existingOrderItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OrderItem>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.OrderItems
                .Include(oi => oi.Product)
                .ThenInclude(p => p.Category)
                .Where(oi => oi.Order.Date >= startDate && oi.Order.Date <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderItem>> WhereAsync(Expression<Func<OrderItem, bool>> predicate)
        {
            return await _context.OrderItems.Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<OrderItem, bool>> predicate)
        {
            return await _context.OrderItems.AnyAsync(predicate);
        }

        public async Task<bool> DeleteByIdsAsync(IEnumerable<int> ids)
        {
            var entities = await _context.Set<OrderItem>()
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();

            if (!entities.Any())
            {
                return false;
            }

            _context.Set<OrderItem>().RemoveRange(entities);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
