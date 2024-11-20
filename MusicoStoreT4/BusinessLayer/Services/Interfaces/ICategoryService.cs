using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICategoryService : IBaseService
    {
        public Task<List<CategorySummaryDto?>> GetCategoriesAsync();
        public Task<CategorySummaryDto?> GetCategorySummaryAsync(int categoryId);
    }
}
