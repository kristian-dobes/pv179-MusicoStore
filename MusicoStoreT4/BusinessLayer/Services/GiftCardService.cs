using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
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

        public async Task<GiftCardDto> GetById(int giftCardId)
        {
            return (await _uow.GiftCardsRep.GetByIdAsync(giftCardId)).Adapt<GiftCardDto>();
        }

        public async Task<GiftCardDto> CreateGiftCardAsync(CreateGiftCardDto createGiftCardDto)
        {
            if (createGiftCardDto.DiscountAmount <= 0)
                throw new ArgumentException("Discount must be greater than zero.");

            if (createGiftCardDto.ValidityStartDate >= createGiftCardDto.ValidityEndDate)
                throw new ArgumentException("Validity start date must be before end date.");

            var giftCard = createGiftCardDto.Adapt<GiftCard>();
            var added = await _uow.GiftCardsRep.AddAsync(giftCard);

            await _uow.SaveAsync();

            return added.Adapt<GiftCardDto>();
        }
    }
}
