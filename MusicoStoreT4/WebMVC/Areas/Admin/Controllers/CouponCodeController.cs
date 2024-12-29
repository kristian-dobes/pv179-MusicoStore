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
    public class CouponCodeController : Controller
    {
        private readonly IGiftCardService _giftCardService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public CouponCodeController(IGiftCardService giftCardService, UserManager<LocalIdentityUser> userManager)
        {
            _giftCardService = giftCardService;
            _userManager = userManager;
        }

        // GET: Admin/CouponCode/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var couponCode = await _giftCardService.GetGiftCardById(id);

            if (couponCode == null)
            {
                return NotFound();
            }

            return View(couponCode.Adapt<CouponCodeViewModel>());
        }

        // GET: Admin/CouponCode/Create
        public async Task<IActionResult> Create()
        {
            var productCreateViewModel = new CouponCodeViewModel();
            return View(productCreateViewModel);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(CouponCodeViewModel model)
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

        // GET: Admin/CouponCode/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var giftCard = await _giftCardService.GetGiftCardById(id);

            if (giftCard == null)
            {
                return NotFound();
            }

            return View(giftCard.Adapt<CouponCodeViewModel>());
        }

        // POST: Admin/CouponCode/Edit/id
        [HttpPost]
        public async Task<IActionResult> Edit(CouponCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var updateGiftCardDto = model.Adapt<UpdateGiftCardDto>();
            var giftCardResult = await _giftCardService.UpdateGiftCardAsync(updateGiftCardDto);

            return View(giftCardResult.Adapt<CouponCodeViewModel>());
        }

        // GET: Admin/CouponCode/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var giftCard = await _giftCardService.GetGiftCardById(id);

            if (giftCard == null)
                return NotFound();

            if (giftCard.CouponCodes.Count() > 0)
                return BadRequest("Gift card has coupon codes, cannot delete.");

            return View(giftCard.Adapt<CouponCodeViewModel>());
        }

        // POST: Admin/CouponCode/Delete/id
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _giftCardService.DeleteGiftCardAsync(id);

            return RedirectToAction("Index");
        }
    }
}
