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
    public class CategoryRepository(MyDBContext _context) : ICategoryRepository
    {
        public async Task<Category?> AddAsync(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var added = (await _context.Categories.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();

            return added;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var existingCategory = await _context.Categories.FindAsync(entity.Id);

            if (existingCategory == null)
            {
                return false;
            }

            existingCategory.Name = entity.Name;

            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<CategorySummaryDto>> GetCategoriesSummariesAsync()
        {
            var categories = await _context.Categories
                .Select(c => new CategorySummaryDto
                {
                    CategoryId = c.Id,
                    Name = c.Name,
                    ProductCount = c.Products.Count()
                })
                .ToListAsync();

            return categories;
        }

        public async Task<CategorySummaryDto?> GetCategorySummaryAsync(int categoryId)
        {
            var categorySummary = await _context.Categories
                .Where(c => c.Id == categoryId)
                .Select(c => new CategorySummaryDto
                {
                    CategoryId = c.Id,
                    Name = c.Name,
                    ProductCount = c.Products.Count()
                })
                .FirstOrDefaultAsync();

            return categorySummary;
        }

        public async Task<IEnumerable<Category>> WhereAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _context.Categories.Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _context.Categories.AnyAsync(predicate);
        }
    }
}
