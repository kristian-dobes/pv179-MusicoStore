using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.Product;
using BusinessLayer.DTOs.User;
using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.Order
{
    public class OrderCreateViewModel
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public IEnumerable<OrderItemDto> Items { get; set; }

        public IEnumerable<UserDto> Users { get; set; } = [];
        public IEnumerable<ProductCompleteDTO> Products { get; set; } = [];
    }
}
