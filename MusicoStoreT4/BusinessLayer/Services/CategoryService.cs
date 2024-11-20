using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CategoryService : BaseService
    {
        private readonly MyDBContext _dBContext;

        public CategoryService(MyDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Category> MergeCategoriesAndCreateNewAsync(string newCategoryName, int sourceCategoryId1, int sourceCategoryId2, bool save = true)
        {
            var sourceCategory1 = await _dBContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == sourceCategoryId1);

            var sourceCategory2 = await _dBContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == sourceCategoryId2);

            if (sourceCategory1 == null || sourceCategory2 == null)
            {
                throw new Exception("One or both source categories not found.");
            }

            var newCategory = new Category
            {
                Name = newCategoryName,
                Products = new List<Product>()
            };

            _dBContext.Categories.Add(newCategory);

            if (sourceCategory1.Products != null)
            {
                foreach (var product in sourceCategory1.Products)
                {
                    product.CategoryId = newCategory.Id;
                    newCategory.Products.Add(product);
                }
            }

            if (sourceCategory2.Products != null)
            {
                foreach (var product in sourceCategory2.Products)
                {
                    product.CategoryId = newCategory.Id;
                    newCategory.Products.Add(product);
                }
            }

            _dBContext.Categories.Remove(sourceCategory1);
            _dBContext.Categories.Remove(sourceCategory2);

            if (save)
            {
                await SaveAsync(true);
            }

            return newCategory;
        }
    }
}
