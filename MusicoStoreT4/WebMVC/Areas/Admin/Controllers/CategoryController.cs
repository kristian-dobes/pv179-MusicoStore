using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Services.Interfaces;
using Mapster;
using BusinessLayer.DTOs.Category;
using WebMVC.Models.Category;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Models;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public CategoryController(ICategoryService categoryService, UserManager<LocalIdentityUser> userManager)
        {
            _categoryService = categoryService;
            _userManager = userManager;
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
            var category = await _categoryService.GetCategoryWithProductsAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category.Adapt<CategoryProductsViewModel>());
        }

        // GET: Admin/Category/Create
        public IActionResult Create()
        {
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

            var category = model.Adapt<CategoryUpdateDTO>();

            await _categoryService.CreateCategory(category);

            return RedirectToAction("Index", new { area = "Admin" });
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category.Adapt<CategoryNameViewModel>());
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = model.Adapt<CategoryUpdateDTO>();
            await _categoryService.UpdateCategoryAsync(id, category);

            return RedirectToAction("Details", "Category", new { area = "Admin", id });
        }

        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            if (category.PrimaryProductCount > 0)
                return BadRequest("Category has products, cannot delete.");

            return View(category.Adapt<CategorySummaryViewModel>());
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            return RedirectToAction("Index", new { area = "Admin" });
        }

        // GET: Admin/Category/Merge
        public async Task<IActionResult> Merge()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            if (!categories.Any())
                return NotFound();

            var mergeViewModel = new CategoryMergeViewModel
            {
                Categories = categories
            };

            return View(mergeViewModel);
        }

        // POST: Admin/Category/Merge
        [HttpPost]
        public async Task<IActionResult> Merge(CategoryMergeViewModel model)
        {
            if (!ModelState.IsValid || model.SourceCategoryId1 == model.SourceCategoryId2)
            {
                var categories = await _categoryService.GetCategoriesAsync(); // reload categories for dropdown
                model.Categories = categories;

                return View(model);
            }

            // Retrieve the userId of the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User must be authenticated to delete the product.");

            await _categoryService.MergeCategoriesAndCreateNewAsync(model.NewCategoryName, model.SourceCategoryId1, model.SourceCategoryId2, user.UserId);
           
            //return RedirectToAction("Details", new { id = newCategory.Id });
            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}
