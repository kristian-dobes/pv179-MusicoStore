using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs.Product;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly MyDBContext _dBContext;

        public ProductController(MyDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> Fetch()
        {
            var products = await _dBContext.Products.ToListAsync();

            return Ok(products.Select(a => new
            {
                ProductId = a.Id,
                ProductDateOfCreation = a.Created,
                ProductName = a.Name,
                ProductDescription = a.Description,
                ProductPrice = a.Price,
                ProductQuantityInStock = a.QuantityInStock,
            }));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int productId)
        {
            var product = await _dBContext.Products
                                          .Where(a => a.Id == productId)
                                          .FirstOrDefaultAsync();

            if (product != null)
            {
                _dBContext.Products.Remove(product);
                await _dBContext.SaveChangesAsync();
            }
            else
                return NotFound();

            return Ok();
        }

        [HttpGet("detail")]
        public async Task<IActionResult> FetchWithOrderItems()
        {
            var products = await _dBContext.Products
                                           .Include(a => a.OrderItems)
                                           .ToListAsync();

            return Ok(products.Select(a => new
            {
                ProductId = a.Id,
                ProductName = a.Name,
                ProductDateOfCreation = a.Created,
                ProductDescription = a.Description,
                ProductPrice = a.Price,
                ProductQuantityInStock = a.QuantityInStock,
                OrderItems = a.OrderItems?.Select(orderItem => new
                {
                    OrderItemId = orderItem.Id,
                    OrderItemQuantity = orderItem.Quantity,
                    OrderItemDateOfCreation = orderItem.Created,
                }),
            }));
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateProductDTO createProductDTO)
        {
            if (string.IsNullOrEmpty(createProductDTO.Name))
                return BadRequest("Product name is required");

            if (string.IsNullOrEmpty(createProductDTO.Description))
                return BadRequest("Product description is required");

            if (createProductDTO.Price <= 0)
                return BadRequest("Price must be valid");

            if (await _dBContext.Products.AnyAsync(a => a.Name == createProductDTO.Name))
                return BadRequest($"Product with name '{createProductDTO.Name}' already exists");

            if (!(await _dBContext.Categories.AnyAsync(c => c.Id == createProductDTO.CategoryId)))
                return BadRequest($"Category with id {createProductDTO.CategoryId} not found");

            if (!(await _dBContext.Manufacturers.AnyAsync(m => m.Id == createProductDTO.ManufacturerId)))
                return BadRequest($"Manufacturer with id {createProductDTO.ManufacturerId} not found");

            var product = new Product
            {
                Name = createProductDTO.Name,
                Description = createProductDTO.Description,
                Price = createProductDTO.Price,
                CategoryId = createProductDTO.CategoryId,
                ManufacturerId = createProductDTO.ManufacturerId
            };

            await _dBContext.Products.AddAsync(product);
            await _dBContext.SaveChangesAsync();

            return Ok($"Product {createProductDTO.Name} created successfully.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProductDTO updateProductDTO)
        {
            var product = await _dBContext.Products
                                          .Where(a => a.Id == updateProductDTO.Id)
                                          .FirstOrDefaultAsync();

            if (product == null)
                return BadRequest("ProductID not found");

            if (updateProductDTO.Price <= 0)
                return BadRequest("Price must be valid");

            if (await _dBContext.Products.AnyAsync(a => a.Name == updateProductDTO.Name && a.Id != updateProductDTO.Id))
                return BadRequest($"Product with name '{updateProductDTO.Name}' already exists");

            if (updateProductDTO.CategoryId != null && !(await _dBContext.Categories.AnyAsync(c => c.Id == updateProductDTO.CategoryId)))
                return BadRequest($"Category with id {updateProductDTO.CategoryId} not found");

            if (updateProductDTO.ManufacturerId != null && !(await _dBContext.Manufacturers.AnyAsync(m => m.Id == updateProductDTO.ManufacturerId)))
                return BadRequest($"Manufacturer with id {updateProductDTO.ManufacturerId} not found");

            if (updateProductDTO.Name != null)
                product.Name = updateProductDTO.Name;
            
            if (updateProductDTO.Description != null)
                product.Description = updateProductDTO.Description;

            if (updateProductDTO.Price.HasValue)
                product.Price = updateProductDTO.Price.Value;

            if (updateProductDTO.CategoryId.HasValue)
                product.CategoryId = updateProductDTO.CategoryId.Value;

            if (updateProductDTO.ManufacturerId.HasValue)
                product.ManufacturerId = updateProductDTO.ManufacturerId.Value;

            await _dBContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Product updated successfully.",
                ProductId = product.Id,
                DateOfCreation = product.Created,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductPrice = product.Price,
                ProductQuantityInStock = product.QuantityInStock,
            });
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetProducts(
            string? name,
            string? description,
            decimal? price,
            int? categoryId,
            int? manufacturerId)
        {

            // Build query
            var productsQuery = _dBContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                productsQuery = productsQuery.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }

            if (!string.IsNullOrEmpty(description))
            {
                productsQuery = productsQuery.Where(p => p.Description.ToLower().Contains(description.ToLower()));
            }

            if (price.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.Price == price);
            }

            if (categoryId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.CategoryId == categoryId);
            }

            if (manufacturerId.HasValue)
            {
                productsQuery = productsQuery.Where(p => p.ManufacturerId == manufacturerId);
            }

            var products = await productsQuery
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Select(p => new ProductDto      // Project the filtered products into ProductDto
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    ManufacturerName = p.Manufacturer.Name
                })
                .ToListAsync(); // Execute the query

            return Ok(products);
        }
    }
}
