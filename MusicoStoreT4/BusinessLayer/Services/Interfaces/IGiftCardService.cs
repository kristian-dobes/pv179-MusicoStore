using BusinessLayer.DTOs.CouponCode;
using BusinessLayer.DTOs.GiftCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Interfaces
{
    public interface IGiftCardService
    {
        Task<IEnumerable<GiftCardDto>> GetGiftCardsAsync();
        Task<GiftCardDto> GetGiftCardByIdAsync(int giftCardId);
        Task<GiftCardDto> CreateGiftCardAsync(CreateGiftCardDto createGiftCardDto);
        Task<GiftCardDto?> UpdateGiftCardAsync(UpdateGiftCardDto updateGiftCardDto);
        Task<bool> DeleteGiftCardAsync(int giftCardId);

        Task<IEnumerable<CouponCodeDto>> GetCouponCodesAsync();
        Task<CouponCodeDto> GetCouponCodeByIdAsync(int couponCodeId);
        Task<CouponCodeDto> CreateCouponCodeAsync(CreateCouponCodeDto createCouponCodeDto);
        Task<CouponCodeDto?> UpdateCouponCodeAsync(UpdateCouponCodeDto updateCouponCodeDto);
        Task<bool> DeleteCouponCodeAsync(int couponCodeId);

        Task<GiftCardDto?> GetGiftCardByCouponCodeAsync(string code);
    }
}
