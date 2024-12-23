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
        Task<ProductCompleteDTO?> GetProductByIdAsync(int productId);
        Task<IEnumerable<ProductCompleteDTO>> GetAllProductsAsync();
        Task<IEnumerable<ProductWithDetailsDto>> GetAllProductsWithDetailsAsync();
        Task <ProductCompleteDTO> UpdateProductAsync(int id, ProductUpdateDTO productDto);
        Task<ProductDto> CreateProductAsync(ProductCreateDTO productDto);
        Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int targetManufacturerId, int modifiedBy);
        Task<IEnumerable<ProductDto>> GetProductsByManufacturerAsync(int manufacturerId);
        Task UpdateProductManufacturerAsync(int productId, int newManufacturerId, int modifiedBy);
        Task<IEnumerable<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(DateTime startDate, DateTime endDate, int topN = 5);
        Task DeleteProductAsync(int productId, int deletedBy);
        Task<IEnumerable<ProductDto>> GetFilteredProductsAsync(FilterProductDto filterProductDto);
    }
}
