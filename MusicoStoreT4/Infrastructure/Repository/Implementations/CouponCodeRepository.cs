﻿using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Implementations
{
    public class CouponCodeRepository : Repository<CouponCode>, ICouponCodeRepository
    {
        private readonly MyDBContext _context;

        public CouponCodeRepository(MyDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<bool> UpdateAsync(CouponCode entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingCouponCode = await _context.CouponCodes
                .FirstOrDefaultAsync(g => g.Id == entity.Id);

            if (existingCouponCode == null)
                return false;

            existingCouponCode.Code = entity.Code;
            existingCouponCode.IsUsed = entity.IsUsed;

            var giftCard = _context.GiftCards.FirstOrDefault(gc => gc.Id == existingCouponCode.GiftCardId);

            if (giftCard == null)
                return false;

            existingCouponCode.GiftCardId = entity.GiftCardId;
            existingCouponCode.OrderId = entity.OrderId;

            _context.CouponCodes.Update(existingCouponCode);
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<CouponCode?> GetCouponCodeByCodeAsync(string code)
        {
            return await _context.Set<CouponCode>()
                //.Include(cc => cc.GiftCard)
                .FirstOrDefaultAsync(cc => cc.Code == code);
        }

        public async Task MarkCouponCodeAsUsedAsync(CouponCode couponCode)
        {
            couponCode.IsUsed = true;
            _context.Set<CouponCode>().Update(couponCode);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<CouponCode> couponCodes)
        {
            if (couponCodes == null || !couponCodes.Any())
                throw new ArgumentException("The couponCodes collection cannot be null or empty.", nameof(couponCodes));

            await _context.CouponCodes.AddRangeAsync(couponCodes);
        }
    }
}
