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
        Task<List<Product>> GetProductsByManufacturerAsync(int manufacturerId);
        Task UpdateProductManufacturerAsync(int productId, int newManufacturerId, int modifiedBy);
        Task<List<TopSellingProductDto>> GetTopSellingProductsByCategoryAsync(DateTime startDate, DateTime endDate, int topN = 5);
        Task<ProductCompleteDTO?> GetProductByIdAsync(int productId);
        Task<ProductCompleteDTO?> UpdateProductAsync(int id, ProductUpdateDTO productDto);
        Task<ProductCompleteDTO> CreateProductAsync(ProductCreateDTO model);
        Task DeleteProductAsync(int productId, int deletedBy);
        Task<Boolean> IsProductValidAsync(int productId);
    }
}
