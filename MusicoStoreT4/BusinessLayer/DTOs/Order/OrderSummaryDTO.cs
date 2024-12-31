using BusinessLayer.DTOs.GiftCard;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.Order
{
    public class OrderSummaryDTO
    {
        public int OrderId { get; set; }
        public DateTime Created { get; set; }
        public required int OrderItemsCount { get; set; }
        public int CustomerId { get; set; }
        public required string Email { get; set; }
        public required decimal TotalOrderPrice { get; set; }
        public required string PaymentStatus { get; set; }

        public GiftCardSummaryDTO GiftCard { get; set; }
    }
}
