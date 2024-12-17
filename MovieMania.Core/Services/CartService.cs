using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Cart;
using MovieMania.Core.Models.Movie;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Infrastructure.Data.Models.Carts;
using System.Linq;

namespace MovieMania.Core.Services
{
    public class CartService : ICartService
    {

        private readonly IUnitOfWork unitOfWork;

        public CartService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task AddToCartAsync(string userId, MovieDetailsServiceModel model)
        {
            var cart = await unitOfWork.AllReadOnly<Cart>()
                 .Where(c => c.UserId == userId)
                 .FirstOrDefaultAsync();

            var cartItem = cart.CartItems.FirstOrDefault(c => c.MovieId == model.Id);

            if (cartItem != null)
            {
                cartItem.Quantity++;
                await unitOfWork.SaveChangesAsync();
            }
            else
            {
                var newItem = new CartItem()
                {
                    CartId = cart.CartId,
                    MovieId = model.Id,
                    ItemTotal = model.Price,
                    Quantity = 0,
                };
                await unitOfWork.AddAsync(newItem);
            }

            await unitOfWork.SaveChangesAsync();
        }

        public async Task<CartItemQueryServiceModel> AllAsync(int cartId)
        {
            var cartItems = await unitOfWork.AllReadOnly<CartItem>()
                .Where(c => c.CartId == cartId)
                .Select(c => new CartItemServiceModel()
                {
                    CartItemId = c.CartItemId,
                    Title = c.Movie.Title,
                    ImageUrl = c.Movie.ImageURL,
                    Quantity = c.Quantity,
                    ItemTotal = c.ItemTotal
                })
                .ToListAsync();

            return new CartItemQueryServiceModel()
            {
                TotalPrice = cartItems.Sum(ci => ci.Quantity * ci.ItemTotal),
                CartItems = cartItems
            };
        }

        public async Task<bool> ExistsCartItemByMovieId(int cartId, int movieId)
        {
            return await unitOfWork.AllReadOnly<CartItem>().AnyAsync(c => c.CartId == cartId && c.MovieId == movieId);
        }

        public async Task<int> CreateCartAsync(string userId)
        {
            Cart newCart = new Cart()
            {
                CartItems = new List<CartItem>(),
                UserId = userId,
                TotalAmount = 0,
                
            };

            await unitOfWork.AddAsync(newCart);
            await unitOfWork.SaveChangesAsync();

            return newCart.CartId;
        }

        public async Task<bool> CartExistsAsync(string userId)
        {
            return await unitOfWork.AllReadOnly<Cart>()
                .AnyAsync(c => c.UserId == userId);
        }

        public async Task<int> GetCartIdAsync(string userId)
        {
            var cart = await unitOfWork.AllReadOnly<Cart>()
                .Where(c => c.UserId == userId)
                .FirstAsync();

            return cart.CartId;
        }

        public async Task<bool> CartItemExistsByMovieIdAsync(int movieId, int cartId)
        {
            return await unitOfWork.AllReadOnly<CartItem>()
                .AnyAsync(ci => ci.MovieId == movieId && ci.CartId == cartId);
        }

        public async Task UpdateCartItemQuantity(int cartId, int cartItemId)
        {
            var item = await unitOfWork.All<CartItem>()
                .Where(c => c.CartItemId == cartItemId && c.CartId == cartId)
                .FirstAsync();

            item.Quantity += 1;
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<CartItemServiceModel> GetCartItemServiceModelAsync(int cartId, int movieId)
        {
            return await unitOfWork.AllReadOnly<CartItem>()
                .Where(ci => ci.CartId == cartId && ci.MovieId == movieId)
                .Select(ci => new CartItemServiceModel()
                {
                    CartItemId = ci.CartItemId,
                    ImageUrl = ci.Movie.ImageURL,
                    Title = ci.Movie.Title,
                    ItemTotal = ci.ItemTotal,
                    Quantity = ci.Quantity
                })
                .FirstAsync();
        }

        public async Task ClearCartAsync(int cartId)
        {
            var cart = await unitOfWork.All<Cart>()
                .Where(c => c.CartId == cartId)
                .Include(ci => ci.CartItems)
                .FirstOrDefaultAsync();

            foreach(var cartitem in cart.CartItems)
            {
                await unitOfWork.DeleteAsync<CartItem>(cartitem.CartItemId);
            }

            await unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveFromCartAsync(int cartId, int cartItemId)
        {
            var cartItem = await unitOfWork.All<CartItem>()
                .Where(c => c.CartItemId == cartItemId && c.CartId == cartId)
                .FirstAsync();

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;
                await unitOfWork.SaveChangesAsync();
            }

            await unitOfWork.DeleteAsync<CartItem>(cartItem);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> CartItemExistsByIdAsync(int cartId, int cartItemId)
        {
            return await unitOfWork.AllReadOnly<CartItem>()
                .AnyAsync(ci => ci.CartItemId == cartItemId && ci.CartId == cartId);
        }
    }
}
