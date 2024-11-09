using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly MyDBContext _dBContext;

        public OrderController(MyDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        // GET: api/Order/fetch
        [HttpGet("fetch")]
        public async Task<IActionResult> Fetch()
        {
            var orders = await _dBContext.Orders.ToListAsync();

            return Ok(orders.Select(a => new
            {
                OrderId = a.Id,
                OrderDateOfCreation = a.Created,
                OrderDate = a.Date,
                UserId = a.UserId
            }));
        }

        // DELETE: api/Order/delete/{orderId}
        [HttpDelete("delete/{orderId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            var order = await _dBContext.Orders.FirstOrDefaultAsync(a => a.Id == orderId);

            if (order != null)
            {
                _dBContext.Orders.Remove(order);
                await _dBContext.SaveChangesAsync();
                return Ok();
            }
            else
                return NotFound();

            return NotFound();
        }

        // GET: api/Order/detail
        [HttpGet("detail")]
        public async Task<IActionResult> FetchWithOrderItems()
        {
            var orders = await _dBContext.Orders.Include(a => a.OrderItems).ToListAsync();

            return Ok(orders.Select(a => new
            {
                OrderId = a.Id,
                OrderDateOfCreation = a.Created,
                OrderDate = a.Date,
                OrderItems = a.OrderItems?.Select(orderItem => new
                {
                    OrderItemId = orderItem.Id,
                    OrderItemQuantity = orderItem.Quantity,
                    OrderItemDateOfCreation = orderItem.Created,
                }),
            }));
        }

        // POST: api/Order/create
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrderDto)
        {
            int createdOrdersAmount = 0;

            if (createOrderDto == null || createOrderDto.Items == null || !createOrderDto.Items.Any())
            {
                return BadRequest("Order must contain at least one item.");
            }

            foreach (OrderItemDto orderItemDto in createOrderDto.Items)
            {
                var order = new Order
                {
                    UserId = createOrderDto.CustomerId,
                    Date = DateTime.UtcNow,
                    OrderItems = createOrderDto.Items.Select(itemDto => new OrderItem
                    {
                        ProductId = itemDto.ProductId,
                        Quantity = itemDto.Quantity,
                        Price = _dBContext.Products.First(p => p.Id == itemDto.ProductId).Price,
                    }).ToList()
                };

                await _dBContext.Orders.AddAsync(order);
                await _dBContext.SaveChangesAsync();
                createdOrdersAmount++;
            }

            return createdOrdersAmount == 0 ? BadRequest("None of the products were found") : Ok();
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _dBContext.Orders
                .Where(o => o.Id == id)
                .Select(o => new
                {
                    o.Id,
                    o.Created,
                    o.Date,
                    o.UserId,
                    OrderItems = o.OrderItems.Select(oi => new
                    {
                        oi.Id,
                        oi.ProductId,
                        oi.Quantity,
                        oi.Price
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        // PUT: api/Order/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDto updateOrderDto)
        {
            if (id != updateOrderDto.OrderId)
                return BadRequest("Order ID mismatch.");

            var order = await _dBContext.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return NotFound($"Order with ID {id} not found.");

            order.Date = updateOrderDto.OrderDate;
            order.OrderItems = new List<OrderItem>();

            foreach (var itemDto in updateOrderDto.OrderItems)
            {
                var product = await _dBContext.Products.FirstOrDefaultAsync(p => p.Id == itemDto.ProductId);

                if (product == null)
                    continue;

                order.OrderItems.Add(new OrderItem
                {
                    ProductId = itemDto.ProductId,
                    Quantity = itemDto.Quantity,
                    Price = product.Price
                });
            }

            try
            {
                await _dBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dBContext.Orders.Any(o => o.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }
    }
}