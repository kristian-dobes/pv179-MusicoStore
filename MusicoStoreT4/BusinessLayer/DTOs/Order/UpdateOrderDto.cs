using BusinessLayer.DTOs.OrderItem;

namespace BusinessLayer.DTOs.Order
{
    public class UpdateOrderDto
    {
        public DateTime? OrderDate { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; }
    }
}
