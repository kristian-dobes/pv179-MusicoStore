using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Product;

namespace BusinessLayer.Services.Interfaces
{
    public interface IProductService : IBaseService
    {
        Task<ProductCompleteDTO?> GetProductByIdAsync(int productId);
        Task<ProductShoppingDetailsDTO?> GetProductShoppingDetailsAsync(int productId);
        Task<IEnumerable<ProductCompleteDTO>> GetAllProductsAsync();
        Task<ProductCompleteDTO> UpdateProductAsync(int id, ProductUpdateDTO productDto);
        Task<bool> CreateProductAsync(ProductCreateDTO productDto);
        Task ReassignProductsToManufacturerAsync(int sourceManufacturerId, int destinationManufacturerId, int modifiedById);
        Task DeleteProductAsync(int productId, int deletedBy);
        Task<IEnumerable<ProductDto>> GetFilteredProductsAsync(FilterProductDto filterProductDto);
        Task<(IEnumerable<ProductDto>, int totalCount)> GetProductsPaginatedAsync(
            int page = 1,
            int pageSize = 9
        );
        Task<SearchResultDto> SearchAsync(
            string? query,
            int page = 1,
            int pageSize = 8,
            string? manufacturer = null,
            string? category = null
        );
    }
}
