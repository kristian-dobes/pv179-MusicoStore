﻿using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly MyDBContext _dBContext;

        public CategoryController(MyDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet("fetch")]
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

        [HttpDelete("delete")]
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

        [HttpPost("create")]
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

        [HttpPut("update")]
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
    }
}
