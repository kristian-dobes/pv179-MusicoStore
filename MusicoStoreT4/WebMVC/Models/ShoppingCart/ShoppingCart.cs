namespace WebMVC.Models.ShoppingCart
{
    public class ShoppingCart
    {
        public List<CartItem> CartItems { get; set; } = [];
        public decimal TotalAmount => CartItems.Sum(item => item.Price * item.Quantity);
        public string? AppliedGiftCardCode { get; set; } // Gift card code applied to the cart
        public decimal DiscountAmount { get; set; } = 0; // Discount from the gift card

        public decimal FinalAmount => TotalAmount - DiscountAmount; // Final amount after discount
    }
}
