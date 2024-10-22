using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly MyDBContext _dBContext;

        public UserController(MyDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> Fetch()
        {
            var users = await _dBContext.Users.ToListAsync();
            return Ok(users.Select(a => new
            {
                UserId = a.Id,
                UserName = a.Name,
                UserDateOfCreation = a.Created,
               
            }));
        }

        [HttpDelete("delete")]
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

            return Ok();
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
                UserName = a.Name,
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

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            if (userDto == null || userDto.Role != "admin" && userDto.Role != "customer")
            {
                return BadRequest("User must have valid role");
            }

            User user;

            if (userDto.Role == "admin")
            {
                user = new User
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Role = Role.Admin,
                };
            }
            else
            {
                var customerDto = userDto as CustomerDto;
                user = new Customer
                {
                    Name = customerDto.Name,
                    Email = customerDto.Email,
                    Role = Role.Customer,
                    PhoneNumber = customerDto.PhoneNumber,
                    Address = customerDto.Address,
                    City = customerDto.City,
                    State = customerDto.State,
                    PostalCode = customerDto.PostalCode,
                };
            }

            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("update/{userId}")]
        public async Task<IActionResult> Update(int userId, [FromBody] UserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is required.");
            }

            if (await _dBContext.Users.AnyAsync(a => a.Name == userDto.Name && a.Id != userId))
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

            if (user.Role == Role.Admin)
            {
                user.Name = userDto.Name;
                user.Email = userDto.Email;
            }
            else
            {
                var customerDto = userDto as CustomerDto;
                var customer = user as Customer;

                customer.Name = customerDto.Name;
                customer.Email = customerDto.Email;
                customer.PhoneNumber = customerDto.PhoneNumber;
                customer.Address = customerDto.Address;
                customer.City = customerDto.City;
                customer.State = customerDto.State;
                customer.PostalCode = customerDto.PostalCode;
            }

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

        // GET: api/User/{id}
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _dBContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    u.Id,
                    u.Name,
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
    }
}

