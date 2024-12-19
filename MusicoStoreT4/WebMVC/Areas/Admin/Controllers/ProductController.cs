using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Services.Interfaces;
using Mapster;
using WebMVC.Models.Product;
using BusinessLayer.Services;
using System.Security.Claims;
using BusinessLayer.DTOs.Product;
using Microsoft.AspNetCore.Identity;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly MyDBContext _context; // TODO REMOVE ANY REFERENCES TO THIS
        private readonly IProductService _productService;

        public ProductController(MyDBContext context, IProductService productService)
        {
            _context = context;
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
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            //ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");

            Console.WriteLine("First Create product return View");

            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            Console.WriteLine("Second Create product start");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = model.Adapt<ProductCreateDTO>();
            product.LastModifiedBy = User.Identity.Name; // created by the currently logged-in user

            var productResult = await _productService.CreateProductAsync(product);

            Console.WriteLine("Third Create product end");

            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            //ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", product.ManufacturerId);
            return RedirectToAction(nameof(Index));
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
        //[ValidateAntiForgeryToken]
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

            var productResult = await _productService.UpdateProductAsync(id, product, username); // TODO use real username

            return View(productResult.Adapt<ProductUpdateViewModel>());
        }

        // GET: Admin/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
