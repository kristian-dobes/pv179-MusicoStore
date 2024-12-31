using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICouponCodeRepository : IRepository<CouponCode>
    {
        Task<CouponCode?> GetCouponCodeByCodeAsync(string code);
        Task MarkCouponCodeAsUsedAsync(CouponCode couponCode);
    }
}
