using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class ImageController : Controller
    {
        private readonly string _imagesFolder;
        private readonly IImageService _imageService;

        public ImageController(string imagesFolder, IImageService imageService)
        {
            _imagesFolder = imagesFolder;
            _imageService = imageService;
        }

        public async Task<IActionResult> GetImage(int productId)
        {
            var imageResult = await _imageService.GetProductImageAsync(productId);

            if (imageResult == null)
            {
                return NotFound();
            }

            return imageResult;
        }
    }
}
