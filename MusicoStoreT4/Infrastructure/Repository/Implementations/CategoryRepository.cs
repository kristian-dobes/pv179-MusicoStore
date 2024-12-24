using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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

            _context.Categories.Update(existingCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Category>> GetCategoriesWithProductsAsync()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public IQueryable<Category> GetAllQuery()
        {
            return _context.Categories.AsQueryable();
        }
    }
}
