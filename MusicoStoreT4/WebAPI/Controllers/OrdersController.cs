using BusinessLayer.DTOs;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly MyDBContext _dBContext;

        public OrdersController(MyDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        // GET: api/Order/fetch
        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrderDto)
        {
            int createdOrdersAmount = 0;

            if (createOrderDto == null || createOrderDto.Items == null || !createOrderDto.Items.Any())
                return BadRequest("Order must contain at least one item.");

            if (!(await _dBContext.Users.AnyAsync(u => u.Id == createOrderDto.CustomerId)))
                return BadRequest($"No such customer with id {createOrderDto.CustomerId}");

            foreach (OrderItemDto orderItemDto in createOrderDto.Items)
            {
                if (!(await _dBContext.Products.AnyAsync(p => p.Id == orderItemDto.ProductId)))
                    return BadRequest($"No such product with id {orderItemDto.ProductId}. Order was not created.");
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

                _dBContext.Orders.Add(order);
                await _dBContext.SaveChangesAsync();
                createdOrdersAmount++;
            }

            return createdOrdersAmount == 0 ? BadRequest("None of the products were found") : Ok();
        }

        [HttpPut("{id}")]
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

        [HttpDelete("{orderId}")]
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
    }
}