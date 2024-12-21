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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<ICollection<ProductCompleteDTO>> GetProducts()
        {
            IQueryable<Product> productQuery = _dBContext.Products;

            // Fetch data into a list
            var products = await productQuery.ToListAsync();

            // Map to DTOs
            var productDTOs = products.Adapt<ICollection<ProductCompleteDTO>>();

            return productDTOs;
        }

        public async Task<ProductCompleteDTO?> GetProductByIdAsync(int productId)
        {
            var product = await _dBContext.Products.SingleOrDefaultAsync(a => a.Id == productId);

            return product?.Adapt<ProductCompleteDTO>();
        }

        public async Task<ProductCompleteDTO?> UpdateProductAsync(int id, ProductUpdateDTO productDto)
        {
            var product = await _dBContext.Products.FindAsync(id);

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
            {
                //throw new KeyNotFoundException($"Product with ID {id} not found.");
                return null;
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.LastModifiedById = modifiedById;
            product.EditCount++;
            await _auditLogService.LogAsync(productDto.Id, AuditAction.Update, modifiedById);
            _dBContext.Products.Update(product);
            await SaveAsync(true);
            product.QuantityInStock = model.QuantityInStock;
            return product.Adapt<ProductCompleteDTO>();
            product.LastModifiedBy = modifiedBy;
            product.EditCount++;

            await _dBContext.SaveChangesAsync();
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

        public async Task<ProductCompleteDTO> CreateProductAsync(ProductCreateDTO productDto)
        {
            var product = productDto.Adapt<Product>();

            product.EditCount = 0;

            _dBContext.Products.Add(product);
            await SaveAsync(true);
           
            return product.Adapt<ProductCompleteDTO>();
        }

        public async Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId)
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

            var product = await _dBContext.Products.FindAsync(productId);

            if (product != null)
            {
                _dBContext.Products.Remove(product);
                await SaveAsync(true);
            }

            //if (product == null)
            //    throw new KeyNotFoundException($"Product with ID {productId} not found.");
        }

        public async Task<Boolean> IsProductValidAsync(int productId) 
        {
            // TODO might shoudl be implemented in repository ?
            return await _dBContext.Products.AnyAsync(p => p.Id == productId);
        }
    }
}
