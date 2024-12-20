using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Services.Interfaces;
using Mapster;
using WebMVC.Models.Product;
using BusinessLayer.DTOs.Product;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Admin/Product
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();

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

            var product = model.Adapt<ProductCreateDTO>();
            product.LastModifiedBy = User.Identity.Name; // created by the currently logged-in user

            var productResult = await _productService.CreateProductAsync(product);

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

            return View(product.Adapt<ProductUpdateViewModel>());
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

            // Retrieve the username of the currently logged-in user
            string username = User.Identity.Name;
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized("User must be authenticated to update the product.");
            }
            product.LastModifiedBy = User.Identity.Name; // created by the currently logged-in user
            
            var productResult = await _productService.UpdateProductAsync(id, product); // TODO use real username

            return View(productResult.Adapt<ProductUpdateViewModel>()); // TODO return to index
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
            await _productService.DeleteProductAsync(id);

            return RedirectToAction("Index");
        }
    }
}
