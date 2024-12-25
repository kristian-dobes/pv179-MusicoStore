using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;
using WebMVC.Models.Product;

namespace WebMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IImageService _imageService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IImageService imageService)
        {
            _logger = logger;
            _productService = productService;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index()
        {
            int productId = 3;
            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null)
                return NotFound();

            var productHomeViewModel = new ProductHomeViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageFilePath = await _imageService.GetImagePathByProductIdAsync(productId)
            };

            return View(productHomeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
