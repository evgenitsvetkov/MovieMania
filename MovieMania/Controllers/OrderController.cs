using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Order;
using System.Security.Claims;

namespace MovieMania.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;

        public OrderController(IOrderService _orderService, ICartService _cartService)
        {
            orderService = _orderService;
            cartService = _cartService;

        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var model = new OrderFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderFormModel model)
        {
            string userId = User.Id();

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            int newOrderId = await orderService.CreateAsync(model, userId);
            int cartId = await cartService.GetCartIdAsync(userId);

            await orderService.CreateOrderDetailsAsync(cartId, newOrderId);

            await cartService.ClearCartAsync(cartId);

            return RedirectToAction(nameof(Details), new { id = newOrderId });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string userId = User.Id();

            if (await orderService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var order = await orderService.GetOrderServiceModelAsync(id, userId);

            if (order == null)
            {
                return NotFound();
            }

            //var model = await orderService.AllAsync(id);

            return View(order);
        }
    }
}
