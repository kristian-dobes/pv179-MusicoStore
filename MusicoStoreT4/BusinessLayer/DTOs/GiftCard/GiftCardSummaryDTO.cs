using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.GiftCard
{
    public class GiftCardSummaryDTO
    {
        public int GiftCardId { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
