using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface ICouponCodeRepository : IRepository<CouponCode>
    {
        Task<CouponCode?> GetCouponCodeByCodeAsync(string code);
        Task MarkCouponCodeAsUsedAsync(CouponCode couponCode);
    }
}
