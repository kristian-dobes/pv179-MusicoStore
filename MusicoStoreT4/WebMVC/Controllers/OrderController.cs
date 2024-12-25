using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public OrderController(IOrderService orderService, UserManager<LocalIdentityUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> UserOrders()
        {
            var userId = await GetCurrentUserId();
            // var userId = 3;

            var orders = await _orderService.GetOrdersWithProductsAsync(userId);

            var ordersVMs = orders.Select(o => new OrderViewModel
            {
                Id = o.Id,
                OrderDate = o.Date,
                OrderStatusStr = o.OrderStatus.ToString(),
                OrderItems = o.OrderItems.Select(oi => new OrderItemViewModel
                {
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity,
                    Price = oi.Price,
                    Product = new ProductViewModel()
                    {
                        ProductId = oi.Product.Id,
                        ProductName = oi.Product.Name,
                        Description = oi.Product.Description,
                        Price = oi.Product.Price,
                        ImageFilePath = oi.Product.Image?.FilePath ?? ""  // fix this?
                    }
                }).ToList()
            });

            return View(ordersVMs);
        }

        private async Task<int> GetCurrentUserId()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return -1;

            return user.UserId;
        }
    }
}
