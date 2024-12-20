using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAuditLogService _auditLogService;
        private readonly IUserService _userService;
        private readonly IImageService _imageService;

        public ProductController(IProductService productService, IAuditLogService auditLogService, IUserService userService, IImageService imageService)
        {
            _productService = productService;
            _auditLogService = auditLogService;
            _userService = userService;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product model)
        {
            if (id != model.Id)
                return BadRequest();

            var existingProduct = await _productService.GetProductByIdAsync(id);
            
            if (existingProduct == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _productService.UpdateProductAsync(model, userId);
            var action = "Update";
            await _auditLogService.LogAsync(model.Id, action, int.Parse(userId));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var createdProduct = await _productService.CreateProductAsync(model, userId);
                var action = "Create";
                await _auditLogService.LogAsync(createdProduct.Id, action, int.Parse(userId));

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the user ID from the claims
            var action = "Delete"; // Action type (CRUD)
            await _auditLogService.LogAsync(product.Id, action, int.Parse(userId));
            await _productService.DeleteProductAsync(id, userId);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ProductDetails(int productId)
        {
            Product product = await _productService.GetProductByIdAsync(productId);

            if (product == null)
                return NotFound();

            string imageFilePath = await _imageService.GetImagePathByProductIdAsync(productId);

            var productViewModel = new ProductViewModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageFilePath = imageFilePath
            };

            return View(productViewModel);
        }
    }
}
