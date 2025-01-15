using BusinessLayer.DTOs.GiftCard;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.User;

namespace BusinessLayer.DTOs.Order
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public DateTime Created { get; set; }
        public required int OrderItemsCount { get; set; }
        public required IEnumerable<OrderItemCompleteDTO> OrderItems { get; set; }
        public required CustomerOrderDTO User { get; set; }
        public required decimal TotalOrderPrice { get; set; }
        public required string PaymentStatus { get; set; }
        public GiftCardSummaryDTO? GiftCard { get; set; }
        public string? UsedCouponCode { get; set; } = "";
    }
}
