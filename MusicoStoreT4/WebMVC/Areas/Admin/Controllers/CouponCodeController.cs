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
using BusinessLayer.DTOs.CouponCode;

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
            var couponCode = await _giftCardService.GetCouponCodeByIdAsync(id);

            
            Console.WriteLine("ORDERRRRRR"+couponCode.OrderId);

            if (couponCode == null)
            {
                return NotFound();
            }

            return View(couponCode.Adapt<CouponCodeViewModel>());
        }

        // GET: Admin/CouponCode/Create
        public async Task<IActionResult> Create(int giftCardId)
        {
            var couponCodeViewModel = new CouponCodeViewModel();
            ViewBag.GiftCardId = giftCardId;
            return View(couponCodeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CouponCodeViewModel model, int giftCardId)
        {
            model.Created = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized("User must be authenticated to create the coupon code.");
            }

            CreateCouponCodeDto createCouponCodeDto = new()
            {
                Code = model.Code,
                GiftCardId = giftCardId,
            };

            await _giftCardService.CreateCouponCodeAsync(createCouponCodeDto);
            return RedirectToAction("Index", "GiftCard");
        }

        // GET: Admin/CouponCode/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var couponCode = await _giftCardService.GetCouponCodeByIdAsync(id);

            if (couponCode == null)
            {
                return NotFound();
            }

            return View(couponCode.Adapt<CouponCodeViewModel>());
        }

        // POST: Admin/CouponCode/Edit/id
        [HttpPost]
        public async Task<IActionResult> Edit(CouponCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var updateCouponCodeDto = model.Adapt<UpdateCouponCodeDto>();
            var CouponCodeResult = await _giftCardService.UpdateCouponCodeAsync(updateCouponCodeDto);

            return View(CouponCodeResult.Adapt<CouponCodeViewModel>());
        }

        // GET: Admin/CouponCode/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var couponCode = await _giftCardService.GetCouponCodeByIdAsync(id);

            if (couponCode == null)
                return NotFound();

            return View(couponCode.Adapt<CouponCodeViewModel>());
        }

        // POST: Admin/CouponCode/Delete/id
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _giftCardService.DeleteCouponCodeAsync(id);

            return RedirectToAction("Index", "GiftCard");
        }
    }
}
