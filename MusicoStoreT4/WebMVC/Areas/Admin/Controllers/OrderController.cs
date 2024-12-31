using BusinessLayer.DTOs.Order;
using BusinessLayer.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models.Order;

namespace WebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;

        public OrderController(
            IOrderService orderService, 
            IUserService userService,
            IProductService productService)
        {
            _orderService = orderService;
            _userService = userService;
            _productService = productService;
        }

        // GET: Admin/Order
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrdersAsync();

            if (!orders.Any())
            {
                return NotFound();
            }

            return View(orders.Adapt<IEnumerable<OrderSummaryViewModel>>());
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

        // GET: Admin/Order/Create
        public async Task<IActionResult> Create()
        {
            var users = await _userService.GetAllUsersAsync();
            var products = await _productService.GetAllProductsAsync();

            if (users == null || products == null)
            {
                return NotFound();
            }

            var orderCreateViewModel = new OrderCreateViewModel
            {
                Users = users,
                Products = products
            };

            return View(orderCreateViewModel);
        }

        // POST: Admin/Order/Create
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateViewModel model)
        {
            // Check if any item is missing ProductId or Quantity
            if (model.Items == null || model.Items.Any(item => item.ProductId <= 0 || item.Quantity <= 0))
            {
                ModelState.AddModelError("", "Each order item must have a valid product and quantity.");

                // Reload Users and Products for the view
                model.Users = await _userService.GetAllUsersAsync();
                model.Products = await _productService.GetAllProductsAsync();
                return View(model);
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var order = model.Adapt<CreateOrderDto>();
            var order = new CreateOrderDto
            {
                CustomerId = model.CustomerId,
                Items = model.Items
            };

            await _orderService.CreateOrderAsync(order);

            return RedirectToAction("Index", new { area = "Admin" });
        }

        // GET: Admin/Order/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var orderDetailDto = await _orderService.GetOrderByIdAsync(id);

            if (orderDetailDto == null)
                return NotFound();

            var products = await _productService.GetAllProductsAsync();

            if (products == null)
                return NotFound();

            var orderUpdateViewModel = orderDetailDto.Adapt<OrderUpdateViewModel>();
            orderUpdateViewModel.Products = products;

            return View(orderUpdateViewModel);
        }

        // POST: Admin/Order/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, OrderUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Invalid edit
                ModelState.AddModelError("", "Each order must have a valid product and quantity.");

                // Reload products for dropdown
                model.Products = await _productService.GetAllProductsAsync(); 
                return View(model);
            }

            var UpdateOrderDto = model.Adapt<UpdateOrderDto>();
            await _orderService.UpdateOrderAsync(id, UpdateOrderDto);

            return RedirectToAction("Details", "Order", new { area = "Admin", id });
        }

        // GET: Admin/Order/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order.Adapt<OrderDetailViewModel>());
        }

        // POST: Admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _orderService.DeleteOrderAsync(id);

            return RedirectToAction("Index", new { area = "Admin" });
        }
    }
}
