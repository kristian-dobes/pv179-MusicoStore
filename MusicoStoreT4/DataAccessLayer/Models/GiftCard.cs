namespace DataAccessLayer.Models
{
    public class GiftCard : BaseEntity
    {
        public decimal DiscountAmount { get; set; }
        public DateTime ValidityStartDate { get; set; }
        public DateTime ValidityEndDate { get; set; }

        public virtual ICollection<CouponCode> CouponCodes { get; set; }
    }
}
