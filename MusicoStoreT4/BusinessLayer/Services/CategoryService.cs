using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Services.Interfaces;
using BusinessLayer.DTOs;
using DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Mapper;
using DataAccessLayer.Models;

namespace BusinessLayer.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly MyDBContext _dbContext;

        public CategoryService(MyDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<CategorySummaryDto?>> GetCategoriesAsync()
        {
            var categories = await _dbContext.Categories
                .Include(c => c.Products)
                .ToListAsync();

            if (categories == null)
            {
                return new();
            }

            return categories
                    .Select(c => c.MapToCategorySummaryDTO())
                    .ToList();
        }

        public async Task<CategorySummaryDto?> GetCategorySummaryAsync(int categoryId)
        {
            var category = await _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
            {
                return null;
            }

            return category.MapToCategorySummaryDTO();
        }

        public async Task<Category> MergeCategoriesAndCreateNewAsync(string newCategoryName, int sourceCategoryId1, int sourceCategoryId2, bool save = true)
        {
            var sourceCategory1 = await _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == sourceCategoryId1);

            var sourceCategory2 = await _dbContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == sourceCategoryId2);

            if (sourceCategory1 == null || sourceCategory2 == null)
            {
                throw new Exception("One or both source categories not found.");
            }

            var newCategory = new Category
            {
                Name = newCategoryName,
                Products = new List<Product>()
            };

            _dbContext.Categories.Add(newCategory);

            if (sourceCategory1.Products != null)
            {
                foreach (var product in sourceCategory1.Products)
                {
                    product.CategoryId = newCategory.Id;
                    newCategory.Products.Add(product);
                }
            }

            if (sourceCategory2.Products != null)
            {
                foreach (var product in sourceCategory2.Products)
                {
                    product.CategoryId = newCategory.Id;
                    newCategory.Products.Add(product);
                }
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
