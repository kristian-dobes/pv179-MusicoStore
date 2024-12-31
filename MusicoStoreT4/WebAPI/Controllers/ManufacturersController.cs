using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.Facades.Interfaces;
using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IProductService _productService;
        private readonly IManufacturerFacade _manufacturerFacade;

        public ManufacturersController(IManufacturerService manufacturerService, IProductService productService, IManufacturerFacade manufacturerFacade)
        {
            _manufacturerService = manufacturerService;
            _productService = productService;
            _manufacturerFacade = manufacturerFacade;
        }

        [HttpGet]
        public async Task<IActionResult> Fetch()
        {
            var manufacturers = await _manufacturerService.GetManufacturersAsync();

            return Ok(manufacturers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            var manufacturer = await _manufacturerService.GetById(id);

            if (manufacturer == null)
                return NotFound();

            return Ok(manufacturer);
        }

        [HttpGet("with-products")]
        public async Task<IActionResult> FetchWithProducts()
        {
            var manufacturers = await _manufacturerService.GetManufacturersWithProductsAsync();

            return Ok(manufacturers);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ManufacturerUpdateDTO createManufacturerDto)
        {
            try
            {
                await _manufacturerService.CreateManufacturerAsync(createManufacturerDto);
                return Ok("Manufacturer created successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        [HttpPut("{manufacturerId}")]
        public async Task<IActionResult> Update(int manufacturerId, [FromBody] ManufacturerUpdateDTO updateManufacturerDto)
        {
            try
            {
                var updatedManufacturer = await _manufacturerService.UpdateManufacturerAsync(manufacturerId, updateManufacturerDto);

                return Ok(updatedManufacturer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        [HttpPut("merge")]
        public async Task<IActionResult> MergeManufacturers(int sourceManufacturerId, int targetManufacturerId)
        {
            try
            {
                await _manufacturerFacade.MergeManufacturersAsync(sourceManufacturerId, targetManufacturerId, -1);
                return Ok("Manufacturers merged successfully, source manufacturer was removed.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{manufacturerId}")]
        public async Task<IActionResult> Delete(int manufacturerId)
        {
            try
            {
                var isDeleted = await _manufacturerService.DeleteManufacturerAsync(manufacturerId);

                if (!isDeleted)
                {
                    return NotFound($"Manufacturer with ID {manufacturerId} not found.");
                }

                return Ok($"Manufacturer with ID {manufacturerId} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
