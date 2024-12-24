using System.Security.Claims;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVC.Models.Category;
using WebMVC.Models.Manufacturer;
using WebMVC.Models.Product;
using WebMVC.Models.Shared;

namespace WebMVC.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IImageService _imageService;

        public ProductController(
            UserManager<LocalIdentityUser> userManager,
            IUserService userService,
            IProductService productService,
            IImageService imageService
        )
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

        [HttpGet("list")]
        [AllowAnonymous]
        public async Task<IActionResult> List(int page = 1, int pageSize = 10)
        {
            var (products, totalCount) = await _productService.GetProductsAsync(page, pageSize);

            if (!products.Any())
            {
                return NotFound();
            }

            var viewModel = new ProductListViewModel
            {
                Products = products.Adapt<IEnumerable<ProductDetailViewModel>>(),
                CurrentPage = page,
                // we need to get the upper number of pages ... therefore
                // this of this is is 11 posts were returned, we wish to change `1.1` (result) to `2`
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
            };

            return View(viewModel);
        }

        [HttpGet("search")]
        [AllowAnonymous]
        public async Task<IActionResult> Search(
            string query,
            int page = 1,
            string? manufacturer = null,
            string? category = null
        )
        {
            const int pageSize = 5;

            // If query is empty and no category or manufacturer is selected, return to search page
            if (
                string.IsNullOrWhiteSpace(query)
                && string.IsNullOrWhiteSpace(category)
                && string.IsNullOrWhiteSpace(manufacturer)
            )
            {
                ModelState.AddModelError("", "Search query cannot be empty.");
                return Redirect(Request.Headers["Referer"].ToString());
            }
            var searchResults = await _productService.SearchAsync(
                query,
                page,
                pageSize,
                manufacturer,
                category
            );

            var viewModel = new SearchProductListViewModel
            {
                Products = searchResults.Products.Adapt<IEnumerable<ProductDetailViewModel>>(),
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling((double)searchResults.TotalProductCount / pageSize),
                Manufacturers = searchResults.Manufacturers.Adapt<
                    IEnumerable<ManufacturerViewModel>
                >(),
                Categories = searchResults.Categories.Adapt<IEnumerable<CategoryViewModel>>(),
                SearchParams = new SearchViewModel
                {
                    Query = query,
                    Category = category,
                    Manufacturer = manufacturer
                }
            };

            return View("SearchResult", viewModel);
        }
    }
}
