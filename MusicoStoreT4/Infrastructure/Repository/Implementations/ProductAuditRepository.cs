using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductAuditRepository : IProductAuditRepository
    {
        private readonly MyDBContext _context;

        public ProductAuditRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<AuditLog?> Add(AuditLog entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            AuditLog added = (await _context.AuditLogs.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return added;
        }

        public async Task<bool> Delete(int id)
        {
            var auditLog = await _context.AuditLogs.FindAsync(id);

            if (auditLog == null)
                return false;

            _context.AuditLogs.Remove(auditLog);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AuditLog>> GetAll()
        {
            return await _context.AuditLogs.ToListAsync();
        }

        public async Task<AuditLog?> GetById(int id)
        {
            return await _context.AuditLogs.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> Update(AuditLog entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingAuditLog = await _context.AuditLogs.FindAsync(entity.Id);

            if (existingAuditLog == null)
                return false;

            existingAuditLog.ProductId = entity.ProductId;
            existingAuditLog.Action = entity.Action;
            existingAuditLog.ModifiedById = entity.ModifiedById;

            _context.AuditLogs.Update(existingAuditLog);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
