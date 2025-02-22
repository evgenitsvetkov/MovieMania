using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Order;
using System.Security.Claims;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Core.Constants.LogMessageConstants;

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
        public async Task<IActionResult> MyOrders()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning(UnauthorizedAccessLogMessage, nameof(Details));
                TempData[UserMessageError] = UserUnauthorizedMessage;

                return Unauthorized();
            }

            string userId = User.Id();

            var allOrders = await orderService.AllUserOrdersAsync(userId);

            return View(allOrders);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Checkout()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning(UnauthorizedAccessLogMessage, nameof(Checkout));
                TempData[UserMessageError] = UserUnauthorizedMessage;

                return Unauthorized();
            }

            var userId = this.User.Id();

            if (!await cartService.CartExistsAsync(userId))
            {
                logger.LogWarning(CartNotExistLogMessage, userId);
                TempData[UserMessageError] = CartNotFoundMessage;

                return NotFound();
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.GetCartItemsCountAsync(cartId) <= 0)
            {
                logger.LogWarning(CartIsEmptyLogMessage, userId);
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
                logger.LogWarning(UnauthorizedAccessLogMessage, nameof(Checkout));
                TempData[UserMessageError] = UserUnauthorizedMessage;

                return Unauthorized();
            }

            string userId = User.Id();

            if (!ModelState.IsValid)
            {
                logger.LogInformation(InvalidModelStateLogMessage, nameof(Checkout), model);
                TempData[UserMessageError] = InvalidInputMessage;

                return View(model);
            }

            if (!await cartService.CartExistsAsync(userId))
            {
                logger.LogWarning(CartNotExistLogMessage, userId);
                TempData[UserMessageError] = CartNotFoundMessage;

                return NotFound();
            }

            var cart = await cartService.GetCartServiceModelAsync(userId);

            int newOrderId = await orderService.CreateAsync(model, userId, cart.TotalAmount);
            logger.LogInformation(OrderCreatedLogMessage, newOrderId, userId);

            await orderService.CreateOrderDetailsAsync(cart.CartId, newOrderId);
            logger.LogInformation(OrderDetailsCreatedLogMessage, userId, newOrderId);

            await cartService.DeleteCartAsync(cart.CartId, userId);

            logger.LogInformation(CartClearedLogMessage, cart.CartId, userId);
            TempData[UserMessageSuccess] = CheckoutSuccessMessage;

            return RedirectToAction(nameof(Details), new { orderId = newOrderId });
        }

        [HttpGet("Order/Details/{orderId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int orderId)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning(UnauthorizedAccessLogMessage, nameof(Details));
                TempData[UserMessageError] = UserUnauthorizedMessage;

                return Unauthorized();
            }

            string userId = User.Id();

            if (!await orderService.ExistsAsync(orderId))
            {
                logger.LogWarning(OrderNotExistLogMessage, userId);
                TempData[UserMessageError] = OrderNotFoundMessage;

                return NotFound();
            }

            var order = await orderService.GetOrderServiceModelAsync(orderId, userId);

            return View(order);
        }
    }
}
