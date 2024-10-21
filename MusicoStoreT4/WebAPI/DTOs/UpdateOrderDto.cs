namespace WebAPI.DTOs
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
