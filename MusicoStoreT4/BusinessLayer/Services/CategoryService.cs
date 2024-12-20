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

        public async Task<List<CategorySummaryDto>> GetCategoriesAsync()
        {
            var categories = await _dbContext.Categories
                .Select(c => new CategorySummaryDto
                {
                    CategoryId = c.Id,
                    Name = c.Name,
                    ProductCount = c.Products.Count()
                })
                .ToListAsync();

            return categories;
        }

        public async Task<CategorySummaryDto?> GetCategorySummaryAsync(int categoryId)
        {
            var categorySummary = await _dbContext.Categories
                .Where(c => c.Id == categoryId)
                .Select(c => new CategorySummaryDto
                {
                    CategoryId = c.Id,
                    Name = c.Name,
                    ProductCount = c.Products.Count()
                })
                .FirstOrDefaultAsync();

            return categorySummary;
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
