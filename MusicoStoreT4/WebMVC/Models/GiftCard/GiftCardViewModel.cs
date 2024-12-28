namespace WebMVC.Models.GiftCard
{
    public class GiftCardViewModel
    {
        public int GiftCardId { get; set; }
        public DateTime Created { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ValidityStartDate { get; set; }
        public DateTime ValidityEndDate { get; set; }

        public virtual ICollection<CouponCodeViewModel> CouponCodes { get; set; }
    }
}
