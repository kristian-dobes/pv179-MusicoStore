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
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace BusinessLayer.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAuditLogService _auditLogService;

        public ProductService(IUnitOfWork unitOfWork, IAuditLogService auditLogService) : base(unitOfWork)
        {
            _uow = unitOfWork;
            _auditLogService = auditLogService;
        }

        public async Task<ProductDto?> GetProductByIdAsync(int productId)
        {
            var product = await _uow.ProductsRep.GetByIdAsync(productId);

            if (product == null)
                return null;

            return product.MapToProductDTO();
        }

        public async Task UpdateProductAsync(UpdateProductDto productDto, int modifiedById)
        {
            var product = await _uow.ProductsRep.GetByIdAsync(productDto.Id);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productDto.Id} not found.");

            if (productDto.ManufacturerId.HasValue)
            {
                var manufacturer = await _uow.ManufacturersRep.GetByIdAsync(productDto.ManufacturerId.Value);
                if (manufacturer == null)
                    throw new KeyNotFoundException($"Manufacturer with ID {productDto.ManufacturerId} not found.");
                product.Manufacturer = manufacturer;
            }

            if (productDto.CategoryId.HasValue)
            {
                var category = await _uow.CategoriesRep.GetByIdAsync(productDto.CategoryId.Value);
                if (category == null)
                    throw new KeyNotFoundException($"Category with ID {productDto.CategoryId} not found.");
                product.Category = category;
            }

            if (!string.IsNullOrEmpty(productDto.Name))
                product.Name = productDto.Name;

            if (!string.IsNullOrEmpty(productDto.Description))
                product.Description = productDto.Description;

            if (productDto.Price.HasValue)
                product.Price = productDto.Price.Value;

            product.LastModifiedById = modifiedById;
            product.EditCount++;

            await _auditLogService.LogAsync(productDto.Id, AuditAction.Update, modifiedById);
            await _uow.SaveAsync();
        }

        public async Task<Product> CreateProductAsync(CreateProductDto productDto, int createdById)
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

            var added = await _uow.ProductsRep.AddAsync(product);

            try
            {
                await _auditLogService.LogAsync(added.Id, AuditAction.Create, createdById);
                await _uow.SaveAsync();

                return added;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error occurred while creating the product.", ex);
            }
        }

        public async Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId, int modifiedBy)
        {
            var productsToUpdate = await _uow.ProductsRep.WhereAsync(p => p.ManufacturerId == sourceManufacturerId);

            foreach (var product in productsToUpdate)
            {
                product.ManufacturerId = targetManufacturerId;
                product.LastModifiedById = modifiedBy;
                product.EditCount++;
                await _auditLogService.LogAsync(product.Id, AuditAction.Update, modifiedBy);
            }

            await _uow.SaveAsync();
        }

        public async Task<List<Product>> GetProductsByManufacturerAsync(int manufacturerId)
        {
            return (await _uow.ProductsRep.WhereAsync(p => p.ManufacturerId == manufacturerId)).ToList();
        }

        public async Task UpdateProductManufacturerAsync(int productId, int newManufacturerId, int modifiedBy)
        {
            var product = await _uow.ProductsRep.GetByIdAsync(productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            product.ManufacturerId = newManufacturerId;
            product.LastModifiedById = modifiedBy;
            product.EditCount++;

            await _auditLogService.LogAsync(product.Id, AuditAction.Update, modifiedBy);
            await _uow.SaveAsync();
        }

        public async Task<List<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(DateTime startDate, DateTime endDate, int topN = 5)
        {
            // Fetch order items within the date range using the repository
            var orderItems = await _uow.OrderItemsRep.GetByDateRangeAsync(startDate, endDate);

            // Perform the grouping and aggregation in-memory
            var query = orderItems
                .GroupBy(oi => new { oi.Product.Category.Id, oi.Product.Category.Name })
                .Select(categoryGroup => new TopSellingProductDto
                {
                    CategoryId = categoryGroup.Key.Id,
                    CategoryName = categoryGroup.Key.Name,
                    Products = categoryGroup
                        .GroupBy(oi => new { oi.Product.Id, oi.Product.Name })
                        .Select(productGroup => new ProductSalesDto
                        {
                            ProductId = productGroup.Key.Id,
                            ProductName = productGroup.Key.Name,
                            TotalUnitsSold = productGroup.Sum(x => x.Quantity),
                            Revenue = productGroup.Sum(x => x.Quantity * x.Price)
                        })
                        .OrderByDescending(p => p.TotalUnitsSold)
                        .Take(topN)
                        .ToList()
                }).ToList();

            return query;
        }

        public async Task DeleteProductAsync(int productId, int deletedBy)
        {
            var product = await _uow.ProductsRep.GetByIdAsync(productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            await _auditLogService.LogAsync(product.Id, AuditAction.Delete, deletedBy);
            await _uow.ProductsRep.DeleteAsync(productId);
            await _uow.SaveAsync();
        }
    }
}
