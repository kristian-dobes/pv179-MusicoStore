using BusinessLayer.DTOs.Product;
using BusinessLayer.Services;
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

        public ProductController
            (
            IProductService productService,
            IManufacturerService manufacturerService,
            ICategoryService categoryService,
            UserManager<LocalIdentityUser> userManager,
            IImageService imageService
            )
        {
            _productService = productService;
            _manufacturerService = manufacturerService;
            _categoryService = categoryService;
            _userManager = userManager;
            _imageService = imageService;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product.Adapt<ProductDetailViewModel>());
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
                Categories = categories,   // TODO sort values by name
                Manufacturers = manufacturers
            };

            return View(productCreateViewModel);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Retrieve the userId of the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User must be authenticated to create the product.");

            var product = model.Adapt<ProductCreateDTO>();
            product.LastModifiedById = user.UserId;

            await _productService.CreateProductAsync(product);

            return RedirectToAction("Index");
        }

        // GET: Admin/Product/Edit/5
        [HttpGet("edit/{id}")]
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

            productUpdateViewModel.SecondaryCategoryIds = product.SecondaryCategories.Select(c => c.CategoryId);

            productUpdateViewModel.Manufacturers = manufacturers;   // TODO sort values by name
            productUpdateViewModel.Categories = categories;

            return View(productUpdateViewModel);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _categoryService.GetCategoriesAsync();
                model.Manufacturers = await _manufacturerService.GetManufacturersAsync();
                return View(model);
                // return BadRequest(ModelState);
            }

            // Check if the PrimaryCategoryId is also in SecondaryCategoryIds
            if (model.SecondaryCategoryIds.Contains(model.PrimaryCategoryId))
            {
                ModelState.AddModelError("SecondaryCategoryIds", "The primary category cannot also be a secondary category.");

                // Reload categories and manufacturers for the view
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

            if (model.Image != null)
            {
                var imageRestult = await _imageService.ChangeOrAssignProductImageAsync(id, model.Image);

                if (!imageRestult)
                {
                    // Reload categories and manufacturers for the view
                    model.Categories = await _categoryService.GetCategoriesAsync();
                    model.Manufacturers = await _manufacturerService.GetManufacturersAsync();
                    ModelState.AddModelError("Image", "Failed to upload image.");
                    return View(model);
                }
            }

            await _productService.UpdateProductAsync(id, product);

            return RedirectToAction("Details", new { id });
        }

        // GET: Admin/Product/Delete/5
        [HttpGet("delete/{id}")]
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

            await _productService.DeleteProductAsync(id, user.UserId);

            return RedirectToAction("Index");
        }
    }
}
