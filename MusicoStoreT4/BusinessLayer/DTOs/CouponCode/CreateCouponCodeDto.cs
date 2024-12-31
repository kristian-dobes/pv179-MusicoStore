namespace BusinessLayer.DTOs.CouponCode
{
    public class CreateCouponCodeDto
    {
        public required string Code { get; set; }
        public required int GiftCardId { get; set; }
    }
}
