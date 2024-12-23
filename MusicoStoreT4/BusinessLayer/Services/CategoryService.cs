using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Mapper;
using DataAccessLayer.Models;
using BusinessLayer.DTOs.Category;
using Mapster;

namespace BusinessLayer.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly IUnitOfWork _uow;

        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<List<CategorySummaryDTO>> GetCategoriesAsync()
        {
            return (await _uow.CategoriesRep.GetAllAsync()).Select(c => c.MapToCategoryDTO()).ToList();
        }

        public async Task<CategoryDto?> GetById(int id)
        {
            var category = await _uow.CategoriesRep.GetByIdAsync(id);

            return category?.MapToCategoryDTO();
        }

        public async Task<List<CategorySummaryDto>> GetCategoriesSummariesAsync()
        {
            return await _uow.CategoriesRep.GetCategoriesSummariesAsync();
        }

        public async Task<CategorySummaryDto?> GetCategorySummaryAsync(int categoryId)
        {
            return await _uow.CategoriesRep.GetCategorySummaryAsync(categoryId);
        }

        public async Task<Category> MergeCategoriesAndCreateNewAsync(string newCategoryName, int sourceCategoryId1,
                                                                     int sourceCategoryId2, bool save = true)
        {
            var sourceCategory1 = (await _uow.CategoriesRep.WhereAsync(c => c.Id == sourceCategoryId1)).FirstOrDefault();
            var sourceCategory2 = (await _uow.CategoriesRep.WhereAsync(c => c.Id == sourceCategoryId2)).FirstOrDefault();

            if (sourceCategory1 == null || sourceCategory2 == null)
            {
                throw new InvalidOperationException("One or both source categories not found.");
            }

            var newCategory = new Category { Name = newCategoryName };
            await _uow.CategoriesRep.AddAsync(newCategory);

            var productsToMove = sourceCategory1.Products?.Concat(sourceCategory2.Products ?? Enumerable.Empty<Product>())
                                 ?? Enumerable.Empty<Product>();

            foreach (var product in productsToMove)
            {
                product.CategoryId = newCategory.Id;
            }

            await _uow.CategoriesRep.DeleteAsync(sourceCategory1.Id);
            await _uow.CategoriesRep.DeleteAsync(sourceCategory2.Id);

            if (save)
            {
                await _uow.SaveAsync();
            }

            return newCategory;
        }

        public async Task<List<CategoryDto>> GetCategoriesWithProductsAsync()
        {
            return (await _uow.CategoriesRep.GetCategoriesWithProductsAsync()).Select(c => c.MapToCategoryDTO()).ToList();
        }

        public async Task AddCategory(CreateCategoryDto createCategoryDto)
        {
            await _uow.CategoriesRep.AddAsync(createCategoryDto.MapToCategory());
        }

        public async Task<Category?> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            if (await _uow.CategoriesRep.AnyAsync(c => c.Name == updateCategoryDto.Name))
            {
                throw new ArgumentException("Category with this name already exists");
            }

            var category = await _uow.CategoriesRep.GetByIdAsync(updateCategoryDto.Id);

            if (category == null)
            {
                return null;
            }

            category.Name = updateCategoryDto.Name;

            await _uow.SaveAsync();

            return category;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = (await _uow.CategoriesRep.GetCategoriesWithProductsAsync()).FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                return false; // Not found
            }

            if (category.Products.Any())
            {
                throw new InvalidOperationException("Cannot delete category as it contains products");
            }

            await _uow.CategoriesRep.DeleteAsync(category.Id);
            return true;
        }
    }
}
