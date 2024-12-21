using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementations.Implementations
{
    public class LogRepository : ILogRepository
    {
        private readonly MyDBContext _context;

        public LogRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<Log?> AddAsync(Log entity)
        {
            var log = (await _context.Logs.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var log = await _context.Logs.FindAsync(id);
            if (log == null)
            {
                return false;
            }

            _context.Logs.Remove(log);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Log>> GetAllAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<Log?> GetByIdAsync(int id)
        {
            return await _context.Logs.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Log entity)
        {
            var existingLog = await _context.Logs.FindAsync(entity.Id);
            if (existingLog == null)
            {
                return false;
            }

            existingLog.Method = entity.Method;
            existingLog.Path = entity.Path;
            existingLog.Created = entity.Created;

            _context.Logs.Update(existingLog);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Log>> WhereAsync(Expression<Func<Log, bool>> predicate)
        {
            return await _context.Logs.Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Log, bool>> predicate)
        {
            return await _context.Logs.AnyAsync(predicate);
        }

        public async Task<bool> DeleteByIdsAsync(IEnumerable<int> ids)
        {
            var entities = await _context.Set<Log>()
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();

            if (!entities.Any())
            {
                return false;
            }

            _context.Set<Log>().RemoveRange(entities);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
