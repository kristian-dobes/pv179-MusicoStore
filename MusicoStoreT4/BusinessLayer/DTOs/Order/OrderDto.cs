using DataAccessLayer.Models.Enums;

namespace BusinessLayer.DTOs.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Created { get; set; }
        public PaymentStatus OrderStatus { get; set; }
    }
}
