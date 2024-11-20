using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using DataAccessLayer.Models;

namespace BusinessLayer.Services.Interfaces
{
    public interface IProductService : IBaseService
    {
        Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId);
        Task<List<Product>> GetProductsByManufacturerAsync(int manufacturerId);
        Task UpdateProductManufacturerAsync(int productId, int newManufacturerId);
    }
}
