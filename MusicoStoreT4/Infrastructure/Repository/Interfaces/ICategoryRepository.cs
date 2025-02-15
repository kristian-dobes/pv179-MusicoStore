﻿using System.Linq.Expressions;
using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithProductsAsync();
        Task<List<Category>> GetCategoriesWithPrimaryProductsAsync();
        Task<List<Category>> GetCategoriesWithSecondaryProductsAsync();
        Task<Category?> GetCategoryWithAllProductsAsync(int categoryId);
        IQueryable<Category> GetAllQuery();
        IQueryable<Category> GetQueryProducts();
        IQueryable<Category> GetQueryById(int id);
        Task<bool> HasProductsAsync(int categoryId);
        Task<Category?> GetByConditionAsync(Expression<Func<Category, bool>> predicate);
        Task DeleteCategoriesAsync(IEnumerable<int> categoryIds);
        Task<bool> IsNameUniqueAsync(string name, int? excludeCategoryId = null);
    }
}
