using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Services.Interfaces;
using Mapster;
using BusinessLayer.DTOs.Category;
using WebMVC.Models.Category;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Admin/Category
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            if (!categories.Any())
            {
                return NotFound();
            }

            return View(categories.Adapt<IEnumerable<CategorySummaryViewModel>>());
        }

        // GET: Admin/Category/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category.Adapt<CategorySummaryViewModel>());
        }

        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            // TODO use list of available categories and categories
            // not like this:
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");

            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public async Task<IActionResult> Create(CategoryNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = model.Adapt<CategoryNameDTO>();

            var categoryResult = await _categoryService.CreateCategoryAsync(category);

            return RedirectToAction("Index");
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            // using CreateViewModel for Edit as well, as they are the same
            return View(category.Adapt<CategoryNameViewModel>());
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
                // return BadRequest(ModelState);
            }

            var category = model.Adapt<CategoryNameDTO>();

            var categoryResult = await _categoryService.UpdateCategoryAsync(id, category);

            return View(categoryResult.Adapt<CategoryNameViewModel>());
        }

        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            if (category.ProductCount > 0)
            {
                return BadRequest("Category has products, cannot delete.");
            }

            return View(category.Adapt<CategorySummaryViewModel>());
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            return RedirectToAction("Index");
        }
    }
}
