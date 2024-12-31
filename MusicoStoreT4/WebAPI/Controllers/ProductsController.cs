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

        [HttpPost("filter")]
        public async Task<IActionResult> GetProducts([FromBody] FilterProductDto filterProductDTO)
        {
            var filteredProducts = await _productService.GetFilteredProductsAsync(filterProductDTO);

            return Ok(filteredProducts);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO createProductDto)
        {
            var result = await _productService.CreateProductAsync(createProductDto);
            if (result)
            {
                return Ok($"Product created successfully.");
            }   
            else
            {
                return BadRequest("Product creation failed.");
            }
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> Update(int productId, [FromBody] ProductUpdateDTO updateProductDTO)
        {
            try
            {
                await _productService.UpdateProductAsync(productId, updateProductDTO);

                return Ok(new
                {
                    Message = "Product updated successfully.",
                    ProductId = productId,
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
    }
}
