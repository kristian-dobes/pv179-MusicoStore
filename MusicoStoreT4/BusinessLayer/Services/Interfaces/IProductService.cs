using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using DataAccessLayer.Models;
using BusinessLayer.DTOs.Product;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Services.Interfaces
{
    public interface IProductService : IBaseService
    {
        Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId, int modifiedBy);
        Task<List<Product>> GetProductsByManufacturerAsync(int manufacturerId);
        Task UpdateProductManufacturerAsync(int productId, int newManufacturerId, int modifiedBy);
        Task<List<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(DateTime startDate, DateTime endDate, int topN = 5);
        Task<ProductDto> GetProductByIdAsync(int productId);
        Task UpdateProductAsync(UpdateProductDTO productDto, int modifiedById);
        Task<Product> CreateProductAsync(CreateProductDTO productDto, int createdById);
        Task DeleteProductAsync(int productId, int deletedBy);
    }
}
