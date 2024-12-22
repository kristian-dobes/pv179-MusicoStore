using BusinessLayer.DTOs.OrderItem;

namespace BusinessLayer.DTOs.Order
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public List<OrderItemDto> Items { get; set; }
    }
}
