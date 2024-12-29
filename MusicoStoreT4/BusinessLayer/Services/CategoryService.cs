using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Category;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Infrastructure.UnitOfWork;
using Mapster;

namespace BusinessLayer.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _uow = unitOfWork;
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
            bool save = true
        )
        {
            var sourceCategory1 = (
                await _uow.CategoriesRep.WhereAsync(c => c.Id == sourceCategoryId1)
            ).FirstOrDefault();
            var sourceCategory2 = (
                await _uow.CategoriesRep.WhereAsync(c => c.Id == sourceCategoryId2)
            ).FirstOrDefault();

            if (sourceCategory1 == null || sourceCategory2 == null)
            {
                throw new InvalidOperationException("One or both source categories not found.");
            }

            var newCategory = new Category { Name = newCategoryName };
            await _uow.CategoriesRep.AddAsync(newCategory);

            var primaryProductsToMove =
                sourceCategory1.PrimaryProducts?.Concat(
                    sourceCategory2.PrimaryProducts ?? Enumerable.Empty<Product>()
                ) ?? Enumerable.Empty<Product>();

            var secondaryProductsToMove =
                sourceCategory1.SecondaryProducts?.Concat(
                    sourceCategory2.SecondaryProducts ?? Enumerable.Empty<Product>()
                ) ?? Enumerable.Empty<Product>();

            foreach (var product in primaryProductsToMove)
            {
                product.PrimaryCategoryId = newCategory.Id;
            }

            foreach (var product in secondaryProductsToMove)
            {
                product.SecondaryCategories?.Remove(sourceCategory1);
                product.SecondaryCategories?.Remove(sourceCategory2);
                product.SecondaryCategories?.Add(newCategory);
            }

            await _uow.CategoriesRep.DeleteAsync(sourceCategory1.Id);
            await _uow.CategoriesRep.DeleteAsync(sourceCategory2.Id);

            if (save)
            {
                await _uow.SaveAsync();
            }

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
            if (await _uow.CategoriesRep.AnyAsync(c => c.Name == updateCategoryDto.Name))
            {
                throw new ArgumentException("Category with this name already exists");
            }

            var category = await _uow.CategoriesRep.GetByIdAsync(categoryId);

            if (category == null)
            {
                throw new InvalidOperationException("Category not found");
            }

            category.Name = updateCategoryDto.Name;

            await _uow.SaveAsync();

            return category.Adapt<CategoryDTO>();
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = (
                await _uow.CategoriesRep.GetCategoriesWithProductsAsync()
            ).FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                return false; // Not found
            }

            if (category.PrimaryProducts != null && category.PrimaryProducts.Any())
            {
                return false;
            }

            if (category.SecondaryProducts != null && category.SecondaryProducts.Any())
            {
                return false;
            }

            await _uow.CategoriesRep.DeleteAsync(category.Id);
            return true;
        }
    }
}
