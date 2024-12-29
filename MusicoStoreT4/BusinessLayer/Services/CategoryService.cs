using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Category;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Infrastructure.UnitOfWork;
using Mapster;

namespace BusinessLayer.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IUnitOfWork _uow;
        private readonly IAuditLogService _auditLogService;

        public CategoryService(IUnitOfWork unitOfWork, IAuditLogService auditLogService)
            : base(unitOfWork)
        {
            _uow = unitOfWork;
            _auditLogService = auditLogService;
        }

        public async Task<IEnumerable<CategorySummaryDTO>> GetCategoriesAsync()
        {
            var categoryEntities = await _uow.CategoriesRep.GetAllAsync();
            return categoryEntities.Adapt<IEnumerable<CategorySummaryDTO>>();
        }

        public async Task<CategorySummaryDTO?> GetByIdAsync(int id)
        {
            var category = await _uow.CategoriesRep.GetByIdAsync(id);

            return category.Adapt<CategorySummaryDTO>();
        }

        public async Task<Category> MergeCategoriesAndCreateNewAsync(
            string newCategoryName,
            int sourceCategoryId1,
            int sourceCategoryId2,
            int modifiedById
        )
        {
            // fetch categories with products
            var sourceCategory1 = await _uow.CategoriesRep.GetCategoryWithAllProductsAsync(sourceCategoryId1);
            var sourceCategory2 = await _uow.CategoriesRep.GetCategoryWithAllProductsAsync(sourceCategoryId2);

            if (sourceCategory1 == null || sourceCategory2 == null)
                throw new InvalidOperationException("One or both source categories not found.");

            // new category
            var newCategory = new Category { Name = newCategoryName };
            await _uow.CategoriesRep.AddAsync(newCategory);
            await _uow.SaveAsync(); // get new category ID

            // get product IDs
            var primaryProductIds = sourceCategory1.PrimaryProducts
                .Concat(sourceCategory2.PrimaryProducts)
                .Select(p => p.Id)
                .ToList();

            var secondaryProductIds = sourceCategory1.SecondaryProducts
                .Concat(sourceCategory2.SecondaryProducts)
                .Select(p => p.Id)
                .ToList();

            // bulkp roduct update
            await _uow.ProductsRep.UpdatePrimaryCategoryAsync(primaryProductIds, newCategory.Id);
            await _uow.ProductsRep.UpdateSecondaryCategoriesAsync(secondaryProductIds, newCategory.Id, [sourceCategoryId1, sourceCategoryId2]);

            // Collect audit logs
            var auditLogs = primaryProductIds
                .Select(productId => new AuditLog
                {
                    ProductId = productId,
                    Action = AuditAction.Update,
                    ModifiedById = modifiedById,
                    Created = DateTime.UtcNow
                })
                .Concat(secondaryProductIds.Select(productId => new AuditLog
                {
                    ProductId = productId,
                    Action = AuditAction.Update,
                    ModifiedById = modifiedById,
                    Created = DateTime.UtcNow
                }))
                .ToList();

            // Log updates in bulk
            await _auditLogService.LogAsync(auditLogs);

            await _uow.CategoriesRep.DeleteCategoriesAsync([sourceCategoryId1, sourceCategoryId2]);

            await _uow.SaveAsync();

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
        }

        public async Task<CategoryDTO?> UpdateCategoryAsync(
            int categoryId,
            CategoryUpdateDTO updateCategoryDto
        )
        {
            if (string.IsNullOrWhiteSpace(updateCategoryDto.Name))
                throw new ArgumentException("Category name cannot be empty");

            var existingCategory = await _uow.CategoriesRep.GetByConditionAsync(c => c.Id == categoryId || c.Name == updateCategoryDto.Name);
            
            if (existingCategory == null)
                throw new InvalidOperationException("Category not found");

            if (existingCategory.Name == updateCategoryDto.Name && existingCategory.Id != categoryId)
                throw new ArgumentException("Category with this name already exists");

            existingCategory.Name = updateCategoryDto.Name;

            await _uow.SaveAsync();

            return existingCategory.Adapt<CategoryDTO>();
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            if (await _uow.CategoriesRep.HasProductsAsync(categoryId))
                return false; // Cannot delete if the category has products

            var category = await _uow.CategoriesRep.GetByIdAsync(categoryId);
            if (category == null)
                return false; // Not found

            await _uow.CategoriesRep.DeleteAsync(category.Id);
            return true;
        }
    }
}
