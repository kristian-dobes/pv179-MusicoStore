using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly MyDBContext _dbContext;

        public ProductService(MyDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
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

        public async Task UpdateProductAsync(UpdateProductDTO productDto, string modifiedBy)
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

            product.LastModifiedBy = modifiedBy;
            product.EditCount++;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> CreateProductAsync(CreateProductDTO productDto, string createdBy)
        {
            // Map CreateProductDTO to Product entity
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                ManufacturerId = productDto.ManufacturerId,
                LastModifiedBy = createdBy,
                EditCount = 0
            };

            // Add the product to the database
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId)
        {
            var productsToUpdate = await _dbContext.Products
                .Where(p => p.ManufacturerId == sourceManufacturerId)
                .ToListAsync();

            foreach (var product in productsToUpdate)
            {
                product.ManufacturerId = targetManufacturerId;
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProductsByManufacturerAsync(int manufacturerId)
        {
            return await _dbContext.Products
                    .Where(p => p.ManufacturerId == manufacturerId)
                    .ToListAsync();
        }

        public async Task UpdateProductManufacturerAsync(int productId, int newManufacturerId)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            product.ManufacturerId = newManufacturerId;

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

        public async Task DeleteProductAsync(int productId, string deletedBy)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}
