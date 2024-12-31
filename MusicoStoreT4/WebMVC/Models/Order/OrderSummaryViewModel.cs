using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.User;

namespace WebMVC.Models.Order
{
    public class OrderSummaryViewModel
    {
        public required int OrderId { get; set; }
        public required DateTime Created { get; set; }
        public required int OrderItemsCount { get; set; }
        public required int CustomerId { get; set; }
        public required string Email { get; set; }
        public required double TotalOrderPrice { get; set; }
        public required string PaymentStatus { get; set; }
    }
}
