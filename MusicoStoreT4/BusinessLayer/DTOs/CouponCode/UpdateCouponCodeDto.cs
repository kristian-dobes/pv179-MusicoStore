namespace BusinessLayer.DTOs.CouponCode
{
    public class UpdateCouponCodeDto
    {
        public required int CouponCodeId { get; set; }
        public string? Code { get; set; }
        public bool? IsUsed { get; set; }
        public int? GiftCardId { get; set; }
        public int? OrderId { get; set; }
    }
}
