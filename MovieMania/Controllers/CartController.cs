using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Cart;
using System.Security.Claims;
using static MovieMania.Core.Constants.MessageConstants;

namespace MovieMania.Controllers
{
    public class CartController : BaseController
    {
        private readonly ICartService cartService;
        private readonly IMovieService movieService;
        private readonly ILogger<CartController> logger;

        public CartController(ICartService _cartService, IMovieService _movieService, ILogger<CartController> _logger)
        {
            cartService = _cartService;
            movieService = _movieService;
            logger = _logger;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCart()
        {
            var userId = User.Id();
            
            if (await cartService.CartExistsAsync(userId) == false)
            {
                logger.LogInformation("Cart not exist for User {UserId}. Creating new cart...", userId);
                await cartService.CreateCartAsync(userId);
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            logger.LogInformation("Cart is ready for User ${UserId}", userId);
            return Json(new { success = true });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning("Unauthorized access attempt to AddToCart. Redirect to login.");
                return Redirect(LoginUrl);
            }

            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
                logger.LogInformation("Cart not exist for User {UserId}. Creating new cart...", userId);
                return NotFound();
            }

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
                logger.LogWarning("Unauthorized access attempt to AddToCart.");
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            if (!ModelState.IsValid)
            {
                logger.LogWarning("Invalid model state in AddToCart. Model: {@Model}", model);
                return Json(new { success = false, message = InvalidInputMessage });
            }

            var userId = User.Id();
            logger.LogInformation("User {UserId} is adding Movie {MovieId} to cart.", userId, model.Id);

            if (await movieService.ExistsAsync(model.Id) == false)
            {
                logger.LogWarning("Movie {MovieId} not found while adding to cart.", model.Id);
                return NotFound(new { success = false, message = MovieNotFoundMessage });
            }

            if (await cartService.CartExistsAsync(userId) == false)
            {
                logger.LogInformation("Cart not exist for User {UserId}. Creating new cart...", userId);
                return NotFound(new { success = false, message = CartNotFoundMessage });
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartItemExistsByMovieIdAsync(model.Id, cartId) == false)
            {
                var movieModel = await movieService.MoviesDetailsByIdAsync(model.Id);
                await cartService.CreateCartItemAsync(cartId, movieModel);
                logger.LogInformation("Cart item created and added to cart {CartId}. Movie: {MovieId}", cartId, model.Id);
            } 
            else
            {
                var cartItemId = await cartService.GetCartItemIdAsync(cartId, model.Id);
                await cartService.IncreaseCartItemQuantityAsync(cartId, cartItemId);
                logger.LogInformation("Increased quantity for Cart item {CartItemId} in Cart {CartId}.", cartItemId, cartId);
            }

            await cartService.SumCartTotalAmountAsync(cartId);

            return Json(new { success = true });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearCart()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning($"Unauthorized access attempt to ClearCart.");
                TempData[UserMessageError] = UserUnauthorizedMessage;
                return Unauthorized();
            }

            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
                logger.LogWarning("Cart not exist for User {UserId}.", userId);
                TempData[UserMessageSuccess] = CartNotFoundMessage;

                return NotFound();
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            await cartService.ClearCartAsync(cartId);
            logger.LogInformation("Cart {CartId} cleared successfully for User {UserId}.", cartId, userId);

            TempData[UserMessageSuccess] = ClearCartSuccessMessage;

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromCart([FromBody]CartRequestModel model) 
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                logger.LogWarning($"Unauthorized access attempt to RemoveFromCart.");
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            if (!ModelState.IsValid)
            {
                logger.LogWarning("Invalid model state in RemoveFromCart. Model: {@Model}", model);
                return Json(new { success = false, message = InvalidInputMessage });
            }

            var userId = User.Id();

            if (!await cartService.CartExistsAsync(userId))
            {
                logger.LogWarning("Cart not exist for User {UserId}.", userId);
                return NotFound(new { success = false, message = CartNotFoundMessage });
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartItemExistsByIdAsync(cartId, model.Id) == false)
            {
                logger.LogWarning("Cart item {CartItemId} not found in Cart {CartId} for User {UserId}.", model.Id, cartId, userId);
                return NotFound(new { success = false, message = CartItemNotFoundMessage }); 
            }

            await cartService.RemoveFromCartAsync(cartId, model.Id);
            logger.LogInformation("Cart item {CartItemId} successfully removed from Cart {CartId} for User {UserId}.", model.Id, cartId, userId);

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
                logger.LogWarning($"Unauthorized access attempt to GetCartItemCount.");
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
                logger.LogWarning("Cart not exist for User {UserId}.", userId);
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
                logger.LogWarning($"Unauthorized access attempt to UpdateQuantity.");
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            if (!ModelState.IsValid)
            {
                logger.LogWarning("Invalid model state in UpdateQuantity. Model: {@Model}", model);
                return Json(new { success = false, message = InvalidInputMessage });
            }

            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
                logger.LogWarning("Cart not exist for User {UserId}.", userId);
                return NotFound(new { sucess = false, message = CartNotFoundMessage });
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartItemExistsByIdAsync(cartId, model.Id) == false)
            {
                logger.LogWarning("Cart item {CartItemId} not found in Cart {CartId} for User {UserId}.", model.Id, cartId, userId);
                return NotFound(new { success = false, message = CartItemNotFoundMessage });
            }

            if (model.IsIncrease)
            {
                await cartService.IncreaseCartItemQuantityAsync(cartId, model.Id);
                logger.LogInformation("Increased quantity of CartItem {CartItemId} in Cart {CartId} for User {UserId}.", model.Id, cartId, userId);
            } else
            {
                await cartService.DecreaseCartItemQuantityAsync(cartId, model.Id);
                logger.LogInformation("Decreased quantity of CartItem {CartItemId} in Cart {CartId} for User {UserId}.", model.Id, cartId, userId);
            }

            await cartService.SumCartTotalAmountAsync(cartId);

            var cartItem = await cartService.GetCartItemServiceModelAsync(cartId, model.Id);
            var totalAmount = await cartService.GetCartTotalAmountAsync(cartId);

            return Json(new { success = true, newQuantity = cartItem.Quantity, itemPrice = cartItem.ItemTotal, totalAmount });
        }
    }
}
