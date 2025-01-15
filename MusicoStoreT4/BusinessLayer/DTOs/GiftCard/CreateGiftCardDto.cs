namespace BusinessLayer.DTOs.GiftCard
{
    public class CreateGiftCardDto
    {
        public required decimal DiscountAmount { get; set; }
        public required DateTime ValidityStartDate { get; set; }
        public required DateTime ValidityEndDate { get; set; }
        public required int CouponCodesCount { get; set; }
    }
}
