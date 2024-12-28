using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithProductsAsync();
        Task<List<Category>> GetCategoriesWithPrimaryProductsAsync();
        Task<List<Category>> GetCategoriesWithSecondaryProductsAsync();
        IQueryable<Category> GetAllQuery();
    }
}
