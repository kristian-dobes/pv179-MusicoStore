using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Implementations
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly MyDBContext _context;

        public ProductRepository(MyDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> UpdateAsync(Product entity)
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
            existingProduct.PrimaryCategoryId = entity.PrimaryCategoryId;
            existingProduct.ManufacturerId = entity.ManufacturerId;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllWithDetailsAsync()
        {
            return await _context.Products
                .Include(p => p.OrderItems)
                .Include(p => p.PrimaryCategory)
                .Include(p => p.Manufacturer)
                .ToListAsync();
        }

        public IQueryable<Product> GetAllQuery()
        {
            return _context.Products.AsQueryable();
        }
    }
}
