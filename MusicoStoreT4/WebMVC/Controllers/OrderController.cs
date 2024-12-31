using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebMVC.Models;
using WebMVC.Models.Order;

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
            //var userId = 3; // for testing

            var orders = await _orderService.GetOrdersByUserAsync(userId);

            if (orders == null || !orders.Any())
                return View("NoOrders");

            return View(orders.Adapt<IEnumerable<OrderDetailViewModel>>());
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
