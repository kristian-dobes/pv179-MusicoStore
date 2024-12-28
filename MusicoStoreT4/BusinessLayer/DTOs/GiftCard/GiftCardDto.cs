using BusinessLayer.DTOs.CouponCode;

namespace BusinessLayer.DTOs.GiftCard
{
    public class GiftCardDto
    {
        public int GiftCardId { get; set; }
        public DateTime Created { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ValidityStartDate { get; set; }
        public DateTime ValidityEndDate { get; set; }

        public virtual IEnumerable<CouponCodeDto> CouponCodes { get; set; }
    }
}
