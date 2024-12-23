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
        public required decimal TotalPrice { get; set; }
    }
}
