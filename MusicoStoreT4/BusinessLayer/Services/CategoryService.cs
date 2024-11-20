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

namespace BusinessLayer.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly MyDBContext _dBContext;

        public CategoryService(MyDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<List<CategorySummaryDto?>> GetCategoriesAsync()
        {
            var categories = await _dBContext.Categories
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
            var category = await _dBContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
            {
                return null;
            }

            return category.MapToCategorySummaryDTO();
        }
    }
}
