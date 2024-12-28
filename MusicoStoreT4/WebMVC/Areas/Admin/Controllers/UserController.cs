using BusinessLayer.DTOs.Auth;
using BusinessLayer.DTOs.User;
using BusinessLayer.Facades.Interfaces;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebMVC.Models.User;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthFacade _authFacade;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public UserController(IUserService userService, IAuthFacade authFacade, UserManager<LocalIdentityUser> userManager)
        {
            _userService = userService;
            _authFacade = authFacade;
            _userManager = userManager;
        }

        // GET: Admin/User
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();

            if (!users.Any())
            {
                return NotFound();
            }

            return View(users.Adapt<IEnumerable<UserSummaryViewModel>>());
        }

        // GET: Admin/User/ResetPassword/5
        public async Task<IActionResult> ResetPassword(int id)
        {
            var userToResetPasswordTo = await _userService.GetUserByIdAsync(id);
            if (userToResetPasswordTo == null)
                return View("Index");

            var viewModel = new UserResetPasswordViewModel 
            { 
                UserToReset = new UserSummaryDTO
                {
                    UserId = userToResetPasswordTo.UserId,
                    Email = userToResetPasswordTo.Email,
                    Username = userToResetPasswordTo.Username,
                    NumberOfOrders = 0
                }
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(int id, UserResetPasswordViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            // Retrieve the userId of the currently logged-in user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized("User must be authenticated to manage passwords.");

            var dto = new PasswordResetDto
            {
                ChangedByUserId = user.UserId,
                UserId = id,
                NewPassword = model.NewPassword
            };

            var authenticationResult = await _authFacade.ResetUserPassword(dto);

            if (!authenticationResult.Succeeded)
            {
                foreach (var error in authenticationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model); // Re-render view with validation errors
            }

            return RedirectToAction("Index");
        }
    }
}
