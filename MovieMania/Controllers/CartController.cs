using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieMania.Core.Contracts;
using System.Security.Claims;

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

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var userId = User.Id();

            if (await cartService.CartExistsAsync(userId) == false)
            {
                await cartService.CreateCartAsync(userId);
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            var cartItems = await cartService.AllAsync(cartId);

            return View(cartItems);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(int id)
        {
            var userId = User.Id();

            if (await movieService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await cartService.CartExistsAsync(userId) == false)
            {
                await cartService.CreateCartAsync(userId);
            }

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartItemExistsByMovieIdAsync(id, cartId) == false)
            {
                var movieModel = await movieService.MoviesDetailsByIdAsync(id);
                await cartService.AddToCartAsync(userId, movieModel);                
            }

            var cartItem = await cartService.GetCartItemServiceModelAsync(cartId, id);
            await cartService.UpdateCartItemQuantity(cartId, cartItem.CartItemId);

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var userId = User.Id();

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartExistsAsync(userId) == false)
            {
                return BadRequest();
            }

            await cartService.ClearCartAsync(cartId);

            return RedirectToAction(nameof(All));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            var userId = User.Id();

            var cartId = await cartService.GetCartIdAsync(userId);

            if (await cartService.CartItemExistsByIdAsync(cartId, cartItemId) == false)
            {
                return BadRequest();
            }

            await cartService.RemoveFromCartAsync(cartId, cartItemId);

            return RedirectToAction("All", "Cart");
        }

    }
}
