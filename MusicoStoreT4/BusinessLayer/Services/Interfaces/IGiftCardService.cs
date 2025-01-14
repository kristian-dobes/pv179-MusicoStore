using BusinessLayer.DTOs.CouponCode;
using BusinessLayer.DTOs.GiftCard;

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
        Task<(bool Valid, decimal DiscountAmount, string? ErrorMessage)> ValidateCouponCode(string code);
        Task<bool> CreateCouponCodeAsync(CreateCouponCodeDto createCouponCodeDto);
        Task<bool> UpdateCouponCodeAsync(UpdateCouponCodeDto updateCouponCodeDto);
        Task<bool> DeleteCouponCodeAsync(int couponCodeId);
        Task<bool> SetCouponCodeAsUsed(string code);

        Task<GiftCardDto?> GetGiftCardByCouponCodeAsync(string code);
    }
}
