using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebMVC.Models.Product;

namespace WebMVC.Controllers
{
    [Route("products")]
    public class ShoppingCartController : Controller
    {
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(UserManager<LocalIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var cart = _shoppingCartService.GetCartItems();
            return View(cart);
        }

        [HttpPost]
        public IActionResult ApplyCoupon(string couponCode)
        {
            var result = _shoppingCartService.ApplyCoupon(couponCode);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantityChange)
        {
            _shoppingCartService.UpdateQuantity(productId, quantityChange);
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult RemoveItem(int productId)
        {
            _shoppingCartService.RemoveItem(productId);
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            _shoppingCartService.PlaceOrder();
            return RedirectToAction("OrderConfirmation");
        }
    }
}
