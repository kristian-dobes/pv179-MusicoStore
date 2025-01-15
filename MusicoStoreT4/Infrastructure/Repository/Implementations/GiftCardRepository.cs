using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementations
{
    public class GiftCardRepository : Repository<GiftCard>, IGiftCardRepository
    {
        private readonly MyDBContext _context;

        public GiftCardRepository(MyDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> UpdateAsync(GiftCard entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingGiftCard = await _context.GiftCards
                .Include(g => g.CouponCodes)
                .FirstOrDefaultAsync(g => g.Id == entity.Id);

            if (existingGiftCard == null)
                return false;

            existingGiftCard.DiscountAmount = entity.DiscountAmount;
            existingGiftCard.ValidityStartDate = entity.ValidityStartDate;
            existingGiftCard.ValidityEndDate = entity.ValidityEndDate;

            var outdatedCoupons = existingGiftCard.CouponCodes
                .Where(cc => !entity.CouponCodes.Any(ecc => ecc.Id == cc.Id))
                .ToList();

            _context.CouponCodes.RemoveRange(outdatedCoupons);

            foreach (var couponCode in entity.CouponCodes)
            {
                var existingCoupon = existingGiftCard.CouponCodes
                    .FirstOrDefault(cc => cc.Id == couponCode.Id);

                if (existingCoupon == null)
                {
                    existingGiftCard.CouponCodes.Add(couponCode);
                }
                else
                {
                    existingCoupon.Code = couponCode.Code;
                    existingCoupon.IsUsed = couponCode.IsUsed;
                    existingCoupon.OrderId = couponCode.OrderId;
                }
            }

            _context.GiftCards.Update(existingGiftCard);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<GiftCard?> GetGiftCardByCodeAsync(string code)
        {
            return await _context.Set<GiftCard>()
                .Include(gc => gc.CouponCodes)
                .FirstOrDefaultAsync(gc => gc.CouponCodes.Any(cc => cc.Code == code));
        }
    }
}
