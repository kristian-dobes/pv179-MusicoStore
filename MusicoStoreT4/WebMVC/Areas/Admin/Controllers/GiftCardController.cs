using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Services.Interfaces;
using Mapster;
using WebMVC.Models.Manufacturer;
using BusinessLayer.DTOs.Manufacturer;
using DataAccessLayer.Models;
using WebMVC.Models.GiftCard;
using BusinessLayer.Services;
using WebMVC.Models.Product;
using Microsoft.AspNetCore.Identity;
using BusinessLayer.DTOs.GiftCard;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GiftCardController : Controller
    {
        private readonly IGiftCardService _giftCardService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public GiftCardController(IGiftCardService giftCardService, UserManager<LocalIdentityUser> userManager)
        {
            _giftCardService = giftCardService;
            _userManager = userManager;
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

        // GET: Admin/GiftCard/Create
        public async Task<IActionResult> Create()
        {
            var productCreateViewModel = new GiftCardViewModel();
            return View(productCreateViewModel);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(GiftCardViewModel model)
        {
            model.Created = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized("User must be authenticated to create the product.");

            var giftCard = model.Adapt<CreateGiftCardDto>();

            await _giftCardService.CreateGiftCardAsync(giftCard);

            return RedirectToAction("Index");
        }

        // GET: Admin/GiftCard/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var giftCard = await _giftCardService.GetById(id);

            if (giftCard == null)
            {
                return NotFound();
            }

            return View(giftCard.Adapt<GiftCardViewModel>());
        }

        // POST: Admin/GiftCard/Edit/id
        [HttpPost]
        public async Task<IActionResult> Edit(GiftCardViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var updateGiftCardDto = model.Adapt<UpdateGiftCardDto>();
            var giftCardResult = await _giftCardService.UpdateGiftCardAsync(updateGiftCardDto);

            return View(giftCardResult.Adapt<GiftCardViewModel>());
        }

        // GET: Admin/GiftCard/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var giftCard = await _giftCardService.GetById(id);

            if (giftCard == null)
                return NotFound();

            if (giftCard.CouponCodes.Count() > 0)
                return BadRequest("Gift card has coupon codes, cannot delete.");

            return View(giftCard.Adapt<GiftCardViewModel>());
        }

        // POST: Admin/GiftCard/Delete/id
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _giftCardService.DeleteGiftCardAsync(id);

            return RedirectToAction("Index");
        }
    }
}
