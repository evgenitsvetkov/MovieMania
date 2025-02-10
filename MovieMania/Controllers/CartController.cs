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

        public CartController(ICartService _cartService, IMovieService _movieService)
        {
            cartService = _cartService;
            movieService = _movieService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Redirect(LoginUrl);
            }

            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
                await cartService.CreateCartAsync(userId);
            }

            var cartId = await cartService.GetCartIdAsync(userId);
            await cartService.SumCartTotalPriceAsync(cartId);

            var cartItems = await cartService.AllAsync(cartId);

            return View(cartItems);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart([FromBody]CartRequestModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = InvalidInputMessage });
            }

            var userId = User.Id();

            if (await movieService.ExistsAsync(model.Id) == false)
            {
                return NotFound(new { success = false, message = MovieNotFoundMessage });
            }

            if (await cartService.CartExistsAsync(userId) == false)
            {
                await cartService.CreateCartAsync(userId);
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartItemExistsByMovieIdAsync(model.Id, cartId) == false)
            {
                var movieModel = await movieService.MoviesDetailsByIdAsync(model.Id);
                await cartService.CreateCartItemAsync(cartId, movieModel);      
            } 
            else
            {
                var cartItemId = await cartService.GetCartItemIdAsync(cartId, model.Id);
                await cartService.IncreaseCartItemQuantityAsync(cartId, cartItemId);
            }

            await cartService.SumCartTotalPriceAsync(cartId);

            return Json(new { success = true });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearCart()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }

            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
                return NotFound();
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            await cartService.ClearCartAsync(cartId);

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
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = InvalidInputMessage });
            }

            var userId = User.Id();

            if (!await cartService.CartExistsAsync(userId))
            {
                return NotFound(new { success = false, message = CartNotFoundMessage });
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartItemExistsByIdAsync(cartId, model.Id) == false)
            {
                return NotFound(new { success = false, message = CartItemNotFoundMessage }); 
            }

            await cartService.RemoveFromCartAsync(cartId, model.Id);
            await cartService.SumCartTotalPriceAsync(cartId);

            decimal cartTotalAmount = await cartService.GetCartTotalAmountAsync(cartId);

            return Json(new { success = true, newCartTotalAmount = cartTotalAmount });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCartItemCount()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
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
                return Unauthorized(new { success = false, message = UserUnauthorizedMessage });
            }

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = InvalidInputMessage });
            }

            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
                return NotFound(new { sucess = false, message = CartNotFoundMessage });
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartItemExistsByIdAsync(cartId, model.Id) == false)
            {
                return NotFound(new { success = false, message = CartItemNotFoundMessage });
            }

            if (model.IsIncrease)
            {
                await cartService.IncreaseCartItemQuantityAsync(cartId, model.Id);
            } else
            {
                await cartService.DecreaseCartItemQuantityAsync(cartId, model.Id);
            }

            await cartService.SumCartTotalPriceAsync(cartId);           

            var cartItem = await cartService.GetCartItemByIdAsync(cartId, model.Id);
            var cartTotalAmount = await cartService.GetCartTotalAmountAsync(cartId);

            return Json(new { success = true, newQuantity = cartItem.Quantity, itemPrice = cartItem.ItemTotal,  totalAmount = cartTotalAmount });
        }
    }
}
