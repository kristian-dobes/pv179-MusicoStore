using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.CouponCode;
using BusinessLayer.DTOs.GiftCard;
using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Enums;
using BusinessLayer.Mapper;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Infrastructure.UnitOfWork;
using Mapster;
using Microsoft.EntityFrameworkCore;

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
            var added = await _uow.GiftCardsRep.AddAsync(giftCard);

            await _uow.SaveAsync();

            return added.Adapt<GiftCardDto>();
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

        public async Task<CouponCodeDto> CreateCouponCodeAsync(CreateCouponCodeDto createCouponCodeDto)
        {
            if ((await _uow.CouponCodesRep.AnyAsync(cc => cc.Code == createCouponCodeDto.Code)))
            {
                throw new ArgumentException("A coupon code with this code already exists");
            }

            if (!(await _uow.GiftCardsRep.AnyAsync(gc => gc.Id == createCouponCodeDto.GiftCardId)))
            {
                throw new ArgumentException("There is no gift card with this id");
            }

            var couponCode = createCouponCodeDto.Adapt<CouponCode>();
            var added = await _uow.CouponCodesRep.AddAsync(couponCode);
            await _uow.SaveAsync();
            return added.Adapt<CouponCodeDto>();
        }

        public async Task<CouponCodeDto?> UpdateCouponCodeAsync(UpdateCouponCodeDto updateCouponCodeDto)
        {
            Console.WriteLine("CouponCodeId: " + updateCouponCodeDto.CouponCodeId);
            Console.WriteLine("CouponCodeText: " + updateCouponCodeDto.Code);

            var existingCouponCode = await _uow.CouponCodesRep
                .FirstOrDefaultAsync(cc => cc.Id == updateCouponCodeDto.CouponCodeId);

            if (existingCouponCode == null)
            {
                throw new KeyNotFoundException("Coupon code ID not found");
            }

            if (updateCouponCodeDto.Code != null)
            {
                if (await _uow.CouponCodesRep.AnyAsync(cc => cc.Id != updateCouponCodeDto.CouponCodeId && cc.Code == updateCouponCodeDto.Code))
                {
                    throw new ArgumentException("A coupon code with this code already exists");
                }
                
                // Assign the new Code
                existingCouponCode.Code = updateCouponCodeDto.Code;
            }

            if (updateCouponCodeDto.IsUsed.HasValue)
            {
                existingCouponCode.IsUsed = updateCouponCodeDto.IsUsed.Value;
            }

            if (updateCouponCodeDto.GiftCardId.HasValue)
            {
                if (!(await _uow.GiftCardsRep.AnyAsync(gc => gc.Id == updateCouponCodeDto.GiftCardId)))
                {
                    throw new ArgumentException("There is no gift card with this id");
                }
            }

            if (updateCouponCodeDto.OrderId.HasValue)
            {
                if (!(await _uow.OrdersRep.AnyAsync(o => o.Id == updateCouponCodeDto.OrderId.Value)))
                {
                    throw new ArgumentException("There is no order with this id");
                }
            }

            await _uow.CouponCodesRep.UpdateAsync(existingCouponCode);
            await _uow.SaveAsync();
            return existingCouponCode.Adapt<CouponCodeDto>();
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

        public async Task<bool> SetCouponCodeAsUsed(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentException("Coupon code cannot be null or empty", nameof(code));
            }

            // Fetch the CouponCode using the repository
            var couponCode = await _uow.CouponCodesRep.GetCouponCodeByCodeAsync(code);

            if (couponCode == null || couponCode.IsUsed)
            {
                return false; // Invalid or already used
            }

            // Mark the coupon as used
            await _uow.CouponCodesRep.MarkCouponCodeAsUsedAsync(couponCode);

            return true;
        }
    }
}
