﻿using BusinessLayer.Cache;
using BusinessLayer.Cache.Interfaces;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Infrastructure.UnitOfWork;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAuditLogService _auditLogService;
        private readonly IMemoryCacheWrapper _cacheWrapper;
        private const string CATEGORY_LIST_CACHE_KEY = "Categories_List";
        private static readonly CacheOptions CacheOptions =
            new(
                AbsoluteExpiration: TimeSpan.FromHours(12),
                SlidingExpiration: TimeSpan.FromMinutes(30)
            );

        public CategoryService(
            IUnitOfWork unitOfWork,
            IAuditLogService auditLogService,
            IMemoryCacheWrapper cacheWrapper
        )
            : base(unitOfWork)
        {
            _uow = unitOfWork;
            _auditLogService = auditLogService;
            _cacheWrapper = cacheWrapper;
        }

        public async Task<IEnumerable<CategorySummaryDTO>> GetCategoriesAsync()
        {
            return await _cacheWrapper.GetOrCreateAsync(
                CATEGORY_LIST_CACHE_KEY,
                async () => await _uow.CategoriesRep.GetQueryProducts()
                .Select(c => new CategorySummaryDTO
                {
                    CategoryId = c.Id,
                    Name = c.Name,
                    PrimaryProductCount = c.PrimaryProducts != null ? c.PrimaryProducts.Count : 0,
                    SecondaryProductCount = c.SecondaryProducts != null ? c.SecondaryProducts.Count : 0
                })
                .ToListAsync(),
                CacheOptions
            );
        }

        public async Task<CategorySummaryDTO?> GetByIdAsync(int id)
        {
            var category = await _uow.CategoriesRep.GetQueryById(id)
                .Select(c => new CategorySummaryDTO
                {
                    CategoryId = c.Id,
                    Name = c.Name,
                    PrimaryProductCount = c.PrimaryProducts != null ? c.PrimaryProducts.Count : 0,
                    SecondaryProductCount = c.SecondaryProducts != null ? c.SecondaryProducts.Count : 0
                })
                .FirstOrDefaultAsync();

            return category;
        }

        public async Task<CategoryProductsDTO?> GetCategoryWithProductsAsync(int categoryId)
        {
            return await _uow.CategoriesRep.GetQueryById(categoryId)
                .Select(c => new CategoryProductsDTO
                {
                    CategoryId = c.Id,
                    Name = c.Name,
                    PrimaryProducts = c.PrimaryProducts.Select(p => new ProductSummaryDTO
                    {
                        ProductId = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        QuantityInStock = p.QuantityInStock
                    }).ToList(),
                    PrimaryProductCount = c.PrimaryProducts != null ? c.PrimaryProducts.Count : 0,
                    SecondaryProducts = c.SecondaryProducts.Select(p => new ProductSummaryDTO
                    {
                        ProductId = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        QuantityInStock = p.QuantityInStock
                    }).ToList(),
                    SecondaryProductCount = c.SecondaryProducts != null ? c.SecondaryProducts.Count : 0
                })
                .FirstOrDefaultAsync();
        }


        public async Task<Category> MergeCategoriesAndCreateNewAsync(
            string newCategoryName,
            int sourceCategoryId1,
            int sourceCategoryId2,
            int modifiedById
        )
        {
            // fetch categories with products
            var sourceCategory1 = await _uow.CategoriesRep.GetCategoryWithAllProductsAsync(
                sourceCategoryId1
            );
            var sourceCategory2 = await _uow.CategoriesRep.GetCategoryWithAllProductsAsync(
                sourceCategoryId2
            );

            if (sourceCategory1 == null || sourceCategory2 == null)
                throw new InvalidOperationException("One or both source categories not found.");

            // new category
            var newCategory = new Category { Name = newCategoryName };
            await _uow.CategoriesRep.AddAsync(newCategory);
            await _uow.SaveAsync(); // get new category ID

            // get product IDs
            var primaryProductIds = sourceCategory1
                .PrimaryProducts.Concat(sourceCategory2.PrimaryProducts)
                .Select(p => p.Id)
                .ToList();

            var secondaryProductIds = sourceCategory1
                .SecondaryProducts.Concat(sourceCategory2.SecondaryProducts)
                .Select(p => p.Id)
                .ToList();

            // bulkp roduct update
            await _uow.ProductsRep.UpdatePrimaryCategoryAsync(primaryProductIds, newCategory.Id);
            await _uow.ProductsRep.UpdateSecondaryCategoriesAsync(
                secondaryProductIds,
                newCategory.Id,
                [sourceCategoryId1, sourceCategoryId2]
            );

            // Collect audit logs
            var auditLogs = primaryProductIds
                .Select(productId => new AuditLog
                {
                    ProductId = productId,
                    Action = AuditAction.Update,
                    ModifiedById = modifiedById,
                    Created = DateTime.UtcNow
                })
                .Concat(
                    secondaryProductIds.Select(productId => new AuditLog
                    {
                        ProductId = productId,
                        Action = AuditAction.Update,
                        ModifiedById = modifiedById,
                        Created = DateTime.UtcNow
                    })
                )
                .ToList();

            // Log updates in bulk
            if (auditLogs.Count != 0)
            {
                await _auditLogService.LogAsync(auditLogs);
            }

            await _uow.CategoriesRep.DeleteCategoriesAsync([sourceCategoryId1, sourceCategoryId2]);

            await _uow.SaveAsync();

            _cacheWrapper.Invalidate(CATEGORY_LIST_CACHE_KEY);

            return newCategory;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesWithProductsAsync()
        {
            var categories = await _uow.CategoriesRep.GetCategoriesWithProductsAsync();

            return categories.Adapt<IEnumerable<CategoryDTO>>();
        }

        public async Task CreateCategory(CategoryUpdateDTO categoryDto)
        {
            var category = await _uow.CategoriesRep.AddAsync(categoryDto.Adapt<Category>());
            _cacheWrapper.Invalidate(CATEGORY_LIST_CACHE_KEY);
        }

        public async Task<CategoryDTO?> UpdateCategoryAsync(
            int categoryId,
            CategoryUpdateDTO updateCategoryDto
        )
        {
            if (string.IsNullOrWhiteSpace(updateCategoryDto.Name))
                throw new ArgumentException("Category name cannot be empty");

            var existingCategory = await _uow.CategoriesRep.GetByIdAsync(categoryId);
            if (existingCategory == null)
                throw new InvalidOperationException("Category not found");

            var duplicateCategory = await _uow.CategoriesRep.GetByConditionAsync(c =>
                c.Name == updateCategoryDto.Name && c.Id != categoryId
            );
            if (duplicateCategory != null)
                throw new ArgumentException("Category with this name already exists");

            existingCategory.Name = updateCategoryDto.Name;

            await _uow.SaveAsync();
            _cacheWrapper.Invalidate(CATEGORY_LIST_CACHE_KEY);

            return existingCategory.Adapt<CategoryDTO>();
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            if (await _uow.CategoriesRep.HasProductsAsync(categoryId))
                return false; // Cannot delete if the category has products

            var deleted = await _uow.CategoriesRep.DeleteAsync(categoryId);
            if (deleted)
            {
                _cacheWrapper.Invalidate(CATEGORY_LIST_CACHE_KEY);
            }
            return deleted;
        }
    }
}
