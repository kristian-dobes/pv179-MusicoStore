using BusinessLayer.DTOs.OrderItem;

namespace BusinessLayer.DTOs.Order
{
    public class UpdateOrderDto
    {
        public required int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public List<OrderItemDto>? OrderItems { get; set; } = new();
        // public OrderStatus? OrderStatus { get; set; }
    }
}
