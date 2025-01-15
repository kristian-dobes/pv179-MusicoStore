using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IProductImageRepository : IRepository<ProductImage>
    {
        Task<ProductImage?> GetByProductIdAsync(int productId);
    }
}
