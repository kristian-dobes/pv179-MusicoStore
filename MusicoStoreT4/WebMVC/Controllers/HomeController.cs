using System.Diagnostics;
using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Models.Product;

namespace WebMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(
            IProductService productService
        )
        {
            _productService = productService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            int productId = 3; // Featured product is hardcoded for now
            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null)
                return View(new ProductHomeViewModel { IsValid = false });

            var productHomeViewModel = new ProductHomeViewModel
            {
                IsValid = true,
                ProductId = product.ProductId,
                ProductName = product.Name,
                Description = product.Description,
                Price = product.Price,
                PrimaryCategory = product.PrimaryCategoryName,
                ImageFilePath = product.ImageFilePath ?? string.Empty
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
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}
