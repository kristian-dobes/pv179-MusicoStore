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
        Task<ICollection<ProductCompleteDTO>> GetProducts();
        Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId, int modifiedBy);
        Task<List<ProductDto>> GetProductsByManufacturerAsync(int manufacturerId);
        Task UpdateProductManufacturerAsync(int productId, int newManufacturerId, int modifiedBy);
        Task<List<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(DateTime startDate, DateTime endDate, int topN = 5);
        Task<ProductDto?> GetProductByIdAsync(int productId);
        Task UpdateProductAsync(UpdateProductDto productDto, int modifiedById);
        Task<ProductDto> CreateProductAsync(CreateProductDto productDto, int createdById);
        Task DeleteProductAsync(int productId, int deletedBy);
        Task<List<ProductDto>> GetAllProductsAsync();
        Task<List<ProductWithDetailsDto>> GetAllProductsWithDetailsAsync();
        Task<List<ProductDto>> GetFilteredProductsAsync(FilterProductDto filterProductDto);
    }
}
