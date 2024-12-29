using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Infrastructure.UnitOfWork;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAuditLogService _auditLogService;

        public ProductService(IUnitOfWork unitOfWork, IAuditLogService auditLogService)
            : base(unitOfWork)
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

            return products
                .Select(p => new ProductWithDetailsDto
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductDateOfCreation = p.Created,
                    ProductDescription = p.Description,
                    ProductPrice = p.Price,
                    ProductQuantityInStock = p.QuantityInStock,
                    ProductManufacturer = p.ManufacturerId,
                    ProductCategory = p.PrimaryCategoryId,
                    OrderItems = p
                        .OrderItems.Select(oi => new OrderItemDto
                        {
                            ProductId = p.Id,
                            Quantity = oi.Quantity,
                        })
                        .ToList(),
                    Category = p.PrimaryCategory?.Adapt<CategorySummaryDTO>(),
                    Manufacturer = p.Manufacturer?.Adapt<ManufacturerSummaryDTO>()
                })
                .ToList();
        }

        public async Task<ProductCompleteDTO> UpdateProductAsync(
            int productId,
            ProductUpdateDTO productDto
        )
        {
            // Fetch product by ID
            var product = await _uow.ProductsRep.GetByIdAsync(productId);

            if (product == null)
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            // Validate Manufacturer
            var manufacturer = await _uow.ManufacturersRep.GetByIdAsync(productDto.ManufacturerId);
            if (manufacturer == null)
                throw new KeyNotFoundException(
                    $"Manufacturer with ID {productDto.ManufacturerId} not found."
                );
            product.Manufacturer = manufacturer;

            // Validate Primary Category
            var primaryCategory = await _uow.CategoriesRep.GetByIdAsync(
                productDto.PrimaryCategoryId
            );
            if (primaryCategory == null)
                throw new KeyNotFoundException(
                    $"Category with ID {productDto.PrimaryCategoryId} not found."
                );

            // Validate Secondary Categories
            var secondaryCategories = await _uow.CategoriesRep.WhereAsync(c =>
                productDto.SecondaryCategoryIds.Contains(c.Id)
            );

            if (secondaryCategories.Count() != productDto.SecondaryCategoryIds.Count)
                throw new KeyNotFoundException("One or more secondary categories not found.");
            product.PrimaryCategory = primaryCategory;

            // Update product fields
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.QuantityInStock = productDto.QuantityInStock;
            product.LastModifiedById = productDto.LastModifiedById;
            product.EditCount++;
            product.PrimaryCategoryId = productDto.PrimaryCategoryId;
            product.ManufacturerId = productDto.ManufacturerId;
            product.SecondaryCategories?.Clear();
            product.SecondaryCategories = secondaryCategories.ToList();

            // Log the update action and save changes
            await _auditLogService.LogAsync(
                productId,
                AuditAction.Update,
                productDto.LastModifiedById
            );
            await _uow.SaveAsync();

            return product.Adapt<ProductCompleteDTO>();
        }

        public async Task<ProductDto> CreateProductAsync(ProductCreateDTO productDto)
        {
            if (productDto.Price <= 0)
                throw new ArgumentException("Price must be valid");

            if (await _uow.ProductsRep.AnyAsync(a => a.Name == productDto.Name))
                throw new ArgumentException(
                    $"Product with name '{productDto.Name}' already exists"
                );

            if (!await _uow.CategoriesRep.AnyAsync(c => c.Id == productDto.PrimaryCategoryId))
                throw new ArgumentException(
                    $"Category with id {productDto.PrimaryCategoryId} not found"
                );

            var secondaryCategories = await _uow.CategoriesRep.WhereAsync(c =>
                productDto.SecondaryCategoryIds.Contains(c.Id)
            );

            if (secondaryCategories.Count() != productDto.SecondaryCategoryIds.Count)
                throw new ArgumentException("One or more secondary categories not found.");

            if (!await _uow.ManufacturersRep.AnyAsync(m => m.Id == productDto.ManufacturerId))
                throw new ArgumentException(
                    $"Manufacturer with id {productDto.ManufacturerId} not found"
                );

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

            var product = productDto.MapToProduct(secondaryCategories);

            var added = await _uow.ProductsRep.AddAsync(product);
            try
            {
                await _auditLogService.LogAsync(
                    added.Id,
                    AuditAction.Create,
                    productDto.LastModifiedById
                );
                await _uow.SaveAsync();

                return added.Adapt<ProductDto>();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(
                    "Error occurred while creating the product.",
                    ex
                );
            }
        }

        public async Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int destinationManufacturerId, int modifiedById)
        {
            // products to reassign
            var productIds = await _uow.ProductsRep.GetProductIdsByManufacturerAsync(sourceManufacturerId);

            // reassign products
            await _uow.ProductsRep.ReassignProductsToManufacturerAsync(sourceManufacturerId, destinationManufacturerId, modifiedById);

            // Log each product update
            foreach (var productId in productIds)
            {
                await _auditLogService.LogAsync(productId, AuditAction.Update, modifiedById);
            }

            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByManufacturerAsync(
            int manufacturerId
        )
        {
            var products = await _uow.ProductsRep.WhereAsync(p =>
                p.ManufacturerId == manufacturerId
            );
            return products.Adapt<IEnumerable<ProductDto>>();
        }

        public async Task UpdateProductManufacturerAsync(
            int productId,
            int newManufacturerId,
            int modifiedBy
        )
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

        public async Task<IEnumerable<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(
            DateTime startDate,
            DateTime endDate,
            int topN = 5
        )
        {
            // Fetch order items within the date range using the repository
            var orderItems = await _uow.OrderItemsRep.GetByDateRangeAsync(startDate, endDate);

            // Perform the grouping and aggregation in-memory
            var query = orderItems
                .GroupBy(oi => new
                {
                    oi.Product.PrimaryCategory.Id,
                    oi.Product.PrimaryCategory.Name
                })
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
                })
                .ToList();

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

        public async Task<IEnumerable<ProductDto>> GetFilteredProductsAsync(
            FilterProductDto filterProductDto
        )
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
                    p.PrimaryCategoryId == filterProductDto.CategoryId
                );

            if (filterProductDto.ManufacturerId.HasValue)
                productsQuery = productsQuery.Where(p =>
                    p.ManufacturerId == filterProductDto.ManufacturerId
                );

            var products = await productsQuery
                .Include(p => p.PrimaryCategory)
                .Include(p => p.SecondaryCategories)
                .Include(p => p.Manufacturer)
                .ToListAsync();

            return products.Adapt<IEnumerable<ProductDto>>();
        }

        public async Task<(IEnumerable<ProductDto>, int totalCount)> GetProductsAsync(
            int page = 1,
            int pageSize = 10
        )
        {
            IQueryable<Product> productQuery = _uow
                .ProductsRep.GetAllQuery()
                .Include(a => a.PrimaryCategory)
                .Include(a => a.Manufacturer);

            // Get the total count of posts
            int totalCount = await productQuery.CountAsync();

            // Get the paginated list of posts
            var products = await productQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (products.Adapt<IEnumerable<ProductDto>>(), totalCount);
        }

        public async Task<SearchResultDto> SearchAsync(
            string? query,
            int page = 1,
            int pageSize = 5,
            string? manufacturer = null,
            string? category = null
        )
        {
            IQueryable<Product> productQuery = _uow
                .ProductsRep.GetAllQuery()
                .Include(p => p.Manufacturer)
                .Include(p => p.PrimaryCategory);

            string? searchQuery = query?.ToLower();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                productQuery = productQuery.Where(p =>
                    p.Manufacturer != null && p.Manufacturer.Name == manufacturer
                );
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                productQuery = productQuery.Where(p =>
                    (p.PrimaryCategory != null && p.PrimaryCategory.Name == category)
                    || p.SecondaryCategories.Select(c => c.Name).Contains(category)
                );
            }

            List<Manufacturer> manufacturers = new List<Manufacturer>();
            List<Category> categories = new List<Category>();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                productQuery = productQuery.Where(p =>
                    (
                        p.Name.ToLower().Contains(searchQuery)
                        || p.Description.ToLower().Contains(searchQuery)
                        || (
                            p.Manufacturer != null
                            && p.Manufacturer.Name.ToLower().Contains(searchQuery)
                        )
                        || (
                            p.PrimaryCategory != null
                            && p.PrimaryCategory.Name.ToLower().Contains(searchQuery)
                        )
                        || p.SecondaryCategories.Any(c => searchQuery.Contains(c.Name.ToLower()))
                    )
                );

                manufacturers = await _uow
                    .ManufacturersRep.GetAllQuery()
                    .Where(m => m.Name.ToLower().Contains(searchQuery))
                    .Take(pageSize)
                    .ToListAsync();

                categories = await _uow
                    .CategoriesRep.GetAllQuery()
                    .Where(c => c.Name.ToLower().Contains(searchQuery))
                    .Take(pageSize)
                    .ToListAsync();
            }

            // Fetch paginated products
            int totalProductCount = await productQuery.CountAsync();

            var products = await productQuery
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return combined results
            return new SearchResultDto
            {
                Products = products.Adapt<IEnumerable<ProductDto>>(),
                TotalProductCount = totalProductCount,
                Manufacturers = manufacturers.Adapt<IEnumerable<ManufacturerDTO>>(),
                Categories = categories.Adapt<IEnumerable<CategoryDTO>>()
            };
        }
    }
}
