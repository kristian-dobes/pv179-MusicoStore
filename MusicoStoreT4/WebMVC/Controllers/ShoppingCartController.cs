using BusinessLayer.DTOs.Order;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Helpers;
using WebMVC.Models.ShoppingCart;

namespace WebMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IGiftCardService _giftCardService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public ShoppingCartController(IGiftCardService giftCardService, IProductService productService, IOrderService orderService, UserManager<LocalIdentityUser> userManager)
        {
            _giftCardService = giftCardService;
            _productService = productService;
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
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

            var existingItem = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var productShoppingDetailsDTO = _productService.GetProductShoppingDetailsAsync(productId).Result;

                if (productShoppingDetailsDTO == null)
                {
                    return Json(new { success = false, message = "Product not found." });
                }

                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    ProductName = productShoppingDetailsDTO.Name,
                    Price = productShoppingDetailsDTO.Price,
                    Quantity = quantity
                });
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, cartTotal = cart.TotalAmount });
        }

        [HttpPost]
        public IActionResult RemoveItem(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

            var itemToRemove = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);

            if (itemToRemove != null)
            {
                cart.CartItems.Remove(itemToRemove);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return Json(new { success = true, cartTotal = cart.TotalAmount });
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId, int quantityChange)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

            var itemToUpdate = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);

            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity += quantityChange;

                if (itemToUpdate.Quantity <= 0)
                {
                    cart.CartItems.Remove(itemToUpdate);
                }

                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return Json(new { success = true, cartTotal = cart.TotalAmount, finalAmount = cart.FinalAmount });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");

            if (cart == null || !cart.CartItems.Any())
            {
                return View("Cart", new ShoppingCart());
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.User == null)
            {
                return Unauthorized();
            }

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
                return View("Cart", cart); 
            }

            // Clear the cart
            HttpContext.Session.Remove("Cart");

            return View("Cart");
        }

        [HttpPost]
        public async Task<IActionResult> ApplyGiftCard(string giftCardCode)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();

            // Check if a gift card is already applied
            if (!string.IsNullOrEmpty(cart.AppliedGiftCardCode))
            {
                return Json(new { success = false, message = "A gift card has already been applied to this cart." });
            }

            // Validate gift code
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

            // discount
            cart.DiscountAmount = couponCode.DiscountAmount;
            cart.AppliedGiftCardCode = giftCardCode; // applied gift card code

            // Save cart to session
            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, discountAmount = cart.DiscountAmount, finalAmount = cart.FinalAmount });
        }
    }
}
