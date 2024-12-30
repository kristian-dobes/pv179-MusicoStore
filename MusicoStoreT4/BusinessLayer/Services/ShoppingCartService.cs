using BusinessLayer.DTOs.GiftCard;
using BusinessLayer.Enums;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Enums;
using Infrastructure.Other;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ISessionManager _sessionManager;
        private readonly IGiftCardService _giftCardService;

        private const string CartSessionKey = "ShoppingCart";

        public ShoppingCartService(ISessionManager sessionManager, IGiftCardService giftCardService)
        {
            _sessionManager = sessionManager;
            _giftCardService = giftCardService;
        }

        public ShoppingCart GetCart()
        {
            return _sessionManager.Get<ShoppingCart>(CartSessionKey) ?? new ShoppingCart();
        }

        public void SaveCart(ShoppingCart cart)
        {
            _sessionManager.Set(CartSessionKey, cart);
        }

        public void UpdateQuantity(int productId, int quantityChange)
        {
            var cart = GetCart();
            var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (item != null)
            {
                item.Quantity += quantityChange;

                if (item.Quantity <= 0)
                {
                    cart.CartItems.Remove(item);
                }
            }

            SaveCart(cart);
        }

        public bool ApplyCoupon(string couponCode)
        {
            // Business logic for validating coupon and applying it
        }

        public void PlaceOrder()
        {
            // Business logic for placing the order
        }
    }
}
