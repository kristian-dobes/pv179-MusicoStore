using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDBContext _context;

        public ProductRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<Product?> AddAsync(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var addedEntity = (await _context.Products.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return addedEntity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingProduct = await _context.Products.FindAsync(entity.Id);

            if (existingProduct == null)
                return false;

            existingProduct.Name = entity.Name;
            existingProduct.Description = entity.Description;
            existingProduct.Price = entity.Price;
            existingProduct.QuantityInStock = entity.QuantityInStock;
            existingProduct.LastModifiedById = entity.LastModifiedById;
            existingProduct.EditCount = entity.EditCount;
            existingProduct.CategoryId = entity.CategoryId;
            existingProduct.ManufacturerId = entity.ManufacturerId;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> WhereAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products.Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Products.AnyAsync(predicate);
        }
    }
}
