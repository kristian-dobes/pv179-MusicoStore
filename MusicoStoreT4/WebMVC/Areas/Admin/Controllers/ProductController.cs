using BusinessLayer.DTOs.Product;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models.Product;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IManufacturerService _manufacturerService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public ProductController(IProductService productService, IManufacturerService manufacturerService, UserManager<LocalIdentityUser> userManager)
        {
            _productService = productService;
            _manufacturerService = manufacturerService;
            _userManager = userManager;
        }

        // GET: Admin/Product
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
        public IActionResult Create()
        {
            // TODO use list of available categories and manufacturers
            // not like this:
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            //ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");

            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
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

            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            //ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", product.ManufacturerId);
            return RedirectToAction("Index");
        }

        // GET: Admin/Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var manufacturers = await _manufacturerService.GetManufacturersAsync();
            if (manufacturers == null)
            {
                return NotFound();
            }

            var productUpdateViewModel = product.Adapt<ProductUpdateViewModel>();

            productUpdateViewModel.Manufacturers = manufacturers;

            return View(productUpdateViewModel);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
                // return BadRequest(ModelState);
            }

            var product = model.Adapt<ProductUpdateDTO>();

            // Retrieve the userId of the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User must be authenticated to edit the product.");
            product.LastModifiedById = user.UserId;

            var productResult = await _productService.UpdateProductAsync(id, product);

            return View(productResult.Adapt<ProductUpdateViewModel>());
        }

        // GET: Admin/Product/Delete/5
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
