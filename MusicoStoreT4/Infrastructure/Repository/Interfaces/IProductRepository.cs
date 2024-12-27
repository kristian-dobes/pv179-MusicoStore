using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetAllWithDetailsAsync();
        IQueryable<Product> GetAllQuery();
        Task<IEnumerable<Product>> GetByIdsAsync(IEnumerable<int> ids);
    }
}
