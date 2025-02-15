﻿using System.Linq.Expressions;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly MyDBContext _context;

        public CategoryRepository(MyDBContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<bool> UpdateAsync(Category entity)
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

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetCategoriesWithProductsAsync()
        {
            return await _context
                .Categories.Include(c => c.PrimaryProducts)
                .Include(c => c.SecondaryProducts)
                .ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesWithPrimaryProductsAsync()
        {
            return await _context.Categories.Include(c => c.PrimaryProducts).ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesWithSecondaryProductsAsync()
        {
            return await _context.Categories.Include(c => c.SecondaryProducts).ToListAsync();
        }

        public async Task<Category?> GetCategoryWithAllProductsAsync(int categoryId)
        {
            return await _context.Categories
                .Include(c => c.PrimaryProducts)
                .Include(c => c.SecondaryProducts)
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public IQueryable<Category> GetAllQuery()
        {
            return _context.Categories.AsQueryable();
        }

        public IQueryable<Category> GetQueryProducts()
        {
            return _context.Categories.
                Include(c => c.PrimaryProducts).
                Include(c => c.SecondaryProducts);
        }

        public IQueryable<Category> GetQueryById(int id)
        {
            return _context.Categories
                .Where(c => c.Id == id)
                .Include(c => c.PrimaryProducts)
                .Include(c => c.SecondaryProducts);
        }

        public async Task<bool> HasProductsAsync(int categoryId)
        {
            return await _context.Categories
                .Where(c => c.Id == categoryId)
                .AnyAsync(c => c.PrimaryProducts.Any() || c.SecondaryProducts.Any());
        }

        public async Task<Category?> GetByConditionAsync(Expression<Func<Category, bool>> predicate)
        {
            return await _context.Categories.FirstOrDefaultAsync(predicate);
        }

        public async Task DeleteCategoriesAsync(IEnumerable<int> categoryIds)
        {
            var categories = _context.Categories.Where(c => categoryIds.Contains(c.Id)).ToList();
            _context.Categories.RemoveRange(categories);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsNameUniqueAsync(string name, int? excludeCategoryId = null)
        {
            return !await _context.Categories
                .AnyAsync(c => c.Name == name && (!excludeCategoryId.HasValue || c.Id != excludeCategoryId.Value));
        }
    }
}
