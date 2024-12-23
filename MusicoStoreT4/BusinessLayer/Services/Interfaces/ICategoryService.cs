using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Category;
using DataAccessLayer.Models;
using Shared.DTOs;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICategoryService : IBaseService
    {
        Task<List<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto?> GetById(int id);
        Task AddCategory(CreateCategoryDto createCategoryDto);
        Task<List<CategorySummaryDto?>> GetCategoriesSummariesAsync();
        Task<CategorySummaryDto?> GetCategorySummaryAsync(int categoryId);
        Task<Category> MergeCategoriesAndCreateNewAsync(string newCategoryName, int sourceCategoryId1, int sourceCategoryId2, bool save = true);
        Task<List<CategoryDto>> GetCategoriesWithProductsAsync();
        Task<Category?> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
