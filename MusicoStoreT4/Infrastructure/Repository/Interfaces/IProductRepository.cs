using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllWithDetailsAsync();
        IQueryable<Product> GetAllQuery();
        Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<int> ids);
        Task<List<int>> GetProductIdsByManufacturerAsync(int manufacturerId);
        Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int destinationManufacturerId, int modifiedById);
    }
}
