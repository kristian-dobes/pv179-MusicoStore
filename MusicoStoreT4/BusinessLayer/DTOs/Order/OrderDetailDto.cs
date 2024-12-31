using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs.CouponCode;
using BusinessLayer.DTOs.GiftCard;
using BusinessLayer.DTOs.OrderItem;
using BusinessLayer.DTOs.User;

namespace BusinessLayer.DTOs.Order
{
    public class OrderDetailDto
    {
        public int OrderId { get; set; }
        public DateTime Created { get; set; }
        public required int OrderItemsCount { get; set; }
        public required IEnumerable<OrderItemCompleteDTO> OrderItems { get; set; }
        public required CustomerOrderDTO User { get; set; }
        public required decimal TotalOrderPrice { get; set; }
        public required string PaymentStatus { get; set; }
        public GiftCardSummaryDTO? GiftCard { get; set; }
        public CouponCodeSummaryDTO? CouponCode { get; set; }
    }
}
