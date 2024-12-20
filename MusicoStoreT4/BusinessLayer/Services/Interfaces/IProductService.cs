using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using DataAccessLayer.Models;
using BusinessLayer.DTOs.Product;

namespace BusinessLayer.Services.Interfaces
{
    public interface IProductService : IBaseService
    {
        Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId);
        Task<List<Product>> GetProductsByManufacturerAsync(int manufacturerId);
        Task UpdateProductManufacturerAsync(int productId, int newManufacturerId);
        Task<List<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(DateTime startDate, DateTime endDate, int topN = 5);
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task UpdateProductAsync(UpdateProductDTO productDto, string modifiedBy);
        Task<Product> CreateProductAsync(CreateProductDTO productDto, string createdBy);
        Task DeleteProductAsync(int productId, string deletedBy);
    }
}
