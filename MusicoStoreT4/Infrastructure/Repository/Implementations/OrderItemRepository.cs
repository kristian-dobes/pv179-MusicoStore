using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Implementations
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        private readonly MyDBContext _context;

        public OrderItemRepository(MyDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> UpdateAsync(OrderItem entity)
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
    }
}
