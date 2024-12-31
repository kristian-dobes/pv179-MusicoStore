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

        public ProductController(
            IProductService productService
        )
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();

            if (!products.Any())
            {
                return NotFound();
            }

            return View(products.Adapt<IEnumerable<ProductDetailViewModel>>());
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
