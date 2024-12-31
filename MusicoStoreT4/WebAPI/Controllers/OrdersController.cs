using BusinessLayer.DTOs.Order;
using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderes()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                var created = await _orderService.CreateOrderAsync(createOrderDto);

                if (!created)
                    return BadRequest("None of the products were found or order creation failed.");

                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderDto updateOrderDto)
        {
            try
            {
                var updated = await _orderService.UpdateOrderAsync(id, updateOrderDto);

                if (!updated)
                    return NotFound($"Order with ID {id} not found.");

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleted = await _orderService.DeleteOrderAsync(id);

                if (!deleted)
                    return NotFound($"Order with ID {id} not found.");

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while deleting the order: {ex.Message}");
            }
        }
    }
}
