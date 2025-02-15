﻿using BusinessLayer.DTOs.GiftCard;

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
