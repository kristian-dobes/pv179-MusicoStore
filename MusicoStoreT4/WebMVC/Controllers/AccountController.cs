using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models.Account;
using WebMVC.Models.Product;

namespace WebMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly SignInManager<LocalIdentityUser> _signInManager;
        private readonly IUserService _userService;

        public AccountController(
            UserManager<LocalIdentityUser> userManager,
            SignInManager<LocalIdentityUser> signInManager,
            IUserService userService
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new LocalIdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    User = new() { Username = model.Email, Email = model.Email }
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (model.IsAdmin)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    // return RedirectToAction("Login", "Account");
                    return RedirectToAction(nameof(Index), nameof(HomeController).Replace("Controller", ""));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe,
                    lockoutOnFailure: false
                );

                if (result.Succeeded)
                {
                    // return RedirectToAction("LoginSuccess", "Account");
                    return RedirectToAction(
                        nameof(LoginSuccess),
                        nameof(AccountController).Replace("Controller", "")
                    );
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [Route("/Account/LogOut")] // Shared route (Can logout from other Areas, eg. Admin)
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(
                nameof(LogoutSuccess),
                nameof(AccountController).Replace("Controller", "")
            );
        }

        public IActionResult LogoutSuccess()
        {
            return View();
        }

        public IActionResult LoginSuccess()
        {
            return View();
        }

        public async Task<IActionResult> MostBoughtProduct()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.User == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var productDto = await _userService.GetMostFrequentBoughtItemAsync(user.UserId);

            if (productDto == null)
                return View(null); // Return an empty view if no product found

            var viewModel = new MostBoughtProductViewModel
            {
                ProductId = productDto.ProductId,
                Name = productDto.Name,
                Description = productDto.Description,
                NumberOfBuys = productDto.NumberOfBuys
            };

            return View(viewModel);
        }
    }
}
