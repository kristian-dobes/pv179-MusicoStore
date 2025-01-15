using BusinessLayer.Cache;
using BusinessLayer.Cache.Interfaces;
using BusinessLayer.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        private readonly IMemoryCacheWrapper _cacheWrapper;
        private static readonly CacheOptions CacheOptions =
            new(
                AbsoluteExpiration: TimeSpan.FromHours(12),
                SlidingExpiration: TimeSpan.FromMinutes(30)
            );

        public ProductController(IProductService productService, IMemoryCacheWrapper cacheWrapper)
        {
            _productService = productService;
            _cacheWrapper = cacheWrapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 1)
        {
            const int pageSize = 9;
            string cacheKey = CacheKeys.GetProductListKey(page);

            var viewModel = await _cacheWrapper.GetOrCreateAsync(
                cacheKey,
                async () =>
                {
                    var (products, totalCount) = await _productService.GetProductsPaginatedAsync(
                        page,
                        pageSize
                    );

                    if (!products.Any())
                    {
                        return null;
                    }

                    return new ProductListViewModel
                    {
                        Products = products.Adapt<IEnumerable<ProductDetailViewModel>>(),
                        CurrentPage = page,
                        TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
                    };
                },
                CacheOptions
            );

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet("details/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await _cacheWrapper.GetOrCreateAsync(
                CacheKeys.GetProductDetailsKey(id),
                async () =>
                {
                    var product = await _productService.GetProductByIdAsync(id);
                    return product?.Adapt<ProductDetailViewModel>();
                },
                CacheOptions
            );

            if (viewModel == null)
                return NotFound();

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
            const int pageSize = 8;

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
