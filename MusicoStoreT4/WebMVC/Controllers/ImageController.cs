using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<IActionResult> GetImage(int productId)
        {
            var imageDto = await _imageService.GetProductImageAsync(productId);

            if (imageDto == null)
            {
                return NotFound(new { Message = "Image not found for this product." });
            }

            return File(imageDto.FileContents, imageDto.MimeType, imageDto.FileName);
        }
    }
}
