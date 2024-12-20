using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Enums;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace BusinessLayer.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly MyDBContext _dbContext;
        private readonly IAuditLogService _auditLogService;

        public ProductService(MyDBContext dBContext, IAuditLogService auditLogService) : base(dBContext)
        {
            _dbContext = dBContext;
            _auditLogService = auditLogService;
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                return null;

            return new ProductDto
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category?.Name,
                ManufacturerName = product.Manufacturer?.Name
            };
        }

        public async Task UpdateProductAsync(UpdateProductDTO productDto, int modifiedById)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productDto.Id);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productDto.Id} not found.");

            var manufacturer = await _dbContext.Manufacturers.FirstOrDefaultAsync(m => m.Id == productDto.ManufacturerId);
            if (manufacturer == null)
                throw new KeyNotFoundException($"Manufacturer with ID {productDto.ManufacturerId} not found.");

            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == productDto.CategoryId);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {productDto.CategoryId} not found.");

            product.Name = productDto.Name;
            product.Description = productDto.Description;

            if (productDto.Price.HasValue)
                product.Price = productDto.Price.Value;

            product.Manufacturer = manufacturer;
            product.Category = category;

            product.LastModifiedById = modifiedById;
            product.EditCount++;
            await _auditLogService.LogAsync(productDto.Id, AuditAction.Update, modifiedById);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> CreateProductAsync(CreateProductDTO productDto, int createdById)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                ManufacturerId = productDto.ManufacturerId,
                LastModifiedById = createdById,
                EditCount = 0
            };

            var added = _dbContext.Products.Add(product).Entity;

            try
            {
                await _dbContext.SaveChangesAsync();
                await _auditLogService.LogAsync(added.Id, AuditAction.Create, createdById);

                return added;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while creating the product.", ex);
            }
        }

        public async Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId, int modifiedBy)
        {
            var productsToUpdate = await _dbContext.Products
                .Where(p => p.ManufacturerId == sourceManufacturerId)
                .ToListAsync();

            foreach (var product in productsToUpdate)
            {
                product.ManufacturerId = targetManufacturerId;
                product.LastModifiedById = modifiedBy;
                product.EditCount++;
                await _auditLogService.LogAsync(product.Id, AuditAction.Update, modifiedBy);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductsByManufacturerAsync(int manufacturerId)
        {
            return await _dbContext.Products
                    .Where(p => p.ManufacturerId == manufacturerId)
                    .ToListAsync();
        }

        public async Task UpdateProductManufacturerAsync(int productId, int newManufacturerId, int modifiedBy)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            product.ManufacturerId = newManufacturerId;
            product.LastModifiedById = modifiedBy;
            product.EditCount++;
            await _auditLogService.LogAsync(product.Id, AuditAction.Update, modifiedBy);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(DateTime startDate, DateTime endDate, int topN = 5)
        {
            var orderItems = await (from orderItem in _dbContext.OrderItems
                                    join product in _dbContext.Products on orderItem.ProductId equals product.Id
                                    join category in _dbContext.Categories on product.CategoryId equals category.Id
                                    where orderItem.Order.Date >= startDate && orderItem.Order.Date <= endDate
                                    select new
                                    {
                                        CategoryId = category.Id,
                                        CategoryName = category.Name,
                                        ProductId = product.Id,
                                        ProductName = product.Name,
                                        orderItem.Quantity,
                                        orderItem.Price
                                    }).ToListAsync();

            var query = orderItems
                .GroupBy(item => new { item.CategoryId, item.CategoryName })
                .Select(categoryGroup => new TopSellingProductDto
                {
                    CategoryId = categoryGroup.Key.CategoryId,
                    CategoryName = categoryGroup.Key.CategoryName,
                    Products = categoryGroup
                        .GroupBy(product => new { product.ProductId, product.ProductName })
                        .Select(productGroup => new ProductSalesDto
                        {
                            ProductId = productGroup.Key.ProductId,
                            ProductName = productGroup.Key.ProductName,
                            TotalUnitsSold = productGroup.Sum(x => x.Quantity),
                            Revenue = (decimal)productGroup.Sum(x => (double)(x.Quantity * x.Price)) // Cast to double
                        })
                        .OrderByDescending(p => p.TotalUnitsSold)
                        .Take(topN)
                        .ToList()
                }).ToList();

            return query;
        }

        public async Task DeleteProductAsync(int productId, int deletedBy)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            await _auditLogService.LogAsync(product.Id, AuditAction.Delete, deletedBy);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
