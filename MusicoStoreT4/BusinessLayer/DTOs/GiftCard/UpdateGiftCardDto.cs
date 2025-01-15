using BusinessLayer.DTOs.CouponCode;

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
