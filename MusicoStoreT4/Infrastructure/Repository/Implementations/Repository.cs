using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Implementations
{
    public abstract class Repository<T>(MyDBContext _context) : IRepository<T> where T : BaseEntity
    {
        public async Task<T?> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var added = (await _context.Set<T>().AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return added;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var T = await _context.Set<T>().FindAsync(id);

            if (T == null)
            {
                return false;
            }

            _context.Set<T>().Remove(T);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<bool> DeleteByIdsAsync(IEnumerable<int> ids)
        {
            var entities = await _context.Set<T>()
                .Where(e => ids.Contains(e.Id))
            .ToListAsync();

            if (!entities.Any())
            {
                return false;
            }

            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();

            return true;
        }

        public abstract Task<bool> UpdateAsync(T entity);
    }
}
