using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;

namespace WebMVC.ViewComponents
{
    public class UserMenuViewComponent : ViewComponent
    {
        private readonly SignInManager<LocalIdentityUser> _signInManager;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public UserMenuViewComponent(SignInManager<LocalIdentityUser> signInManager, UserManager<LocalIdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!_signInManager.IsSignedIn(HttpContext.User))
            {
                return View("LoggedOutMenu");
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var isAdmin = user != null && await _userManager.IsInRoleAsync(user, "Admin");
            var userName = await _userManager.GetUserNameAsync(user);

            return View("LoggedInMenu", new UserMenuViewModel
            {
                IsAdmin = isAdmin,
                UserName = userName
            });
        }
    }
}
