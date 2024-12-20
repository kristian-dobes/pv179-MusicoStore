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
    public class CategoryRepository(MyDBContext _context) : ICategoryRepository
    {
        public async Task<Category?> Add(Category entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var added = (await _context.Categories.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();

            return added;
        }

        public async Task<bool> Delete(int id)
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

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<bool> Update(Category entity)
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
    }
}
