﻿using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Implementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly MyDBContext _context;

        public OrderRepository(MyDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> UpdateAsync(Order entity)
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

            if (existingOrder.OrderItems != null)
                _context.OrderItems.RemoveRange(existingOrder.OrderItems);

            if (entity.OrderItems != null && entity.OrderItems.Any())
            {
                foreach (var item in entity.OrderItems)
                    item.OrderId = entity.Id;

                await _context.OrderItems.AddRangeAsync(entity.OrderItems);
            }

            _context.Orders.Update(existingOrder);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Order>> GetOrdersByAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ThenInclude(p => p.Image)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.Date)
                .ToListAsync();
        }
    }
}
