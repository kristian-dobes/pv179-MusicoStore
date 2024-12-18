using BusinessLayer.DTOs;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Fetch()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost("createAdmin")]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminDto adminDto)
        {
            await _userService.CreateAdminAsync(adminDto);
            return Ok();
        }

        [HttpPost("createCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            await _userService.CreateCustomerAsync(customerDto);
            return Ok();
        }

        [HttpPut("updateAdmin/{userId}")]
        public async Task<IActionResult> UpdateAdmin(int userId, [FromBody] AdminDto adminDto)
        {
            await _userService.UpdateAdminAsync(userId, adminDto);
            return NoContent();
        }

        [HttpPut("updateCustomer/{userId}")]
        public async Task<IActionResult> UpdateCustomer(
            int userId,
            [FromBody] CustomerDto customerDto
        )
        {
            await _userService.UpdateCustomerAsync(userId, customerDto);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            await _userService.DeleteUserAsync(userId);
            return Ok();
        }

        [HttpGet("summaries")]
        public async Task<IActionResult> GetUserSummaries()
        {
            var summaries = await _userService.GetUserSummariesAsync();
            return Ok(summaries);
        }

        [HttpGet("segments")]
        public async Task<IActionResult> GetCustomerSegments()
        {
            var segments = await _userService.GetCustomerSegmentsAsync();
            return Ok(segments);
        }

        [HttpGet("mostFrequentItem/{userId}")]
        public async Task<IActionResult> GetMostFrequentItem(int userId)
        {
            if (!await _userService.ValidateUserAsync(userId))
                return BadRequest($"User {userId} not found");

            var item = await _userService.GetMostFrequentItemAsync(userId);
            return item != null ? Ok(item) : NotFound($"User {userId} doesn't have any orders");
        }
    }
}
