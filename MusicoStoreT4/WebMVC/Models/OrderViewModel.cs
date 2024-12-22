using BusinessLayer.DTOs;
using DataAccessLayer.Models.Enums;

namespace WebMVC.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatusStr { get; set; } = "";
        public List<OrderItemViewModel> OrderItems = new();
    }
}
