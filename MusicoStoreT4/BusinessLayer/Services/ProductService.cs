using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Enums;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ICollection<ProductCompleteDTO>> GetProducts()
        {
            IQueryable<Product> productQuery = _dbContext.Products;

            // Fetch data into a list
            var products = await productQuery.ToListAsync();

            // Map to DTOs
            var productDTOs = products.Adapt<ICollection<ProductCompleteDTO>>();

            return productDTOs;
        }

        public async Task<ProductCompleteDTO?> GetProductByIdAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            return product?.Adapt<ProductCompleteDTO>();
        }

        public async Task<ProductCompleteDTO?> UpdateProductAsync(int id, ProductUpdateDTO productDto)
        {
            var product = await _dbContext.Products.FindAsync(id);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {id} not found.");

            var manufacturer = await _dbContext.Manufacturers.FindAsync(productDto.ManufacturerId);
            if (manufacturer == null)
                throw new KeyNotFoundException($"Manufacturer with ID {productDto.ManufacturerId} not found.");

            var category = await _dbContext.Categories.FindAsync(productDto.CategoryId);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {productDto.CategoryId} not found.");

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.QuantityInStock = productDto.QuantityInStock;
            product.LastModifiedById = productDto.LastModifiedById;
            product.EditCount++;

            await _auditLogService.LogAsync(product.Id, AuditAction.Update, productDto.LastModifiedById);
            _dbContext.Products.Update(product);
            await SaveAsync(true);

            return product.Adapt<ProductCompleteDTO>();
        }
        public async Task<ProductCompleteDTO> CreateProductAsync(ProductCreateDTO productDto)
        {
            var product = productDto.Adapt<Product>();

            product.EditCount = 0;

            var addedProduct = _dbContext.Products.Add(product).Entity;
            await _auditLogService.LogAsync(addedProduct.Id, AuditAction.Create, productDto.LastModifiedById);
            await SaveAsync(true);
           
            return product.Adapt<ProductCompleteDTO>();
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

            await SaveAsync(true);
        }

        public async Task<List<Product>> GetProductsByManufacturerAsync(int manufacturerId)
        {
            return await _dbContext.Products
                    .Where(p => p.ManufacturerId == manufacturerId)
                    .ToListAsync();
        }

        public async Task UpdateProductManufacturerAsync(int productId, int newManufacturerId, int modifiedBy)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            product.ManufacturerId = newManufacturerId;
            product.LastModifiedById = modifiedBy;
            product.EditCount++;
            await _auditLogService.LogAsync(product.Id, AuditAction.Update, modifiedBy);

            await SaveAsync(true);
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
                            Revenue = (decimal)productGroup.Sum(x => (double)(x.Quantity * x.Price))
                        })
                        .OrderByDescending(p => p.TotalUnitsSold)
                        .Take(topN)
                        .ToList()
                }).ToList();

            return query;
        }

        public async Task DeleteProductAsync(int productId, int deletedBy)
        {
            //TODO does this method need string deletedBy?
            // Optionally log the delete action or use the deletedBy field for audit purposes
            // e.g., _auditLogService.LogAsync(productId, "Delete", deletedBy);

            var product = await _dbContext.Products.FindAsync(productId);

            if (product != null)
            {
                await _auditLogService.LogAsync(product.Id, AuditAction.Delete, deletedBy);
                _dbContext.Products.Remove(product);
                await SaveAsync(true);
            }

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
        }

        public async Task<Boolean> IsProductValidAsync(int productId) 
        {
            // TODO might shoudl be implemented in repository ?
            return await _dbContext.Products.AnyAsync(p => p.Id == productId);
        }
    }
}
