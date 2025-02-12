using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Order;
using System.Security.Claims;
using static MovieMania.Core.Constants.MessageConstants;

namespace MovieMania.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly ICartService cartService;
        private readonly ILogger<OrderController> logger;

        public OrderController(IOrderService _orderService, ICartService _cartService, ILogger<OrderController> _logger)
        {
            orderService = _orderService;
            cartService = _cartService;
            logger = _logger;

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Checkout()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning("Unauthorized access attempt to Checkout.");
                TempData[UserMessageError] = UserUnauthorizedMessage;
                return Unauthorized();
            }

            var userId = this.User.Id();

            if (!await cartService.CartExistsAsync(userId))
            {
                logger.LogWarning("Cart not exist for User {UserId}.", userId);
                TempData[UserMessageError] = CartNotFoundMessage;
                return NotFound();
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.GetCartItemsCountAsync(cartId) <= 0)
            {
                logger.LogWarning("Cart is empty for User {UserId}.", userId);
                TempData[UserMessageError] = CartIsEmptyMessage;
                return Redirect(CartAllItemsUrl);
            }

            var model = new OrderFormModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(OrderFormModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning("Unauthorized access attempt to Checkout.");
                TempData[UserMessageError] = UserUnauthorizedMessage;
                return Unauthorized();
            }

            string userId = User.Id();

            if (!ModelState.IsValid)
            {
                logger.LogWarning("Invalid model state in Checkout. Model: {@Model}", model);
                TempData[UserMessageError] = InvalidInputMessage;
                return View(model);
            }

            if (!await cartService.CartExistsAsync(userId))
            {
                logger.LogWarning("Cart not exist for User {UserId}.", userId);
                TempData[UserMessageError] = CartNotFoundMessage;
                return NotFound();
            }

            var cart = await cartService.GetCartServiceModelAsync(userId);

            int newOrderId = await orderService.CreateAsync(model, userId, cart.TotalAmount);
            logger.LogInformation("Order {OrderId} created for User {UserId}.", newOrderId, userId);

            await orderService.CreateOrderDetailsAsync(cart.CartId, newOrderId);
            logger.LogInformation("Order Details created for User {UserId} with Order {OrderId}.", userId, newOrderId);

            await cartService.ClearCartAsync(cart.CartId);
            logger.LogInformation("Cart {CartId} cleared", cart.CartId);

            TempData[UserMessageSuccess] = CheckoutSuccessMessage;
            return RedirectToAction(nameof(Details), new { id = newOrderId });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning("Unauthorized access attempt to Checkout.");
                TempData[UserMessageError] = UserUnauthorizedMessage;
                return Unauthorized();
            }

            string userId = User.Id();

            if (!await orderService.ExistsAsync(id))
            {
                logger.LogWarning("Order not exist for User {UserId}.", userId);
                TempData[UserMessageError] = OrderNotFoundMessage;
                return BadRequest();
            }

            var order = await orderService.GetOrderServiceModelAsync(id, userId);

            return View(order);
        }
    }
}
