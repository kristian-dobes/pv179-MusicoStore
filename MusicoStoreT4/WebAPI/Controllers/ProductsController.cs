using BusinessLayer.DTOs.Product;
using BusinessLayer.Services;
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
        private readonly MyDBContext _dBContext;
        private ProductService _productService;

        public ProductsController(MyDBContext dBContext, ProductService productService)
        {
            _dBContext = dBContext;
            _productService = productService;
        }

        [HttpGet]
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
                ProductManufacturer = a.ManufacturerId,
                ProductCategory = a.CategoryId
            }));
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
                ProductManufacturer = a.ManufacturerId,
                ProductCategory = a.CategoryId,
                OrderItems = a.OrderItems?.Select(orderItem => new
                {
                    OrderItemId = orderItem.Id,
                    OrderItemQuantity = orderItem.Quantity,
                    OrderItemDateOfCreation = orderItem.Created,
                }),
                Category = a.Category == null ? null : new
                {
                    CategoryId = a.Category.Id,
                    CategoryName = a.Category.Name,
                    CategoryDateOfCreation = a.Category.Created,
                },
                Manufacturer = a.Manufacturer == null ? null : new
                {
                    ManufacturerId = a.Manufacturer.Id,
                    ManufacturerName = a.Manufacturer.Name,
                    ManufacturerDateOfCreation = a.Manufacturer.Created,
                }
            }));
        }

        [HttpPost("filter")]
        public async Task<IActionResult> GetProducts([FromBody] FilterProductDTO filterProductDTO)
        {
            var productsQuery = _dBContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(filterProductDTO.Name))
                productsQuery = productsQuery.Where(p => p.Name.ToLower().Contains(filterProductDTO.Name.ToLower()));

            if (!string.IsNullOrEmpty(filterProductDTO.Description))
                productsQuery = productsQuery.Where(p => p.Description.ToLower().Contains(filterProductDTO.Description.ToLower()));

            decimal minPrice = filterProductDTO.MinPrice ?? decimal.MinValue;
            decimal maxPrice = filterProductDTO.MaxPrice ?? decimal.MaxValue;

            productsQuery = productsQuery.Where(p => p.Price >= minPrice && minPrice <= maxPrice);

            if (filterProductDTO.CategoryId.HasValue)
                productsQuery = productsQuery.Where(p => p.CategoryId == filterProductDTO.CategoryId);

            if (filterProductDTO.ManufacturerId.HasValue)
                productsQuery = productsQuery.Where(p => p.ManufacturerId == filterProductDTO.ManufacturerId);

            var products = await productsQuery
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    ManufacturerName = p.Manufacturer.Name
                })
                .ToListAsync();

            return Ok(products);
        }

        [HttpPost]
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

        [HttpPut]
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

        [HttpDelete("{productId}")]
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

        [HttpGet("top-selling-products")]
        public async Task<IActionResult> TopSellingProducts(DateTime startDate, DateTime endDate)
        {
            var result = await _productService.GetTopSellingProductsByCategoryAsync(startDate, endDate);

            return Ok(result);
        }
    }
}
