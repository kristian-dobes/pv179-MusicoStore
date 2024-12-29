using BusinessLayer.DTOs.Category;
using BusinessLayer.Services;
﻿using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Fetch()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpGet("with-products")]
        public async Task<IActionResult> FetchWithProducts()
        {
            var categories = await _categoryService.GetCategoriesWithProductsAsync();

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryUpdateDTO categoryNameDto)
        {
            await _categoryService.CreateCategory(categoryNameDto);

            return Ok();
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> Update(int categoryId, [FromBody] CategoryUpdateDTO categoryNameDto)
        {
            if (string.IsNullOrWhiteSpace(categoryNameDto.Name))
            {
                return BadRequest("Category name is required");
            }

            try
            {
                var updatedCategory = await _categoryService.UpdateCategoryAsync(categoryId, categoryNameDto);

                if (updatedCategory == null)
                {
                    return NotFound("Category not found");
                }

                return Ok(updatedCategory);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            try
            {
                var result = await _categoryService.DeleteCategoryAsync(categoryId);

                if (!result)
                {
                    return NotFound("Category not found");
                }

                return Ok("Category deleted successfully");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        [HttpPost("merge")]
        public async Task<IActionResult> MergeCategories([FromBody] MergeCategoriesDTO mergeCategoriesDTO)
        {
            if (mergeCategoriesDTO == null)
                return BadRequest("Invalid request.");

            try
            {
                var newCategory = await _categoryService.MergeCategoriesAndCreateNewAsync(
                    mergeCategoriesDTO.NewCategoryName,
                    mergeCategoriesDTO.SourceCategoryId1,
                    mergeCategoriesDTO.SourceCategoryId2,
                    1
                );

                var result = CreatedAtAction("GetCategoryById", new { id = newCategory.Id }, new
                {
                    CategoryId = newCategory.Id,
                    CategoryName = newCategory.Name,
                    CategoryCreated = newCategory.Created
                });

                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
