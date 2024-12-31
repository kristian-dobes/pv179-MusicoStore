using BusinessLayer.DTOs.GiftCard;
using BusinessLayer.DTOs.Order;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.User;

namespace WebMVC.Models.Order
{
    public class OrderDetailViewModel
    {
        public required int OrderId { get; set; }
        public required DateTime Created { get; set; }
        public required int OrderItemsCount { get; set; }
        public required IEnumerable<OrderItemCompleteDTO> OrderItems { get; set; }
        public required CustomerOrderDTO User { get; set; }
        public required decimal TotalOrderPrice { get; set; }
        public required string PaymentStatus { get; set; }
        public GiftCardSummaryDTO? GiftCard { get; set; }
        public string? UsedCouponCode { get; set; } = "";
    }
}
