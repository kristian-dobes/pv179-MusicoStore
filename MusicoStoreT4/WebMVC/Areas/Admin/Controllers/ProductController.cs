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
            // TODO use list of categories and manufacturers from the database
            // not like this tho
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            //ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");

            return View();
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

            Console.WriteLine("GET Delete product end");

            return View(product.Adapt<ProductDetailViewModel>());
        }

        // POST: Admin/Product/Delete/5
        //[ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            Console.WriteLine("Delete product start");
            
            await _productService.DeleteProductAsync(id);
            await _context.SaveChangesAsync();

            Console.WriteLine("Delete product end");

            return RedirectToAction("Index");
        }
    }
}
