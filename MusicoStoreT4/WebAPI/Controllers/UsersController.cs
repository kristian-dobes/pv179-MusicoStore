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
        private readonly MyDBContext _dBContext;
        private readonly IUserService _userService;

        public UsersController(MyDBContext dBContext, IUserService userService)
        {
            _dBContext = dBContext;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Fetch()
        {
            var users = await _dBContext.Users.ToListAsync();
            return Ok(users.Select(u => (object)(u.Role == Role.Admin ?
                new
                {
                    UserId = u.Id,
                    UserName = u.Username,
                    UserDateOfCreation = u.Created
                }
                :
                new
                {
                    UserId = u.Id,
                    UserName = u.Username,
                    UserDateOfCreation = u.Created,
                    CustomerDetails = new
                    {
                        PhoneNumber = (u as Customer).PhoneNumber,
                        Address = (u as Customer).Address,
                        City = (u as Customer).City,
                        State = (u as Customer).State,
                        PostalCode = (u as Customer).PostalCode
                    }
                })));
        }

        [HttpGet("detail")]
        public async Task<IActionResult> FetchWithOrders()
        {
            var users = await _dBContext.Users
                .Include(a => a.Orders)
                .ToListAsync();

            return Ok(users.Select(a => new
            {
                UserId = a.Id,
                UserName = a.Username,
                UserDateOfCreation = a.Created,
                UserRole = a.Role,
                Orders = a.Orders?.Select(order => new
                {
                    OrderId = order.Id,
                    OrderDate = order.Date,
                    OrderDateOfCreation = order.Created,
                }),
            }));
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _dBContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    u.Id,
                    u.Username,
                    u.Role,
                    CustomerDetails = u.Role == Role.Customer ? new
                    {
                        PhoneNumber = (u as Customer).PhoneNumber,
                        Address = (u as Customer).Address,
                        City = (u as Customer).City,
                        State = (u as Customer).State,
                        PostalCode = (u as Customer).PostalCode,
                        Orders = (u as Customer).Orders.Select(o => new
                        {
                            o.Id,
                            o.Date,
                            o.Created,
                            OrderItems = o.OrderItems.Select(oi => new
                            {
                                oi.Id,
                                oi.ProductId,
                                oi.Quantity,
                                oi.Price
                            }).ToList()
                        }).ToList()
                    } : null
                })
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("createAdmin")]
        public async Task<IActionResult> CreateAdmin([FromBody] AdminDto adminDto)
        {
            if (adminDto == null)
            {
                return BadRequest("No valid data");
            }

            User user = new User
            {
                Username = adminDto.Name,
                Email = adminDto.Email,
                Role = Role.Admin,
            };

            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("createCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest("No valid data");
            }

            User user = new Customer
            {
                Username = customerDto.Name,
                Email = customerDto.Email,
                Role = Role.Customer,
                PhoneNumber = customerDto.PhoneNumber,
                Address = customerDto.Address,
                City = customerDto.City,
                State = customerDto.State,
                PostalCode = customerDto.PostalCode,
            };

            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("updateAdmin/{userId}")]
        public async Task<IActionResult> UpdateAdmin(int userId, [FromBody] AdminDto adminDto)
        {
            if (adminDto == null)
            {
                return BadRequest("User data is required.");
            }

            if (await _dBContext.Users.AnyAsync(a => a.Username == adminDto.Name && a.Id != userId))
            {
                return BadRequest("User with that name already exists.");
            }

            var user = await _dBContext.Users
                .Where(a => a.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return BadRequest("User not found");
            }

            if (user.Role != Role.Admin)
            {
                return BadRequest("User with given ID is not Admin");
            }

            user.Username = adminDto.Name;
            user.Email = adminDto.Email;

            try
            {
                await _dBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dBContext.Users.Any(u => u.Id == userId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpPut("updateCustomer/{userId}")]
        public async Task<IActionResult> UpdateCustomer(int userId, [FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest("User data is required.");
            }

            if (await _dBContext.Users.AnyAsync(a => a.Username == customerDto.Name && a.Id != userId))
            {
                return BadRequest("User with that name already exists.");
            }

            var customer = await _dBContext.Users
                .Where(a => a.Id == userId)
                .FirstOrDefaultAsync() as Customer;

            if (customer == null)
            {
                return BadRequest("User not found");
            }

            if (customer.Role != Role.Customer)
            {
                return BadRequest("User with given ID is not Customer");
            }

            customer.Username = customerDto.Name;
            customer.Email = customerDto.Email;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.Address = customerDto.Address;
            customer.City = customerDto.City;
            customer.State = customerDto.State;
            customer.PostalCode = customerDto.PostalCode;

            try
            {
                await _dBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dBContext.Users.Any(u => u.Id == userId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var user = await _dBContext.Users
                .Include(a => a.Orders)
                .Where(a => a.Id == userId)
                .FirstOrDefaultAsync();

            if (user != null)
            {
                _dBContext.Users.Remove(user);
                await _dBContext.SaveChangesAsync();
            }
            else
                return NotFound();

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
            {
                return BadRequest();
            }
            var item = await _userService.GetMostFrequentBoughtItemAsync(userId);
            return item != null ? Ok(item) : NotFound();
        }
    }
}

