using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly MyDBContext _dBContext;
        private readonly ICategoryService _categoryService;

        public CategoriesController(MyDBContext dBContext, ICategoryService categoryService)
        {
            _dBContext = dBContext;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Fetch()
        {
            var categories = await _dBContext.Categories.ToListAsync();

            return Ok(categories.Select(a => new
            {
                CategoryId = a.Id,
                CategoryName = a.Name,
                CategoryDateOfCreation = a.Created,
            }));
        }

        [HttpGet("fetch/summary")]
        public async Task<IActionResult> FetchCategoriesSummary()
        {
            return Ok(await _categoryService.GetCategoriesAsync());
        }

        [HttpGet("detail")]
        public async Task<IActionResult> FetchWithProducts()
        {
            var categories = await _dBContext.Categories
                .Include(a => a.Products)
                .ToListAsync();

            return Ok(categories.Select(a => new
            {
                CategoryId = a.Id,
                CategoryName = a.Name,
                CategoryDateOfCreation = a.Created,
                Products = a.Products?.Select(product => new
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductDateOfCreation = product.Created,
                }),
            }));
        }

        [HttpGet("fetch/{categoryId}/summary")]
        public async Task<IActionResult> FetchCategorySummary(int categoryId)
        {
            var category = await _categoryService.GetCategorySummaryAsync(categoryId);

            if (category == null)
            {
                return BadRequest();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string categoryName)
        {
            var category = new Category
            {
                Name = categoryName,
            };

            await _dBContext.Categories.AddAsync(category);
            await _dBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int categoryId, string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                return BadRequest("Category name is required");
            }

            if (await _dBContext.Categories.AnyAsync(a => a.Name == categoryName))
            {
                return BadRequest("Category already exists");
            }

            var category = await _dBContext.Categories
                                           .Where(a => a.Id == categoryId)
                                           .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound("CategoryID not found");
            }

            category.Name = categoryName;
            await _dBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var category = await _dBContext.Categories
                .Include(a => a.Products)
                .Where(a => a.Id == categoryId)
                .FirstOrDefaultAsync();

            if (category != null)
            {
                _dBContext.Categories.Remove(category);
                await _dBContext.SaveChangesAsync();
            }
            else
                return NotFound();

            return Ok();
        }
    }
}
