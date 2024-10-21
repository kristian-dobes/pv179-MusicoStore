using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturerController : Controller
    {
        private readonly MyDBContext _dBContext;

        public ManufacturerController(MyDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet]
        [Route("[controller]/fetch")]
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

        [HttpDelete]
        [Route("[controller]/delete")]
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

            return Ok();
        }

        [HttpGet]
        [Route("[controller]/detail")]
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
        [Route("[controller]/create")]
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
        [Route("[controller]/update")]
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
                return BadRequest("ManufacturerID not found");
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
    }
}
