using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Order
{
    public class OrderDetailDTO
    {
        public int OrderId { get; set; }
        public DateTime Created { get; set; }
        public required int OrderItemsCount { get; set; }
        public required IEnumerable<OrderItemCompleteDTO> OrderItems { get; set; }
        public required CustomerOrderDTO User { get; set; }
        public required decimal TotalOrderPrice { get; set; }
        public required string OrderStatus { get; set; }
    }
}
