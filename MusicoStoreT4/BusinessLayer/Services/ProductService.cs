using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Enums;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Implementations;
using Infrastructure.Repository.Interfaces;
using Infrastructure.UnitOfWork;
using Mapster;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;

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

        public async Task<ProductCompleteDTO?> GetProductByIdAsync(int productId)
        {
            var product = await _uow.ProductsRep.GetByIdAsync(productId);
            
            if (product == null)
                return null;
            
            return product?.Adapt<ProductCompleteDTO>();
        }

        public async Task<IEnumerable<ProductCompleteDTO>> GetAllProductsAsync()
        {
            var products = await _uow.ProductsRep.GetAllAsync();

            var productDtos = products.Select(p => p.Adapt<ProductCompleteDTO>()).ToList();

            return productDtos;
        }
        public async Task<IEnumerable<ProductWithDetailsDto>> GetAllProductsWithDetailsAsync()
        {
            var products = await _uow.ProductsRep.GetAllWithDetailsAsync();

            return products.Select(p => new ProductWithDetailsDto
            {
                ProductId = p.Id,
                ProductName = p.Name,
                ProductDateOfCreation = p.Created,
                ProductDescription = p.Description,
                ProductPrice = p.Price,
                ProductQuantityInStock = p.QuantityInStock,
                ProductManufacturer = p.ManufacturerId,
                ProductCategory = p.CategoryId,
                OrderItems = p.OrderItems.Select(oi => new OrderItemDto
                {
                    OrderItemId = oi.Id,
                    ProductId = p.Id,
                    Quantity = oi.Quantity,
                }).ToList(),
                Category = p.Category != null ? p.Category.Adapt<CategorySummaryDTO>() : null,
                Manufacturer = p.Manufacturer != null ? p.Manufacturer.Adapt<ManufacturerSummaryDTO>() : null
            }).ToList();
        }

        public async Task<ProductCompleteDTO> UpdateProductAsync(int productId, ProductUpdateDTO productDto)
        {
            // Fetch product by ID
            var product = await _uow.ProductsRep.GetByIdAsync(productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            // Validate Manufacturer
            var manufacturer = await _uow.ManufacturersRep.GetByIdAsync(productDto.ManufacturerId);
            if (manufacturer == null)
                throw new KeyNotFoundException($"Manufacturer with ID {productDto.ManufacturerId} not found.");
            product.Manufacturer = manufacturer;

            // Validate Category
            var category = await _uow.CategoriesRep.GetByIdAsync(productDto.CategoryId);
            if (category == null)
                throw new KeyNotFoundException($"Category with ID {productDto.CategoryId} not found.");
            product.Category = category;

            // Update product fields
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.QuantityInStock = productDto.QuantityInStock;
            product.LastModifiedById = productDto.LastModifiedById;
            product.EditCount++;
            product.CategoryId = productDto.CategoryId;
            product.ManufacturerId = productDto.ManufacturerId;

            // Log the update action and save changes
            await _auditLogService.LogAsync(productId, AuditAction.Update, productDto.LastModifiedById);
            await _uow.SaveAsync();

            return product.Adapt<ProductCompleteDTO>();
        }

        public async Task<ProductDto> CreateProductAsync(ProductCreateDTO productDto)
        {
            if (productDto.Price <= 0)
                throw new ArgumentException("Price must be valid");

            if (await _uow.ProductsRep.AnyAsync(a => a.Name == productDto.Name))
                throw new ArgumentException($"Product with name '{productDto.Name}' already exists");

            if (!(await _uow.CategoriesRep.AnyAsync(c => c.Id == productDto.CategoryId)))
                throw new ArgumentException($"Category with id {productDto.CategoryId} not found");

            if (!(await _uow.ManufacturersRep.AnyAsync(m => m.Id == productDto.ManufacturerId)))
                throw new ArgumentException($"Manufacturer with id {productDto.ManufacturerId} not found");

            //var product = new Product
            //{
            //    Name = productDto.Name,
            //    Description = productDto.Description,
            //    Price = productDto.Price,
            //    CategoryId = productDto.CategoryId,
            //    ManufacturerId = productDto.ManufacturerId,
            //    LastModifiedById = createdById,
            //    EditCount = 0
            //};

            var product = productDto.Adapt<Product>();

            var added = await _uow.ProductsRep.AddAsync(product);
            try
            {
                await _auditLogService.LogAsync(added.Id, AuditAction.Create, productDto.LastModifiedById);
                await _uow.SaveAsync();

                return added.MapToProductDTO();
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

        public async Task<IEnumerable<ProductDto>> GetProductsByManufacturerAsync(int manufacturerId)
        {
            return (await _uow.ProductsRep.WhereAsync(p => p.ManufacturerId == manufacturerId))
                .Select(p => p.MapToProductDTO())
                .ToList();
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

        public async Task<IEnumerable<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(DateTime startDate, DateTime endDate, int topN = 5)
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

            await _auditLogService.LogAsync(productId, AuditAction.Delete, deletedBy);
            await _uow.ProductsRep.DeleteAsync(productId);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetFilteredProductsAsync(FilterProductDto filterProductDto)
        {
            var productsQuery = _uow.ProductsRep.GetAllQuery();

            if (!string.IsNullOrEmpty(filterProductDto.Name))
                productsQuery = productsQuery.Where(p =>
                    p.Name.ToLower().Contains(filterProductDto.Name.ToLower())
                );

            if (!string.IsNullOrEmpty(filterProductDto.Description))
                productsQuery = productsQuery.Where(p =>
                    p.Description.ToLower().Contains(filterProductDto.Description.ToLower())
                );

            decimal minPrice = filterProductDto.MinPrice ?? decimal.MinValue;
            decimal maxPrice = filterProductDto.MaxPrice ?? decimal.MaxValue;

            productsQuery = productsQuery.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

            if (filterProductDto.CategoryId.HasValue)
                productsQuery = productsQuery.Where(p =>
                    p.CategoryId == filterProductDto.CategoryId
                );

            if (filterProductDto.ManufacturerId.HasValue)
                productsQuery = productsQuery.Where(p =>
                    p.ManufacturerId == filterProductDto.ManufacturerId
                );

            var products = await productsQuery
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Select(p => p.MapToProductDTO())
                .ToListAsync();

            return products;
        }
    }
}
