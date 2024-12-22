using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.Facades.Interfaces;
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

        [HttpGet("detail")]
        public async Task<IActionResult> FetchWithProducts()
        {
            var manufacturers = await _manufacturerService.GetManufacturersWithProductsAsync();

            return Ok(manufacturers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateManufacturerDto createManufacturerDto)
        {
            try
            {
                await _manufacturerService.CreateManufacturerAsync(createManufacturerDto.Name);
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

        [HttpPut]
        public async Task<IActionResult> Update(UpdateManufacturerDto updateManufacturerDto)
        {
            try
            {
                var updatedManufacturer = await _manufacturerService.UpdateManufacturerAsync(updateManufacturerDto);

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
                // Log the exception if needed
                return StatusCode(500, "An unexpected error occurred");
            }
        }

        [HttpPut("MergeManufacturers")]
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
