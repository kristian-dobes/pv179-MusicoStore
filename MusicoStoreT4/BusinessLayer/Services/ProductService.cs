using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
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
            // egar loading related
            var query = _uow.ProductsRep.GetQuery()
                .Where(p => p.Id == productId)
                .Include(p => p.PrimaryCategory)
                .Include(p => p.SecondaryCategories)
                .Include(p => p.Manufacturer)
                .Include(p => p.Image);

            // Map to DTO
            var product = await query
                .Select(p => new ProductCompleteDTO
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    QuantityInStock = p.QuantityInStock,
                    LastModifiedById = p.LastModifiedById,
                    EditCount = p.EditCount,
                    PrimaryCategoryId = p.PrimaryCategoryId,
                    PrimaryCategoryName = p.PrimaryCategory!.Name,
                    ManufacturerId = p.ManufacturerId,
                    ManufacturerName = p.Manufacturer!.Name,
                    SecondaryCategories = p.SecondaryCategories
                        .Select(sc => new CategoryBasicDto { CategoryId = sc.Id, Name = sc.Name }),
                    NumberOfSecondaryCategories = p.SecondaryCategories != null ? p.SecondaryCategories.Count : 0,
                    ImageFilePath = p.Image != null ? p.Image.FilePath : string.Empty
                })
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<ProductShoppingDetailsDTO?> GetProductShoppingDetailsAsync(int productId)
        {
            var productQuery = _uow.ProductsRep.GetQuery()
                .Where(p => p.Id == productId);
                
            var product = await productQuery
                .Select(p => new ProductShoppingDetailsDTO
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    Price = p.Price
                })
                .FirstOrDefaultAsync();

            return product;
        }

        public async Task<IEnumerable<ProductCompleteDTO>> GetAllProductsAsync()
        {
            var productDtos = await _uow.ProductsRep.GetQuery()
                .Select(p => new ProductCompleteDTO
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    QuantityInStock = p.QuantityInStock,
                    LastModifiedById = p.LastModifiedById,
                    EditCount = p.EditCount,
                    PrimaryCategoryId = p.PrimaryCategoryId,
                    PrimaryCategoryName = p.PrimaryCategory!.Name,
                    ManufacturerId = p.ManufacturerId,
                    ManufacturerName = p.Manufacturer!.Name,
                    SecondaryCategories = p.SecondaryCategories
                        .Select(sc => new CategoryBasicDto { CategoryId = sc.Id, Name = sc.Name }),
                    NumberOfSecondaryCategories = p.SecondaryCategories != null ? p.SecondaryCategories.Count : 0,
                    ImageFilePath = p.Image != null ? p.Image.FilePath : string.Empty
                })
                .ToListAsync();

            return productDtos;
        }

        public async Task<ProductCompleteDTO> UpdateProductAsync(int productId, ProductUpdateDTO productDto)
        {
            var product = await _uow.ProductsRep.GetByIdAsync(productId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {productId} not found.");
            }

            var manufacturer = await _uow.ManufacturersRep.GetByIdAsync(productDto.ManufacturerId);
            if (manufacturer == null)
            {
                throw new KeyNotFoundException($"Manufacturer with ID {productDto.ManufacturerId} not found.");
            }

            // Validate Primary Category
            var primaryCategory = await _uow.CategoriesRep.GetByIdAsync(productDto.PrimaryCategoryId);
            if (primaryCategory == null)
                throw new KeyNotFoundException($"Category with ID {productDto.PrimaryCategoryId} not found.");

            // Validate Secondary Categories
            var secondaryCategories = await _uow.CategoriesRep.WhereAsync(c => productDto.SecondaryCategoryIds.Contains(c.Id));

            if (secondaryCategories.Count() != productDto.SecondaryCategoryIds.Count())
                throw new KeyNotFoundException("One or more secondary categories not found.");

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

            await _auditLogService.LogAsync(productId, AuditAction.Update, productDto.LastModifiedById);
            await _uow.SaveAsync();
            return product.Adapt<ProductCompleteDTO>();
        }

        public async Task<bool> CreateProductAsync(ProductCreateDTO productDto)
        {
            if (productDto.Price <= 0)
                return false;

            // VALIDATION
            var categoriesQuery = _uow.CategoriesRep.GetAllQuery()
                .Where(c => c.Id == productDto.PrimaryCategoryId || productDto.SecondaryCategoryIds.Contains(c.Id));
            var manufacturerExistsQuery = _uow.ManufacturersRep.AnyAsync(m => m.Id == productDto.ManufacturerId);
            var productNameExistsQuery = _uow.ProductsRep.AnyAsync(p => p.Name == productDto.Name);

            var categoriesTask = categoriesQuery.ToListAsync();
            var manufacturerExistsTask = manufacturerExistsQuery;
            var productNameExistsTask = productNameExistsQuery;

            // run at the same time
            await Task.WhenAll(categoriesTask, manufacturerExistsTask, productNameExistsTask);

            // get results
            var categories = await categoriesTask;
            var manufacturerExists = await manufacturerExistsTask;
            var productNameExists = await productNameExistsTask;

            // Validate Primary Category
            if (!categories.Any(c => c.Id == productDto.PrimaryCategoryId))
                return false;

            // Validate Secondary Categories
            var secondaryCategories = categories.Where(c => productDto.SecondaryCategoryIds.Contains(c.Id)).ToList();
            if (secondaryCategories.Count != productDto.SecondaryCategoryIds.Count)
                return false;

            // Validate Manufacturer
            if (!manufacturerExists)
                return false;

            // Validate Product Name
            if (productNameExists)
                return false;

            var product = productDto.MapToProduct(secondaryCategories);

            var added = await _uow.ProductsRep.AddAsync(product);
            try
            {
                await _auditLogService.LogAsync(added.Id, AuditAction.Create, productDto.LastModifiedById);
                await _uow.SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new InvalidOperationException("Error occurred while creating the product.", ex);
            }
        }

        public async Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int destinationManufacturerId, int modifiedById)
        {
            // products to reassign
            var productIds = await _uow.ProductsRep.GetProductIdsByManufacturerAsync(sourceManufacturerId);

            // reassign products
            await _uow.ProductsRep.ReassignProductsToManufacturerAsync(sourceManufacturerId, destinationManufacturerId, modifiedById);

            // list of audit logs for batch logging
            var auditLogs = productIds.Select(productId => new AuditLog
            {
                ProductId = productId,
                Action = AuditAction.Update,
                ModifiedById = modifiedById,
                Created = DateTime.UtcNow
            }).ToList();

            // bulk log
            await _auditLogService.LogAsync(auditLogs);

            await _uow.SaveAsync();
        }

        public async Task DeleteProductAsync(int productId, int deletedBy)
        {
            if(!await _uow.ProductsRep.AnyAsync(p => p.Id == productId))
                throw new KeyNotFoundException($"Product with ID {productId} not found.");

            await _auditLogService.LogAsync(productId, AuditAction.Delete, deletedBy);
            await _uow.ProductsRep.DeleteAsync(productId);
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetFilteredProductsAsync(
            FilterProductDto filterProductDto
        )
        {
            var productsQuery = _uow.ProductsRep.GetQuery();

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

        public async Task<(IEnumerable<ProductDto>, int totalCount)> GetProductsPaginatedAsync(
            int page = 1,
            int pageSize = 9
        )
        {
            var productQuery = _uow.ProductsRep.GetQuery();

            // product count (without Includes)
            int totalCount = await productQuery.CountAsync();

            // Fetch paginated and projected data
            var products = await productQuery
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    QuantityInStock = p.QuantityInStock,
                    PrimaryCategoryName = p.PrimaryCategory.Name,
                    SecondaryCategories = p.SecondaryCategories.Select(sc => sc.Name),
                    ManufacturerName = p.Manufacturer.Name,
                    DateCreated = p.Created,
                    ImageFilePath = p.Image != null ? p.Image.FilePath : null
                })
                .ToListAsync();

            return (products, totalCount);
        }

        public async Task<SearchResultDto> SearchAsync(
            string? query,
            int page = 1,
            int pageSize = 8,
            string? manufacturer = null,
            string? category = null
        )
        {
            // Base query
            var productQuery = _uow.ProductsRep.GetQuery();

            // manufacturer filter
            if (!string.IsNullOrWhiteSpace(manufacturer))
            {
                productQuery = productQuery.Where(p =>
                    p.Manufacturer != null && p.Manufacturer.Name == manufacturer
                );
            }

            // category filter
            if (!string.IsNullOrWhiteSpace(category))
            {
                productQuery = productQuery.Where(p =>
                    (p.PrimaryCategory != null && p.PrimaryCategory.Name == category)
                    || p.SecondaryCategories.Any(c => c.Name == category)
                );
            }

            // normalizing the search query
            string? searchQuery = query?.ToLower();

            // apply search filters
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                productQuery = productQuery.Where(p =>
                    EF.Functions.Like(p.Name, $"%{searchQuery}%")
                    || EF.Functions.Like(p.Description, $"%{searchQuery}%")
                    || (p.Manufacturer != null && EF.Functions.Like(p.Manufacturer.Name, $"%{searchQuery}%"))
                    || (p.PrimaryCategory != null && EF.Functions.Like(p.PrimaryCategory.Name, $"%{searchQuery}%"))
                    || p.SecondaryCategories.Any(c => EF.Functions.Like(c.Name, $"%{searchQuery}%"))
                );
            }

            // Fetch manufacturers and categories - if needed
            var manufacturerQuery = string.IsNullOrWhiteSpace(searchQuery)
                ? _uow.ManufacturersRep.GetAllQuery().Where(m => false) // Returns no results from DB
                : _uow.ManufacturersRep.GetAllQuery().Where(m => EF.Functions.Like(m.Name, $"%{searchQuery}%"));

            var categoryQuery = string.IsNullOrWhiteSpace(searchQuery)
                ? _uow.CategoriesRep.GetAllQuery().Where(c => false) // Returns no results from DB
                : _uow.CategoriesRep.GetAllQuery().Where(c => EF.Functions.Like(c.Name, $"%{searchQuery}%"));

            // product count
            int totalProductCount = await productQuery.CountAsync();

            // project directly to ProductDto
            var products = await productQuery
                .OrderBy(p => p.Name)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    QuantityInStock = p.QuantityInStock,
                    PrimaryCategoryName = p.PrimaryCategory.Name,
                    SecondaryCategories = p.SecondaryCategories.Select(c => c.Name),
                    ManufacturerName = p.Manufacturer.Name,
                    DateCreated = p.Created,
                    ImageFilePath = p.Image != null ? p.Image.FilePath : null
                })
                .ToListAsync();

            // Fetch manufacturers and categories (limit to pageSize
            var manufacturers = await manufacturerQuery.Take(pageSize).ToListAsync();
            var categories = await categoryQuery.Take(pageSize).ToListAsync();

            return new SearchResultDto
            {
                Products = products,
                TotalProductCount = totalProductCount,
                Manufacturers = manufacturers.Adapt<IEnumerable<ManufacturerDTO>>(),
                Categories = categories.Adapt<IEnumerable<CategoryDTO>>()
            };
        }
    }
}
