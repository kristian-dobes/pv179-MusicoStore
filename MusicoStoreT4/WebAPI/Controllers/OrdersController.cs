using BusinessLayer.DTOs.Order;
using BusinessLayer.DTOs.OrderItem;
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

        [HttpGet("with-items")]
        public async Task<IActionResult> FetchWithOrderItems()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                var createdOrdersAmount = await _orderService.CreateOrderAsync(createOrderDto);

                if (createdOrdersAmount == 0)
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
            if (id != updateOrderDto.OrderId)
                return BadRequest("Order ID mismatch.");

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
