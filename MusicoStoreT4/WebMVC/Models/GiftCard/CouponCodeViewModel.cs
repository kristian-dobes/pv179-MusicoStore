
namespace WebMVC.Models.GiftCard
{
    public class CouponCodeViewModel
    {
        public int CouponCodeId { get; set; }
        public DateTime Created { get; set; }
        public string Code { get; set; }
        public bool IsUsed { get; set; }
        public int? OrderId { get; set; }
    }
}
