using BusinessLayer.DTOs.Order;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models.Order;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<LocalIdentityUser> _userManager;

        public OrderController(IOrderService orderService, UserManager<LocalIdentityUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        // GET: Admin/Order
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            if (!orders.Any())
            {
                return NotFound();
            }

            return View(orders.Adapt<IEnumerable<OrderDetailViewModel>>());
        }

        // GET: Admin/Order/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order.Adapt<OrderDetailViewModel>());
        }

        //// GET: Admin/Order/Create
        //public IActionResult Create()
        //{
        //    // TODO use list of available categories and manufacturers
        //    // not like this:
        //    //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
        //    //ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");

        //    return View();
        //}

        //// POST: Admin/Order/Create
        //[HttpPost]
        //public async Task<IActionResult> Create(OrderCreateViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    // Retrieve the userId of the currently logged-in user
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //        return Unauthorized("User must be authenticated to create the order.");

        //    var order = model.Adapt<OrderCreateDTO>();
        //    order.LastModifiedById = user.UserId;

        //    await _orderService.CreateOrderAsync(order);

        //    //ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", order.CategoryId);
        //    //ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", order.ManufacturerId);
        //    return RedirectToAction("Index");
        //}

        //// GET: Admin/Order/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var order = await _orderService.GetOrderByIdAsync(id);

        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    var manufacturers = await _manufacturerService.GetManufacturers();
        //    if (manufacturers == null)
        //    {
        //        return NotFound();
        //    }

        //    var orderUpdateViewModel = order.Adapt<OrderUpdateViewModel>();

        //    orderUpdateViewModel.Manufacturers = manufacturers;

        //    return View(orderUpdateViewModel);
        //}

        //// POST: Admin/Order/Edit/5
        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, OrderUpdateViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //        // return BadRequest(ModelState);
        //    }

        //    var order = model.Adapt<OrderUpdateDTO>();

        //    // Retrieve the userId of the currently logged-in user
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //        return Unauthorized("User must be authenticated to edit the order.");
        //    order.LastModifiedById = user.UserId;

        //    var orderResult = await _orderService.UpdateOrderAsync(id, order);

        //    return View(orderResult.Adapt<OrderUpdateViewModel>());
        //}

        //// GET: Admin/Order/Delete/5
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var order = await _orderService.GetOrderByIdAsync(id);

        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order.Adapt<OrderDetailViewModel>());
        //}

        //// POST: Admin/Order/Delete/5
        //[HttpPost, ActionName("Delete")]
        //public async Task<IActionResult> DeleteConfirm(int id)
        //{
        //    // Retrieve the userId of the currently logged-in user
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //        return Unauthorized("User must be authenticated to delete the order.");

        //    await _orderService.DeleteOrderAsync(id, user.UserId);

        //    return RedirectToAction("Index");
        //}
    }
}
