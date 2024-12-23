using BusinessLayer.DTOs.OrderItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Order
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime Created { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new();
    }
}
