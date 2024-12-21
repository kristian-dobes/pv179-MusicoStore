using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Category;
using BusinessLayer.DTOs.Manufacturer;
using DataAccessLayer.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICategoryService : IBaseService
    {
        Task<List<CategorySummaryDTO?>> GetCategoriesAsync();
        Task<CategorySummaryDTO?> GetCategoryByIdAsync(int id);
        Task<CategorySummaryDTO?> GetCategorySummaryAsync(int categoryId);
        Task<CategoryDTO> CreateCategoryAsync(CategoryNameDTO category);
        Task<CategoryDTO?> UpdateCategoryAsync(int categoryId, CategoryNameDTO categoryDto);
        Task DeleteCategoryAsync(int categoryId);
        Task<Category> MergeCategoriesAndCreateNewAsync(string newCategoryName, int sourceCategoryId1, int sourceCategoryId2, bool save = true);
    }
}
