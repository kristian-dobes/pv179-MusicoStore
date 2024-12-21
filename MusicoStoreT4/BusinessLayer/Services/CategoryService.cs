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
        private readonly MyDBContext _dbContext;

        public CategoryService(MyDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<CategorySummaryDTO>> GetCategoriesAsync()
        {
            IQueryable<Category> categoryQuery = _dbContext.Categories;

            // Fetch data into a list
            var categories = await categoryQuery.ToListAsync();

            // Map to DTOs
            var categoryDTOs = categories.Adapt<List<CategorySummaryDTO>>();
            return categoryDTOs;
        }

        // will later use different DTO
        public async Task<CategorySummaryDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _dbContext.Categories
                .SingleOrDefaultAsync(m => m.Id == id);

            return category?.Adapt<CategorySummaryDTO>();
        }

        public async Task<CategorySummaryDTO?> GetCategorySummaryAsync(int id)
        {
            var category = await _dbContext.Categories
                .SingleOrDefaultAsync(m => m.Id == id);

            return category?.Adapt<CategorySummaryDTO>();
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryNameDTO category)
        {
            var categoryEntity = category.Adapt<Category>();

            _dbContext.Categories.Add(categoryEntity);
            await SaveAsync(true);

            return categoryEntity.Adapt<CategoryDTO>();
        }

        public async Task<CategoryDTO?> UpdateCategoryAsync(int categoryId, CategoryNameDTO categoryDto)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);
            if (category == null)
            {
                return null;
            }
            category = categoryDto.Adapt(category);
            _dbContext.Categories.Update(category);
            await SaveAsync(true);
            return category.Adapt<CategoryDTO>();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
                throw new Exception("Category not found.");

            if (category.Products != null && category.Products.Count > 0)
                throw new Exception("Category has products, cannot delete.");

            _dbContext.Categories.Remove(category);
            await SaveAsync(true);
        }

        public async Task<Category> MergeCategoriesAndCreateNewAsync(string newCategoryName, int sourceCategoryId1, int sourceCategoryId2, bool save = true)
        {
            var categories = await _dbContext.Categories
                .Where(c => c.Id == sourceCategoryId1 || c.Id == sourceCategoryId2)
                .ToListAsync();

            var sourceCategory1 = categories.FirstOrDefault(c => c.Id == sourceCategoryId1);
            var sourceCategory2 = categories.FirstOrDefault(c => c.Id == sourceCategoryId2);

            if (sourceCategory1 == null || sourceCategory2 == null)
            {
                throw new Exception("One or both source categories not found.");
            }

            var newCategory = new Category
            {
                Name = newCategoryName
            };

            _dbContext.Categories.Add(newCategory);

            var productsToMove = sourceCategory1.Products.Concat(sourceCategory2.Products).ToList();
            foreach (var product in productsToMove)
            {
                product.CategoryId = newCategory.Id;
            }

            _dbContext.Categories.Remove(sourceCategory1);
            _dbContext.Categories.Remove(sourceCategory2);

            if (save)
            {
                await SaveAsync(true);
            }

            return newCategory;
        }
    }
}
