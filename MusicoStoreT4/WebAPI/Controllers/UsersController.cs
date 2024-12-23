using BusinessLayer.DTOs.User.Admin;
using BusinessLayer.DTOs.User.Customer;
using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("with-orders")]
        public async Task<IActionResult> FetchWithOrders()
        {
            var users = await _userService.GetAllUserDetailsAsync();
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

        [HttpPost("admin")]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminDto adminDto)
        {
            await _userService.CreateAdminAsync(adminDto);
            return Ok();
        }

        [HttpPost("customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            await _userService.CreateCustomerAsync(customerDto);
            return Ok();
        }

        [HttpPut("admin/{userId}")]
        public async Task<IActionResult> UpdateAdmin(int userId, [FromBody] AdminDto adminDto)
        {
            await _userService.UpdateAdminAsync(userId, adminDto);
            return NoContent();
        }

        [HttpPut("customer/{userId}")]
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
            var summaries = await _userService.GetAllUserSummariesAsync();
            return Ok(summaries);
        }

        [HttpGet("segments")]
        public async Task<IActionResult> GetCustomerSegments()
        {
            var segments = await _userService.GetCustomerSegmentsAsync();
            return Ok(segments);
        }

        [HttpGet("frequent-item/{userId}")]
        public async Task<IActionResult> GetMostFrequentItem(int userId)
        {
            if (!await _userService.ValidateUserAsync(userId))
                return BadRequest($"User {userId} not found");

            var item = await _userService.GetMostFrequentBoughtItemAsync(userId);
            return item != null ? Ok(item) : NotFound($"User {userId} doesn't have any orders");
        }
    }
}
