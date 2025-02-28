using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Cart;
using System.Security.Claims;
using static MovieMania.Core.Constants.MessageConstants;
using static MovieMania.Core.Constants.LogMessageConstants;

namespace MovieMania.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly IMovieService movieService;
        private readonly ILogger<CartController> logger;

        public CartController(
            ICartService _cartService, 
            IMovieService _movieService, 
            ILogger<CartController> _logger)
        {
            cartService = _cartService;
            movieService = _movieService;
            logger = _logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Items()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning(UnauthorizedAccessLogMessage, nameof(Items));
                TempData[UserMessageError] = UserUnauthorizedMessage;

                return Redirect(LoginUrl);
            }

            var userId = User.Id();

            await CreateCart(userId);

            var cart = await cartService.GetCartServiceModelAsync(userId);
            await cartService.SumCartTotalAmountAsync(cart.CartId);

            return View(cart);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart([FromBody]CartRequestModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning(UnauthorizedAccessLogMessage, nameof(AddToCart));
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            if (!ModelState.IsValid)
            {
                logger.LogWarning(InvalidModelStateLogMessage, nameof(AddToCart), model);
                return Json(new { success = false, message = InvalidInputMessage });
            }

            var userId = User.Id();
            logger.LogInformation(AddingMovieToCartLogMessage, userId, model.Id);

            if (await movieService.ExistsAsync(model.Id) == false)
            {
                logger.LogWarning(MovieNotFoundLogMessage, model.Id);
                return NotFound(new { success = false, message = AddingMovieNotFoundMessage });
            }

            var cartId = await CreateCart(userId);

            if (await cartService.CartItemExistsByMovieIdAsync(model.Id, cartId) == false)
            {
                var movieModel = await movieService.MoviesDetailsByIdAsync(model.Id);
                await cartService.CreateCartItemAsync(cartId, movieModel);
                logger.LogInformation(CartItemCreatedLogMessage, cartId, model.Id);
            } 
            else
            {
                var cartItemId = await cartService.GetCartItemIdAsync(cartId, model.Id);
                await cartService.IncreaseCartItemQuantityAsync(cartId, cartItemId);
                logger.LogInformation(CartItemQuantityIncreasedLogMessage, cartItemId, cartId);
            }

            await cartService.SumCartTotalAmountAsync(cartId);

            return Json(new { success = true });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart([FromBody]CartRequestModel model) 
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning(UnauthorizedAccessLogMessage, nameof(RemoveFromCart));
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            if (!ModelState.IsValid)
            {
                logger.LogWarning(InvalidModelStateLogMessage, nameof(RemoveFromCart), model);
                return Json(new { success = false, message = InvalidInputMessage });
            }

            var userId = User.Id();

            if (!await cartService.CartExistsAsync(userId))
            {
                logger.LogWarning(CartNotExistLogMessage, userId);
                return NotFound(new { success = false, message = CartNotFoundMessage });
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartItemExistsByIdAsync(cartId, model.Id) == false)
            {
                logger.LogWarning(CartItemNotFoundLogMessage, model.Id, cartId);
                return NotFound(new { success = false, message = CartItemNotFoundMessage }); 
            }

            await cartService.RemoveFromCartAsync(cartId, model.Id);
            logger.LogInformation(CartItemRemovedLogMessage, model.Id, cartId);

            await cartService.SumCartTotalAmountAsync(cartId);
            decimal cartTotalAmount = await cartService.GetCartTotalAmountAsync(cartId);

            return Json(new { success = true, newCartTotalAmount = cartTotalAmount });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCartItemCount()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning(UnauthorizedAccessLogMessage, nameof(GetCartItemCount));
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
                logger.LogWarning(CartNotExistLogMessage, userId);
                return NotFound(new { success = false, message = CartNotFoundMessage });
            }

            int cartId = await cartService.GetCartIdAsync(userId);

            int count = await cartService.GetCartItemsCountAsync(cartId);

            return Json(new { success = true, count });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQuantity([FromBody]UpdateCartItemRequestModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning(UnauthorizedAccessLogMessage, nameof(UpdateQuantity));
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            if (!ModelState.IsValid)
            {
                logger.LogWarning(InvalidModelStateLogMessage, nameof(UpdateQuantity), model);
                return Json(new { success = false, message = InvalidInputMessage });
            }

            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
                logger.LogWarning(CartNotExistLogMessage, userId);
                return NotFound(new { sucess = false, message = CartNotFoundMessage });
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartItemExistsByIdAsync(cartId, model.Id) == false)
            {
                logger.LogWarning(CartItemNotFoundLogMessage, model.Id, cartId);
                return NotFound(new { success = false, message = CartItemNotFoundMessage });
            }

            if (model.IsIncrease)
            {
                await cartService.IncreaseCartItemQuantityAsync(cartId, model.Id);
                logger.LogInformation(CartItemQuantityIncreasedLogMessage, model.Id, cartId);
            } else
            {
                await cartService.DecreaseCartItemQuantityAsync(cartId, model.Id);
                logger.LogInformation(CartItemQuantityDecreasedLogMessage, model.Id, cartId);
            }

            await cartService.SumCartTotalAmountAsync(cartId);

            var cartItem = await cartService.GetCartItemServiceModelAsync(cartId, model.Id);
            var totalAmount = await cartService.GetCartTotalAmountAsync(cartId);

            return Json(new { success = true, newQuantity = cartItem.Quantity, itemPrice = cartItem.ItemTotal, totalAmount });
        }

        private async Task<int> CreateCart(string userId)
        {
            if (await cartService.CartExistsAsync(userId) == false)
            {
                logger.LogInformation(CartNotExistCreatingLogMessage, userId);

                var newCartId = await cartService.CreateCartAsync(userId);
                logger.LogInformation(CartCreatedLogMessage, newCartId);      
                return newCartId;
            }

            var cartId = await cartService.GetCartIdAsync(userId);
            logger.LogInformation(CartAlreadyExistLogMessage, cartId);

            return cartId;
        }
    }
}
