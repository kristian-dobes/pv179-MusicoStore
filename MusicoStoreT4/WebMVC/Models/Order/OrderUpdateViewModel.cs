using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;
using BusinessLayer.DTOs.User;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.Order
{
    public class OrderUpdateViewModel
    {
        public IEnumerable<OrderItemDto> Items { get; set; }

        public IEnumerable<ProductCompleteDTO> Products { get; set; } = [];
    }
}
