using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Create(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return BadRequest("Product name is required");
            }

            if (await _dBContext.Products.AnyAsync(a => a.Name == productName))
            {
                return BadRequest("Product already exists");
            }

            var product = new Product
            {
                Name = productName,
            };

            await _dBContext.Products.AddAsync(product);
            await _dBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(int productId, string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                return BadRequest("Product name is required");
            }

            if (await _dBContext.Products.AnyAsync(a => a.Name == productName))
            {
                return BadRequest("Product with that name already exists");
            }

            var product = await _dBContext.Products
                                          .Where(a => a.Id == productId)
                                          .FirstOrDefaultAsync();

            if (product == null)
            {
                return BadRequest("ProductID not found");
            }

            product.Name = productName;
            await _dBContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Product updated successfully",
                ProductId = product.Id,
                DateOfCreation = product.Created,
                ProductName = product.Name,
                ProductDescription = product.Description,
                ProductPrice = product.Price,
                ProductQuantityInStock = product.QuantityInStock,
            });
        }
    }
}
