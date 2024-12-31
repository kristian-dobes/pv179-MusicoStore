using BusinessLayer.DTOs.Order;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Helpers;
using WebMVC.Models.ShoppingCart;

namespace WebMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGiftCardService _giftCardService;
        private readonly IOrderService _orderService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public ShoppingCartController(IGiftCardService giftCardService, IOrderService orderService, UserManager<LocalIdentityUser> userManager)
        {
            _giftCardService = giftCardService;
            _orderService = orderService;
            _userManager = userManager;
        }
        
        [HttpGet("Cart")]
        public IActionResult Cart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, string productName, decimal price, int quantity = 1)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

            var existingItem = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productName,
                    Price = price,
                    Quantity = quantity
                });
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, cartTotal = cart.TotalAmount });
        }

        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");

            // Check if the cart is null or empty
            if (cart == null || !cart.CartItems.Any())
            {
                return View("Cart", new ShoppingCart()); // Reload the cart view
            }

            // Retrieve the userId of the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.User == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // Create the CreateOrderDto from the cart
            var createOrderDto = new CreateOrderDto
            {
                CustomerId = user.User.Id,
                Items = cart.CartItems.Select(item => new OrderItemDto
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                }),
                AppliedGiftCardCode = cart.AppliedGiftCardCode,
                DiscountAmount = cart.DiscountAmount
            };

            var orderCreated = await _orderService.CreateOrderAsync(createOrderDto);

            if (!orderCreated)
            {
                return View("Cart", cart); // Reload the cart view
            }

            // Clear the cart
            HttpContext.Session.Remove("Cart");

            return View("Cart");
        }

        [HttpPost]
        public async Task<IActionResult> ApplyGiftCard(string giftCardCode)
        {
            // Check if cart exists
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

            // Validate the gift card code
            var couponCode = await _giftCardService.GetGiftCardByCouponCodeAsync(giftCardCode);

            if (couponCode == null ||
                couponCode.ValidityStartDate > DateTime.Now ||
                couponCode.ValidityEndDate < DateTime.Now)
            {
                return Json(new { success = false, message = "Invalid or expired gift card." });
            }

            var wasUsed = await _giftCardService.SetCouponCodeAsUsed(giftCardCode);
            if (!wasUsed)
            {
                return Json(new { success = false, message = "This coupon was already used." });
            }

            // Apply the discount
            cart.DiscountAmount = couponCode.DiscountAmount;
            cart.AppliedGiftCardCode = giftCardCode; // Set the applied gift card code

            // Save the cart back to session
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, discountAmount = cart.DiscountAmount, finalAmount = cart.FinalAmount });
        }
    }
}
