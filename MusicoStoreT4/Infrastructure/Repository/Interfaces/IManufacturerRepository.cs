using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        Task<List<Manufacturer>> GetManufacturersWithProductsAsync();
        IQueryable<Manufacturer> GetAllQuery();
        IQueryable<Manufacturer> GetAllQueryWithProducts();
        IQueryable<Manufacturer> GetQueryById(int id);
    }
}
