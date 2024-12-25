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
        private readonly IImageService _imageService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public OrderController(IOrderService orderService, IImageService imageService, UserManager<LocalIdentityUser> userManager)
        {
            _orderService = orderService;
            _imageService = imageService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> UserOrders()
        {
            //var userId = await GetCurrentUserId();
            var userId = 3; // for testing
            
            var orders = await _orderService.GetOrdersByUserAsync(userId);

            if (orders == null || !orders.Any())
                return View("NoOrders");

            var ordersVM = orders.Adapt<IEnumerable<OrderDetailViewModel>>();

            // access OrderItem and assign ProductImage
            foreach (var order in ordersVM)
            {
                foreach (var orderItem in order.OrderItems)
                {
                    if (orderItem != null)
                    {
                        orderItem.ProductImage = await _imageService.GetImagePathByProductIdAsync(orderItem.ProductId); // TODO can improve this ?
                    }
                }

            }

            return View(ordersVM);
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
