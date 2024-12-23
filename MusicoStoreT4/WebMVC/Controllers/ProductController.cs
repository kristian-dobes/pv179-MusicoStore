using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebMVC.Models.Product;

namespace WebMVC.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IImageService _imageService;

        public ProductController(UserManager<LocalIdentityUser> userManager, IUserService userService, IProductService productService, IImageService imageService)
        {
            _productService = productService;
            _userService = userService;
            _userManager = userManager;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Show(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }


        //public async Task<IActionResult> ProductDetails(int productId)
        //{
        //    var product = await _productService.GetProductByIdAsync(productId);

        //    if (product == null)
        //        return NotFound();

        //    string imageFilePath = await _imageService.GetImagePathByProductIdAsync(productId);

        //    var productViewModel = new ProductDetailViewModel
        //    {
        //        Id = product.ProductId,
        //        Name = product.Name,
        //        Description = product.Description,
        //        Price = product.Price,
        //        //ImageFilePath = imageFilePath
        //    };

        //    return View(productViewModel);
        //}
    }
}
