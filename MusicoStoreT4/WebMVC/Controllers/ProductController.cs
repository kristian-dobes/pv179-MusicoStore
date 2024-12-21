using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebMVC.Models.Product;

namespace WebMVC.Controllers
{
    [Route("products")]
    public class ProductController : Controller
    {
        private readonly UserManager<LocalIdentityUser> _userManager;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        private readonly IImageService _imageService;

        public ProductController(UserManager<LocalIdentityUser> userManager, IProductService productService,
                                 IAuditLogService auditLogService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
            _userManager = userManager;
        }

    }
}
