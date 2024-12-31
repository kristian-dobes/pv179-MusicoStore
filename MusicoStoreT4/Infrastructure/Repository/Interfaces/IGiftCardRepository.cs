using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGiftCardRepository : IRepository<GiftCard>
    {
        Task<GiftCard?> GetGiftCardByCodeAsync(string code);
    }
}
