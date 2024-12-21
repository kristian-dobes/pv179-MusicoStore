using Shared.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<CategorySummaryDto>> GetCategoriesSummariesAsync();
        Task<CategorySummaryDto?> GetCategorySummaryAsync(int categoryId);
    }
}
