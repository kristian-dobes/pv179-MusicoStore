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
        Task<GiftCardDto> GetById(int giftCardId);
    }
}
