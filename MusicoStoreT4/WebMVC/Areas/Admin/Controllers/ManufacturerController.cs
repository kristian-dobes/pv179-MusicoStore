using BusinessLayer.DTOs.Manufacturer;
using BusinessLayer.Facades.Interfaces;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models.Manufacturer;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IManufacturerFacade _manufacturerFacade;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public ManufacturerController(IManufacturerService manufacturerService, IManufacturerFacade manufacturerFacade, UserManager<LocalIdentityUser> userManager)
        {
            _manufacturerService = manufacturerService;
            _manufacturerFacade = manufacturerFacade;
            _userManager = userManager;
        }

        // GET: Admin/Manufacturer
        public async Task<IActionResult> Index()
        {
            var manufacturers = await _manufacturerService.GetManufacturersAsync();

            if (!manufacturers.Any())
            {
                return NotFound();
            }

            return View(manufacturers.Adapt<IEnumerable<ManufacturerSummaryViewModel>>());
        }

        // GET: Admin/Manufacturer/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //var manufacturer = await _manufacturerService.GetById(id);

            //if (manufacturer == null)
            //{
            //    return NotFound();
            //}

            //return View(manufacturer.Adapt<ManufacturerSummaryViewModel>());

            var manufacturer = await _manufacturerService.GetManufacturerWithProductsAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer.Adapt<ManufacturerProductsViewModel>());
        }

        // GET: Admin/Manufacturer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Manufacturer/Create
        [HttpPost]
        public async Task<IActionResult> Create(ManufacturerNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manufacturer = model.Adapt<ManufacturerUpdateDTO>();

            await _manufacturerService.CreateManufacturerAsync(manufacturer);

            return RedirectToAction("Index", new { area = "Admin" });
        }

        // GET: Admin/Manufacturer/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var manufacturer = await _manufacturerService.GetById(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer.Adapt<ManufacturerNameViewModel>());
        }

        // POST: Admin/Manufacturer/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ManufacturerNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
                // return BadRequest(ModelState);
            }

            var manufacturer = model.Adapt<ManufacturerUpdateDTO>();
            await _manufacturerService.UpdateManufacturerAsync(id, manufacturer);
         
            return RedirectToAction("Details", "Manufacturer", new { area = "Admin", id });
        }

        // GET: Admin/Manufacturer/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var manufacturer = await _manufacturerService.GetById(id);

            if (manufacturer == null)
                return NotFound();

            if (manufacturer.ProductCount > 0)
                return BadRequest("Manufacturer has products, cannot delete.");

            return View(manufacturer.Adapt<ManufacturerSummaryViewModel>());
        }

        // POST: Admin/Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _manufacturerService.DeleteManufacturerAsync(id);

            return RedirectToAction("Index", new { area = "Admin" });
        }

        // GET: Admin/Manufacturer/Merge
        public async Task<IActionResult> Merge()
        {
            var manufacturers = await _manufacturerService.GetManufacturersAsync();

            if (!manufacturers.Any())
            {
                return NotFound();
            }

            var mergeViewModel = new ManufacturerMergeViewModel
            {
                Manufacturers = manufacturers
            };

            return View(mergeViewModel);
        }

        // POST: Admin/Manufacturer/Merge
        [HttpPost]
        public async Task<IActionResult> Merge(ManufacturerMergeViewModel model)
        {
            if (!ModelState.IsValid || model.SourceManufacturerId == model.DestinationManufacturerId)
            {
                var manufacturers = await _manufacturerService.GetManufacturersAsync(); // reload manufacturers for dropdown
                model.Manufacturers = manufacturers;

                return View(model);
            }

            // Retrieve the userId of the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User must be authenticated to delete the product.");

            await _manufacturerFacade.MergeManufacturersAsync(model.SourceManufacturerId, model.DestinationManufacturerId, user.UserId);
            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}
