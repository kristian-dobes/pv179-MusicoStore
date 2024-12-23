using BusinessLayer.DTOs.Product;
using BusinessLayer.Mapper;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Fetch()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("detail")]
        public async Task<IActionResult> FetchWithOrderItems()
        {
            var products = await _productService.GetAllProductsWithDetailsAsync();

            return Ok(products);
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetProducts([FromBody] FilterProductDto filterProductDTO)
        {
            var filteredProducts = await _productService.GetFilteredProductsAsync(filterProductDTO);

            return Ok(filteredProducts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto createProductDto, int createdById)
        {
            try
            {
                var createdProduct = await _productService.CreateProductAsync(createProductDto, createdById);
                
                return Ok($"Product {createdProduct.Name} created successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDTO, int updatedById)
        {
            try
            {
                await _productService.UpdateProductAsync(updateProductDTO, updatedById);

                return Ok(new
                {
                    Message = "Product updated successfully.",
                    ProductId = updateProductDTO.Id,
                });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId, int deletedById)
        {
            try
            {
                await _productService.DeleteProductAsync(productId, deletedById);

                return Ok(new { Message = "Product deleted successfully." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("top-selling-products")]
        public async Task<IActionResult> TopSellingProducts(DateTime startDate, DateTime endDate)
        {
            var result = await _productService.GetTopSellingProductsByCategoryAsync(
                startDate,
                endDate
            );

            return Ok(result);
        }
    }
}
