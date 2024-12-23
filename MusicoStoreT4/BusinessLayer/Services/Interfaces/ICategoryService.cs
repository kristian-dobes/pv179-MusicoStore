using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.Category;
using DataAccessLayer.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICategoryService : IBaseService
    {
        Task<IEnumerable<CategorySummaryDTO>> GetCategoriesAsync();
        Task<CategorySummaryDTO?> GetByIdAsync(int id);
        Task<Category> MergeCategoriesAndCreateNewAsync(string newCategoryName, int sourceCategoryId1, int sourceCategoryId2, bool save = true);
        Task<IEnumerable<CategoryDto>> GetCategoriesWithProductsAsync();
        Task CreateCategory(CategoryUpdateDTO categoryDto);
        Task<CategoryDto?> UpdateCategoryAsync(int categoryId, CategoryUpdateDTO categoryDto);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
