using BusinessLayer.DTOs.Category;
using DataAccessLayer.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICategoryService : IBaseService
    {
        Task<IEnumerable<CategorySummaryDTO>> GetCategoriesAsync();
        Task<CategorySummaryDTO?> GetByIdAsync(int id);
        Task<CategoryProductsDTO?> GetCategoryWithProductsAsync(int categoryId);
        Task<Category> MergeCategoriesAndCreateNewAsync(string newCategoryName, int sourceCategoryId1, int sourceCategoryId2, int modifiedById);
        Task<IEnumerable<CategoryDTO>> GetCategoriesWithProductsAsync();
        Task CreateCategory(CategoryUpdateDTO categoryDto);
        Task<CategoryDTO?> UpdateCategoryAsync(int categoryId, CategoryUpdateDTO categoryDto);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
