using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Services.Interfaces;
using Mapster;
using WebMVC.Models.Manufacturer;
using BusinessLayer.DTOs.Manufacturer;
using DataAccessLayer.Models;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturerService;

        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
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
            var manufacturer = await _manufacturerService.GetById(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return View(manufacturer.Adapt<ManufacturerSummaryViewModel>());
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

            return RedirectToAction("Index");
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
         
            return RedirectToAction("Details", new { id });
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

            return RedirectToAction("Index");
        }
    }
}
