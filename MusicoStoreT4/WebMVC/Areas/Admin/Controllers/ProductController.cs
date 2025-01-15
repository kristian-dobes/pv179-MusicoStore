using BusinessLayer.Cache;
using BusinessLayer.Cache.Interfaces;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using WebMVC.Models.Product;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IManufacturerService _manufacturerService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IImageService _imageService;
        private readonly IMemoryCacheWrapper _cacheWrapper;
        private static readonly CacheOptions CacheOptions =
            new(
                AbsoluteExpiration: TimeSpan.FromHours(12),
                SlidingExpiration: TimeSpan.FromMinutes(30)
            );

        public ProductController(
            IProductService productService,
            IManufacturerService manufacturerService,
            ICategoryService categoryService,
            UserManager<LocalIdentityUser> userManager,
            IImageService imageService,
            IMemoryCacheWrapper cacheWrapper
        )
        {
            _productService = productService;
            _manufacturerService = manufacturerService;
            _categoryService = categoryService;
            _userManager = userManager;
            _imageService = imageService;
            _cacheWrapper = cacheWrapper;
        }

        // GET: Admin/Product
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

        // GET: Admin/Product/Details/5
        [HttpGet]
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

        // GET: Admin/Product/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var manufacturers = await _manufacturerService.GetManufacturersAsync();
            if (manufacturers == null)
                return NotFound();

            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null)
                return NotFound();

            var productCreateViewModel = new ProductCreateViewModel()
            {
                Categories = categories, // TODO sort values by name
                Manufacturers = manufacturers
            };

            return View(productCreateViewModel);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (
                !ModelState.IsValid
                || (
                    model.SecondaryCategoryIds != null
                        && model.SecondaryCategoryIds.Contains(model.PrimaryCategoryId)
                    || model.Price == 0
                )
            )
            {
                if (model.Price == 0)
                    ModelState.AddModelError("Price", "Price cannot be 0.");

                if (
                    model.SecondaryCategoryIds != null
                    && model.SecondaryCategoryIds.Contains(model.PrimaryCategoryId)
                )
                    ModelState.AddModelError(
                        "SecondaryCategoryIds",
                        "The primary category cannot also be a secondary category."
                    );

                // Reload categories and manufacturers for the view
                model.Categories = await _categoryService.GetCategoriesAsync();
                model.Manufacturers = await _manufacturerService.GetManufacturersAsync();
                return View(model);
            }

            // Retrieve the userId of the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User must be authenticated to create the product.");

            var product = model.Adapt<ProductCreateDTO>();
            product.LastModifiedById = user.UserId;

            var result = await _productService.CreateProductAsync(product);

            if (!result)
            {
                ModelState.AddModelError(
                    "Name",
                    "Failed to create product. Product name is already taken"
                );
                model.Categories = await _categoryService.GetCategoriesAsync();
                model.Manufacturers = await _manufacturerService.GetManufacturersAsync();
                return View(model);
            }

            InvalidateProductCache();

            return RedirectToAction("Index", new { area = "Admin" });
        }

        // GET: Admin/Product/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            var manufacturers = await _manufacturerService.GetManufacturersAsync();
            if (manufacturers == null)
                return NotFound();

            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null)
                return NotFound();

            var productUpdateViewModel = product.Adapt<ProductUpdateViewModel>();
            productUpdateViewModel.Manufacturers = manufacturers; // TODO sort values by name
            productUpdateViewModel.Categories = categories;

            return View(productUpdateViewModel);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductUpdateViewModel model)
        {
            if (
                !ModelState.IsValid
                || model.SecondaryCategoryIds.Contains(model.PrimaryCategoryId)
                || model.Price == 0
            )
            {
                if (model.Price == 0)
                    ModelState.AddModelError("Price", "Price cannot be 0.");
                if (model.SecondaryCategoryIds.Contains(model.PrimaryCategoryId))
                    ModelState.AddModelError(
                        "SecondaryCategoryIds",
                        "The primary category cannot also be a secondary category."
                    );

                model.Categories = await _categoryService.GetCategoriesAsync();
                model.Manufacturers = await _manufacturerService.GetManufacturersAsync();
                return View(model);
            }

            var product = model.Adapt<ProductUpdateDTO>();
            product.SecondaryCategoryIds = model.SecondaryCategoryIds;

            // Retrieve the userId of the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User must be authenticated to edit the product.");
            product.LastModifiedById = user.UserId;

            // Image handling
            if (model.DeleteImage)
            {
                var deleteResult = await _imageService.DeleteProductImageAsync(id);

                if (!deleteResult)
                {
                    ModelState.AddModelError("Image", "Failed to delete image.");
                    model.Categories = await _categoryService.GetCategoriesAsync();
                    model.Manufacturers = await _manufacturerService.GetManufacturersAsync();
                    return View(model);
                }
            }
            else if (model.Image != null)
            {
                var imageRestult = await _imageService.ChangeOrAssignProductImageAsync(
                    id,
                    model.Image
                );

                if (!imageRestult)
                {
                    ModelState.AddModelError("Image", "Failed to upload image.");
                    model.Categories = await _categoryService.GetCategoriesAsync();
                    model.Manufacturers = await _manufacturerService.GetManufacturersAsync();
                    return View(model);
                }
            }

            await _productService.UpdateProductAsync(id, product);

            InvalidateProductCache(id);

            return RedirectToAction("Details", "Product", new { area = "Admin", id });
        }

        // GET: Admin/Product/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product.Adapt<ProductDetailViewModel>());
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            // Retrieve the userId of the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User must be authenticated to delete the product.");

            await _imageService.DeleteProductImageAsync(id);
            await _productService.DeleteProductAsync(id, user.UserId);

            InvalidateProductCache(id);

            return RedirectToAction("Index", new { area = "Admin" });
        }

        private void InvalidateProductCache(int? productId = null)
        {
            var keysToInvalidate = CacheKeys.GetAllProductListKeys().ToList();

            // Invalidate all product list pages
            foreach (var key in keysToInvalidate)
            {
                _cacheWrapper.Invalidate(key);
                CacheKeys.RemoveKey(key);
            }

            // Invalidate specific product details if provided
            if (productId.HasValue)
            {
                string key = CacheKeys.GetProductDetailsKey(productId.Value);
                _cacheWrapper.Invalidate(key);
                CacheKeys.RemoveKey(key);
            }
        }
    }
}
