using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly MyDBContext _context;

        public OrderItemRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<OrderItem?> Add(OrderItem entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            OrderItem added = (await _context.OrderItems.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return added;
        }

        public async Task<bool> Delete(int id)
        {
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
                return false;

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            return await _context.OrderItems.ToListAsync();
        }

        public async Task<OrderItem?> GetById(int id)
        {
            return await _context.OrderItems.FirstOrDefaultAsync(oi => oi.Id == id);
        }

        public async Task<bool> Update(OrderItem entity)
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
    }
}
