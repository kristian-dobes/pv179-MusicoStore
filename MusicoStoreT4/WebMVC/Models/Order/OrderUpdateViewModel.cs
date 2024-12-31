using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;

namespace WebMVC.Models.Order
{
    public class OrderUpdateViewModel
    {
        public IEnumerable<OrderItemDto> Items { get; set; }
        public string PaymentStatus { get; set; }

        public IEnumerable<ProductCompleteDTO> Products { get; set; } = [];
    }
}
