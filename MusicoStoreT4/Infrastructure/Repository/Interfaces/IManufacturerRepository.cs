using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace Infrastructure.Repository.Interfaces
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        Task<List<Manufacturer>> GetManufacturersWithProductsAsync();
        IQueryable<Manufacturer> GetAllQuery();
    }
}
