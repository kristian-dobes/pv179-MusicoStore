using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOs;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.Services.Interfaces
{
    public interface IImageService : IBaseService
    {
        Task<string> GetImagePathByProductIdAsync(int productId);
        Task<Product> CreateImageAsync(Product model, string createdBy);
        Task<List<FileResult>> GetAllProductsImagesAsync();
        Task<bool> ChangeOrAssignProductImageAsync(int productId, IFormFile newFile);
        Task<bool> DeleteProductImageAsync(int productId);
        Task<FileResult> GetProductImageAsync(int productId);
    }
}
