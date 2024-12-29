using BusinessLayer.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models.Category;
using WebMVC.Models.Manufacturer;
using WebMVC.Models.Product;
using WebMVC.Models.Shared;

namespace WebMVC.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;

        public ProductController(
            IProductService productService,
            IImageService imageService
        )
        {
            _productService = productService;
            _imageService = imageService;
        }

        [HttpGet("detailz/{id}")]
        public async Task<IActionResult> Detailz(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            string imageFilePath = await _imageService.GetImagePathByProductIdAsync(id);

            var productViewModel = product.Adapt<ProductDetailViewModel>();
            productViewModel.ImageFilePath = imageFilePath;

            return View(productViewModel);
        }

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
