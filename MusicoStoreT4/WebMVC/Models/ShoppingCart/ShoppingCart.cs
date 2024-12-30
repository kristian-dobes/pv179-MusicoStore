using BusinessLayer.Services.Interfaces;

namespace WebMVC.Models.ShoppingCart
{
    public class ShoppingCart
    {
        private readonly IGiftCardService _giftCardService;

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
        public string? CouponCode { get; set; }
        public decimal TotalPrice { get; set; }

        public ShoppingCart(IGiftCardService giftCardService)
        {
            _giftCardService = giftCardService;
        }

        public async Task CalculateTotalPrice()
        {
            decimal subtotal = CartItems.Sum(item => item.Price * item.Quantity);

            if (!string.IsNullOrEmpty(CouponCode))
            {
                var giftCard = await _giftCardService.GetGiftCardByCouponCodeAsync(CouponCode);

                if (giftCard != null && giftCard.ValidityStartDate <= DateTime.Now && giftCard.ValidityEndDate >= DateTime.Now)
                {
                    subtotal -= giftCard.DiscountAmount;
                }
            }

            TotalPrice = subtotal;
        }
    }
}
