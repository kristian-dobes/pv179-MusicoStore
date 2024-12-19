﻿using BusinessLayer.DTOs;
using BusinessLayer.DTOs.Product;
using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMVC.Models.Product;

namespace WebMVC.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IAuditLogService _auditLogService;
        private readonly IUserService _userService;

        public ProductController(IProductService productService, IAuditLogService auditLogService, IUserService userService)
        {
            _productService = productService;
            _auditLogService = auditLogService;
            _userService = userService;
        }

        [HttpGet("list")]
        [AllowAnonymous]
        public async Task<IActionResult> List()
        {
            var products = await _productService.GetProducts();

            if (!products.Any())
            {
                return NotFound();
            }

            foreach (var product in products)
            {
                Console.WriteLine("PRODUCT ID :" + product.ProductId);
            }

            return View(products.Adapt<IEnumerable<ProductSummaryViewModel>>());
        }

        //// posts/detail/id
        ////       detail?id=...
        //[HttpGet("detail/{id:int}")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Detail(int id)
        //{
        //    var product = await _productService.GetProductByIdAsync(id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product.Adapt<ProductDetailViewModel>());
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var product = await _productService.GetProductByIdAsync(id);

        //    if (product == null)
        //        return NotFound();

        //    return View(product.Adapt<ProductUpdateViewModel>());
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, Product model)
        //{
        //    if (id != model.Id)
        //        return BadRequest();

        //    var existingProduct = await _productService.GetProductByIdAsync(id);
            
        //    if (existingProduct == null)
        //        return NotFound();

        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    // TODO user real user, probably remove, since customers cant edit products
        //    await _productService.UpdateProductAsync(model, userId, "UserTODO");
        //    var action = "Update";
        //    await _auditLogService.LogAsync(model.Id, action, int.Parse(userId));

        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(Product model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //        var createdProduct = await _productService.CreateProductAsync(model, userId);
        //        var action = "Create";
        //        await _auditLogService.LogAsync(createdProduct.Id, action, int.Parse(userId));

        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var product = await _productService.GetProductByIdAsync(id);

        //    if (product == null)
        //        return NotFound();

        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the user ID from the claims
        //    var action = "Delete"; // Action type (CRUD)
        //    await _auditLogService.LogAsync(product.ProductId, action, int.Parse(userId));
        //    await _productService.DeleteProductAsync(id, userId);

        //    return RedirectToAction("Index");
        //}
    }
}
