using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Area.Admin.Controllers
{
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
