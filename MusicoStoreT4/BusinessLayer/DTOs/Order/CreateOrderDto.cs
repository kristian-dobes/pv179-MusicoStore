using BusinessLayer.DTOs.OrderItem;

namespace BusinessLayer.DTOs.Order
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
        public string? AppliedGiftCardCode { get; set; }
        public decimal DiscountAmount { get; set; } = 0;
    }
}
