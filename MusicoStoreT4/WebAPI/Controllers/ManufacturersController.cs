using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturersController : Controller
    {
        private readonly MyDBContext _dBContext;
        private readonly IManufacturerService _manufacturerService;
        private readonly IProductService _productService;

        public ManufacturersController(MyDBContext dBContext, IManufacturerService manufacturerService, IProductService productService)
        {
            _dBContext = dBContext;
            _manufacturerService = manufacturerService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Fetch()
        {
            var manufacturers = await _dBContext.Manufacturers.ToListAsync();

            return Ok(manufacturers.Select(a => new
            {
                ManufacturerId = a.Id,
                ManufacturerName = a.Name,
                ManufacturerDateOfCreation = a.Created,
            }));
        }

        [HttpGet("detail")]
        public async Task<IActionResult> FetchWithProducts()
        {
            var manufacturers = await _dBContext.Manufacturers
                .Include(a => a.Products)
                .ToListAsync();

            return Ok(manufacturers.Select(a => new
            {
                ManufacturerId = a.Id,
                ManufacturerName = a.Name,
                ManufacturerDateOfCreation = a.Created,
                Products = a.Products?.Select(product => new
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    ProductPrice = product.Price,
                    ProductDateOfCreation = product.Created,
                }),
            }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(string manufacturerName)
        {
            if (string.IsNullOrWhiteSpace(manufacturerName))
            {
                return BadRequest("Manufacturer name is required");
            }

            if (await _dBContext.Manufacturers.AnyAsync(a => a.Name == manufacturerName))
            {
                return BadRequest("Manufacturer already exists");
            }

            var manufacturer = new Manufacturer
            {
                Name = manufacturerName,
            };

            await _dBContext.Manufacturers.AddAsync(manufacturer);
            await _dBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(int manufacturerId, string manufacturerName)
        {
            if (string.IsNullOrWhiteSpace(manufacturerName))
            {
                return BadRequest("Manufacturer name is required");
            }

            if (await _dBContext.Manufacturers.AnyAsync(a => a.Name == manufacturerName))
            {
                return BadRequest("Manufacturer with that name already exists");
            }

            var manufacturer = await _dBContext.Manufacturers
                .Where(a => a.Id == manufacturerId)
                .FirstOrDefaultAsync();

            if (manufacturer == null)
            {
                return NotFound("ManufacturerID not found");
            }

            manufacturer.Name = manufacturerName;
            await _dBContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Manufacturer updated successfully",
                ManufacturerId = manufacturer.Id,
                ManufacturerName = manufacturer.Name,
                DateOfCreation = manufacturer.Created,
            });
        }

        [HttpPut("MergeManufacturers")]
        public async Task<IActionResult> MergeManufacturers(int sourceManufacturerId, int targetManufacturerId)
        {
            if (sourceManufacturerId == targetManufacturerId)
            {
                return BadRequest("Source and target manufacturers cannot be the same");
            }

            if (!await _manufacturerService.ValidateManufacturerAsync(sourceManufacturerId))
            {
                return NotFound("Source manufacturer not found");
            }

            if (!await _manufacturerService.ValidateManufacturerAsync(targetManufacturerId))
            {
                return NotFound("Target manufacturer not found");
            }

            await _productService.ReassignProductsToManufacturerAsync(sourceManufacturerId, targetManufacturerId);
            await _manufacturerService.DeleteManufacturerAsync(sourceManufacturerId);

            return Ok("Manufacturers merged successfully, source manufacturer was removed");
        }

        [HttpDelete("{manufacturerId}")]
        public async Task<IActionResult> Delete(int manufacturerId)
        {
            var manufacturer = await _dBContext.Manufacturers
                .Include(a => a.Products)
                .Where(a => a.Id == manufacturerId)
                .FirstOrDefaultAsync();

            if (manufacturer != null)
            {
                _dBContext.Manufacturers.Remove(manufacturer);
                await _dBContext.SaveChangesAsync();
            }
            else
                return NotFound();

            return Ok();
        }
    }
}
