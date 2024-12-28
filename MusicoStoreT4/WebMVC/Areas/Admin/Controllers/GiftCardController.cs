using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Services.Interfaces;
using Mapster;
using WebMVC.Models.Manufacturer;
using BusinessLayer.DTOs.Manufacturer;
using DataAccessLayer.Models;
using WebMVC.Models.GiftCard;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GiftCardController : Controller
    {
        private readonly IGiftCardService _giftCardService;

        public GiftCardController(IGiftCardService giftCardService)
        {
            _giftCardService = giftCardService;
        }

        // GET: Admin/GiftCard
        public async Task<IActionResult> Index()
        {
            var giftCards = await _giftCardService.GetGiftCardsAsync();

            if (!giftCards.Any())
            {
                return NotFound();
            }

            List<GiftCardViewModel> a = giftCards.Select(gc => gc.Adapt<GiftCardViewModel>()).ToList();

            return base.View(a);
        }

        // GET: Admin/GiftCard/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var giftCard = await _giftCardService.GetById(id);

            if (giftCard == null)
            {
                return NotFound();
            }

            return View(giftCard.Adapt<GiftCardViewModel>());
        }

        /*
        // GET: Admin/GiftCard/Create
        public IActionResult Create()
        {
            // TODO use list of available categories and manufacturers
            // not like this:
            //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            //ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");

            return View();
        }

        // POST: Admin/GiftCard/Create
        [HttpPost]
        public async Task<IActionResult> Create(ManufacturerNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manufacturer = model.Adapt<ManufacturerUpdateDTO>();

            await _giftCardService.CreateManufacturerAsync(manufacturer);

            return RedirectToAction("Index");
        }

        // GET: Admin/GiftCard/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var manufacturer = await _giftCardService.GetById(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            // using CreateViewModel for Edit as well, as they are the same
            return View(manufacturer.Adapt<ManufacturerNameViewModel>());
        }

        // POST: Admin/GiftCard/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ManufacturerNameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
                // return BadRequest(ModelState);
            }

            var manufacturer = model.Adapt<ManufacturerUpdateDTO>();

            var manufacturerResult = await _giftCardService.UpdateManufacturerAsync(id, manufacturer);

            return View(manufacturerResult.Adapt<ManufacturerNameViewModel>());
        }

        // GET: Admin/GiftCard/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var manufacturer = await _giftCardService.GetById(id);

            if (manufacturer == null)
                return NotFound();

            if (manufacturer.ProductCount > 0)
                return BadRequest("Manufacturer has products, cannot delete.");

            return View(manufacturer.Adapt<ManufacturerSummaryViewModel>());
        }

        // POST: Admin/GiftCard/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _giftCardService.DeleteManufacturerAsync(id);

            return RedirectToAction("Index");
        }
        */
    }
}
