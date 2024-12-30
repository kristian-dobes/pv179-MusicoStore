using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public IQueryable<Product> GetQuery()
        {
            return _context.Products.AsQueryable();
        }

        public async Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await _context.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
        }

        public async Task<List<int>> GetProductIdsByManufacturerAsync(int manufacturerId)
        {
            return await _context.Products
                .Where(p => p.ManufacturerId == manufacturerId)
                .Select(p => p.Id)
                .ToListAsync();
        }

        public async Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int destinationManufacturerId, int modifiedById)
        {
            await _context.Products
                .Where(p => p.ManufacturerId == sourceManufacturerId)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(p => p.ManufacturerId, destinationManufacturerId)
                    .SetProperty(p => p.LastModifiedById, modifiedById)
                );
        }

        public async Task UpdatePrimaryCategoryAsync(IEnumerable<int> productIds, int newCategoryId)
        {
            var products = _context.Products.Where(p => productIds.Contains(p.Id));
            await products.ForEachAsync(p => p.PrimaryCategoryId = newCategoryId);
        }

        public async Task UpdateSecondaryCategoriesAsync(IEnumerable<int> productIds, int newCategoryId, IEnumerable<int> oldCategoryIds)
        {
            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .Include(p => p.SecondaryCategories)
                .ToListAsync();

            var oldCategoryIdsSet = new HashSet<int>(oldCategoryIds);

            var newCategory = await _context.Categories.FindAsync(newCategoryId);
            if (newCategory == null)
            {
                throw new InvalidOperationException("New category not found");
            }

            foreach (var product in products)
            {
                var categoriesToRemove = product.SecondaryCategories
                    .Where(c => oldCategoryIdsSet.Contains(c.Id))
                    .ToList();

                foreach (var category in categoriesToRemove)
                {
                    product.SecondaryCategories.Remove(category);
                }

                product.SecondaryCategories.Add(newCategory);
            }

            await _context.SaveChangesAsync();
        }
    }
}
