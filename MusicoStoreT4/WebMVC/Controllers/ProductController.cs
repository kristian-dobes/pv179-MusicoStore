using BusinessLayer.DTOs.Product;
using BusinessLayer.Enums;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IProductService _productService;
        private readonly IAuditLogService _auditLogService;
        private readonly IUserService _userService;

        public ProductController(UserManager<LocalIdentityUser> userManager, IProductService productService,
                                 IAuditLogService auditLogService, IUserService userService)
        {
            _productService = productService;
            _auditLogService = auditLogService;
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Show(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateProductDTO productDto)
        {
            if (id != productDto.Id)
                return BadRequest();

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            var existingProduct = await _productService.GetProductByIdAsync(id);
            
            if (existingProduct == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _productService.UpdateProductAsync(productDto, user.UserId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDTO productDto)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var createdProduct = await _productService.CreateProductAsync(productDto, user.UserId);

                return RedirectToAction("Index");
            }

            return View(productDto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            await _productService.DeleteProductAsync(id, user.UserId);
            return RedirectToAction("Index");
        }
    }
}
