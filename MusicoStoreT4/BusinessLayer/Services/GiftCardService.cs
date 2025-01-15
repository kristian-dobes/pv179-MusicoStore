using BusinessLayer.DTOs.CouponCode;
using BusinessLayer.DTOs.GiftCard;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Infrastructure.UnitOfWork;
using Mapster;

namespace BusinessLayer.Services
{
    public class GiftCardService : BaseService, IGiftCardService
    {
        private readonly IUnitOfWork _uow;

        public GiftCardService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<IEnumerable<GiftCardDto>> GetGiftCardsAsync()
        {
            return (await _uow.GiftCardsRep.GetAllAsync()).Select(gc => gc.Adapt<GiftCardDto>());
        }

        public async Task<GiftCardDto> GetGiftCardByIdAsync(int giftCardId)
        {
            return (await _uow.GiftCardsRep.GetByIdAsync(giftCardId)).Adapt<GiftCardDto>();
        }

        public async Task<GiftCardDto> CreateGiftCardAsync(CreateGiftCardDto createGiftCardDto)
        {
            if (createGiftCardDto.DiscountAmount <= 0)
            {
                throw new ArgumentException("Discount must be greater than zero.");
            }

            if (createGiftCardDto.ValidityStartDate >= createGiftCardDto.ValidityEndDate)
            {
                throw new ArgumentException("Validity start date must be before end date.");
            }

            var giftCard = createGiftCardDto.Adapt<GiftCard>();
            var addedGiftCard = await _uow.GiftCardsRep.AddAsync(giftCard);

            var couponCodes = Enumerable.Range(0, createGiftCardDto.CouponCodesCount)
                .Select(_ => new CouponCode
                {
                    Code = Guid.NewGuid().ToString(),
                    GiftCardId = addedGiftCard.Id
                })
                .ToList();

            await _uow.CouponCodesRep.AddRangeAsync(couponCodes);

            await _uow.SaveAsync();

            return addedGiftCard.Adapt<GiftCardDto>();
        }

        public async Task<GiftCardDto?> UpdateGiftCardAsync(UpdateGiftCardDto updateGiftCardDto)
        {
            if (updateGiftCardDto.DiscountAmount.HasValue && updateGiftCardDto.DiscountAmount <= 0)
            {
                throw new ArgumentException("DiscountAmount must be larger than 0");
            }

            var giftCardToUpdate = new GiftCard
            {
                Id = updateGiftCardDto.GiftCardId,
                DiscountAmount = updateGiftCardDto.DiscountAmount ?? 0,
                ValidityStartDate = updateGiftCardDto.ValidityStartDate ?? default,
                ValidityEndDate = updateGiftCardDto.ValidityEndDate ?? default,
                CouponCodes = updateGiftCardDto.CouponCodes?.Select(c => new CouponCode
                {
                    Id = c.CouponCodeId,
                    Code = c.Code,
                    IsUsed = c.IsUsed,
                    OrderId = c.OrderId
                }).ToList() ?? new List<CouponCode>()
            };

            bool updated = await _uow.GiftCardsRep.UpdateAsync(giftCardToUpdate);

            if (!updated)
            {
                throw new KeyNotFoundException("Gift card ID not found");
            }

            return giftCardToUpdate.Adapt<GiftCardDto>();
        }

        public async Task<bool> DeleteGiftCardAsync(int giftCardId)
        {
            var existingGiftCard = await _uow.GiftCardsRep.GetByIdAsync(giftCardId);

            if (existingGiftCard == null)
            {
                throw new KeyNotFoundException("Gift card ID not found");
            }

            return await _uow.GiftCardsRep.DeleteAsync(giftCardId);
        }

        public async Task<IEnumerable<CouponCodeDto>> GetCouponCodesAsync()
        {
            return (await _uow.CouponCodesRep.GetAllAsync()).Select(gc => gc.Adapt<CouponCodeDto>());
        }

        public async Task<CouponCodeDto> GetCouponCodeByIdAsync(int couponCodeId)
        {
            return (await _uow.CouponCodesRep.GetByIdAsync(couponCodeId)).Adapt<CouponCodeDto>();
        }

        public async Task<bool> CreateCouponCodeAsync(CreateCouponCodeDto createCouponCodeDto)
        {
            if ((await _uow.CouponCodesRep.AnyAsync(cc => cc.Code == createCouponCodeDto.Code)))
            {
                return false; // Duplicate code exists
            }

            if (!(await _uow.GiftCardsRep.AnyAsync(gc => gc.Id == createCouponCodeDto.GiftCardId)))
            {
                return false; // Invalid Gift Card ID
            }

            var couponCode = createCouponCodeDto.Adapt<CouponCode>();
            var added = await _uow.CouponCodesRep.AddAsync(couponCode);
            await _uow.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateCouponCodeAsync(UpdateCouponCodeDto updateCouponCodeDto)
        {
            try
            {
                var existingCouponCode = await _uow.CouponCodesRep
                    .FirstOrDefaultAsync(cc => cc.Id == updateCouponCodeDto.CouponCodeId);

                if (existingCouponCode == null)
                {
                    return false; // Coupon code not found
                }

                if (updateCouponCodeDto.Code != null)
                {
                    if (await _uow.CouponCodesRep.AnyAsync(cc => cc.Id != updateCouponCodeDto.CouponCodeId && cc.Code == updateCouponCodeDto.Code))
                    {
                        return false; // Duplicate code exists
                    }

                    // Assign the new code
                    existingCouponCode.Code = updateCouponCodeDto.Code;
                }

                if (updateCouponCodeDto.IsUsed.HasValue)
                {
                    existingCouponCode.IsUsed = updateCouponCodeDto.IsUsed.Value;
                }

                if (updateCouponCodeDto.GiftCardId.HasValue)
                {
                    // Validate Gift Card ID
                    if (!(await _uow.GiftCardsRep.AnyAsync(gc => gc.Id == updateCouponCodeDto.GiftCardId)))
                    {
                        return false; // Invalid Gift Card ID
                    }
                }

                if (updateCouponCodeDto.OrderId.HasValue)
                {
                    // Validate Order ID
                    if (!(await _uow.OrdersRep.AnyAsync(o => o.Id == updateCouponCodeDto.OrderId.Value)))
                    {
                        return false; // Invalid Order ID
                    }
                }

                // Update and save changes
                await _uow.CouponCodesRep.UpdateAsync(existingCouponCode);
                await _uow.SaveAsync();

                return true; // Update successful
            }
            catch
            {
                return false; //unexpected errors
            }
        }

        public async Task<bool> DeleteCouponCodeAsync(int couponCodeId)
        {
            var existingCouponCode = await _uow.CouponCodesRep.GetByIdAsync(couponCodeId);

            if (existingCouponCode == null)
            {
                throw new KeyNotFoundException("Coupon code ID not found");
            }

            return await _uow.CouponCodesRep.DeleteAsync(couponCodeId);
        }

        public async Task<GiftCardDto?> GetGiftCardByCouponCodeAsync(string code)
        {
            CouponCode? couponCode = await _uow.CouponCodesRep.FirstOrDefaultAsync(cc => cc.Code == code);

            if (couponCode == null)
                return null;

            return couponCode.GiftCard.Adapt<GiftCardDto>();
        }

        public async Task<(bool Valid, decimal DiscountAmount, string? ErrorMessage)> ValidateCouponCode(string code)
        {
            CouponCode? couponCode = await _uow.CouponCodesRep.FirstOrDefaultAsync(cc => cc.Code == code);
            
            if (couponCode == null)
            {
                return (false, 0, "Invalid gift card code"); // Invalid gift card code
            }

            if (couponCode.IsUsed)
            {
                return (false, 0, "Gift card code has already been used"); // Gift card code has already been used
            }

            if(couponCode.GiftCard.ValidityEndDate < DateTime.Now)
            {
                return (false, 0, "Gift card code is expired"); // Gift card code has expired
            }

            if (couponCode.GiftCard.ValidityStartDate > DateTime.Now)
            {
                return (false, 0, "Gift card code is not yet valid"); // Gift card code is not yet valid
            }
                
            return (true, couponCode.GiftCard.DiscountAmount, null);
        }

        public async Task<bool> SetCouponCodeAsUsed(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return false;
            }

            // Fetch the CouponCode using the repository
            var couponCode = await _uow.CouponCodesRep.GetCouponCodeByCodeAsync(code);

            // remove validity check, as it is already checked in ValidateCouponCode method
            if (couponCode == null)
            {
                return false; // Invalid coupon code
            }

            // Mark the coupon as used
            await _uow.CouponCodesRep.MarkCouponCodeAsUsedAsync(couponCode);

            return true;
        }
    }
}
