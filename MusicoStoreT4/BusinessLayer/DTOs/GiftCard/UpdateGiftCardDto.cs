using BusinessLayer.DTOs.CouponCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTOs.GiftCard
{
    public class UpdateGiftCardDto
    {
        public required int GiftCardId { get; set; }
        public decimal? DiscountAmount { get; set; }
        public DateTime? ValidityStartDate { get; set; }
        public DateTime? ValidityEndDate { get; set; }

        public IEnumerable<CouponCodeDto>? CouponCodes { get; set; }
    }
}
