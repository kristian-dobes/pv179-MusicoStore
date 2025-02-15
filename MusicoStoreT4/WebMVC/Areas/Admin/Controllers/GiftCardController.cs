﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Services.Interfaces;
using Mapster;
using DataAccessLayer.Models;
using WebMVC.Models.GiftCard;
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
            var giftCard = await _giftCardService.GetGiftCardByIdAsync(id);

            if (giftCard == null)
            {
                return NotFound();
            }

            return View(giftCard.Adapt<GiftCardViewModel>());
        }

        // GET: Admin/GiftCard/Create
        public async Task<IActionResult> Create()
        {
            var giftCardCreateViewModel = new GiftCardViewModel
            {
                ValidityStartDate = DateTime.Now,
                ValidityEndDate = DateTime.Now.AddYears(1),
                DiscountAmount = 100,
                CouponCodesCount = 5
            };
            return View(giftCardCreateViewModel);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public async Task<IActionResult> Create(GiftCardViewModel model)
        {
            model.Created = DateTime.Now;

            if (!ModelState.IsValid || model.ValidityStartDate > model.ValidityEndDate || model.ValidityEndDate < DateTime.Now || model.DiscountAmount <= 0 || model.CouponCodesCount <= 0 || model.CouponCodesCount > 100)
            {
                if (model.ValidityStartDate > model.ValidityEndDate)
                    ModelState.AddModelError("ValidityStartDate", "Start date must be before end date.");
                if (model.ValidityEndDate < DateTime.Now)
                    ModelState.AddModelError("ValidityEndDate", "End date must be in the future.");
                if (model.DiscountAmount <= 0)
                    ModelState.AddModelError("DiscountAmount", "Discount must be greater than zero.");
                if (model.CouponCodesCount <= 0)
                    ModelState.AddModelError("CouponCodesCount", "Coupon codes count must be greater than zero.");
                if (model.CouponCodesCount > 100)
                    ModelState.AddModelError("CouponCodesCount", "Coupon codes count must be less than 100. (limited for development purposes)");

                return View(model);
            }

            var giftCard = model.Adapt<CreateGiftCardDto>();

            await _giftCardService.CreateGiftCardAsync(giftCard);

            return RedirectToAction("Index");
        }

        // GET: Admin/GiftCard/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var giftCard = await _giftCardService.GetGiftCardByIdAsync(id);

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
            if (!ModelState.IsValid || model.ValidityStartDate > model.ValidityEndDate || model.ValidityEndDate < DateTime.Now)
            {
                if (model.ValidityStartDate > model.ValidityEndDate)
                    ModelState.AddModelError("ValidityStartDate", "Start date must be before end date.");
                if (model.ValidityEndDate < DateTime.Now)
                    ModelState.AddModelError("ValidityEndDate", "End date must be in the future.");

                return View(model);
            }

            var updateGiftCardDto = model.Adapt<UpdateGiftCardDto>();
            var giftCardResult = await _giftCardService.UpdateGiftCardAsync(updateGiftCardDto);

            return View(giftCardResult.Adapt<GiftCardViewModel>());
        }

        // GET: Admin/GiftCard/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var giftCard = await _giftCardService.GetGiftCardByIdAsync(id);

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
