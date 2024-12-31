using BusinessLayer.DTOs;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Services.Interfaces
{
    public interface IImageService : IBaseService
    {
        Task<string> GetImagePathByProductIdAsync(int productId);
        Task<List<ImageDto>> GetAllProductsImagesAsync();
        Task<bool> ChangeOrAssignProductImageAsync(int productId, IFormFile newFile);
        Task<bool> DeleteProductImageAsync(int productId);
        Task<ImageDto?> GetProductImageAsync(int productId);
    }
}
