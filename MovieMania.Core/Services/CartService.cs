using Microsoft.EntityFrameworkCore;
using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Cart;
using MovieMania.Core.Models.Movie;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Infrastructure.Data.Models.Carts;

namespace MovieMania.Core.Services
{
    public class CartService : ICartService
    {

        private readonly IUnitOfWork unitOfWork;

        public CartService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task CreateCartItemAsync(int cartId, MovieServiceModel model)
        {
           var newItem = new CartItem()
           {
               CartId = cartId,
               MovieId = model.Id,
               ItemTotal = model.Price,
               Quantity = 1,
           };
           
            await unitOfWork.AddAsync(newItem);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<CartServiceModel> GetCartServiceModelAsync(string userId)
        {
            return await unitOfWork.AllReadOnly<Cart>()
                .Where(c => c.UserId == userId)
                .Select(c => new CartServiceModel()
                {
                    CartId = c.CartId,
                    TotalAmount = c.TotalAmount,
                    CartItems = c.CartItems.Select(ci => new CartItemServiceModel()
                    {
                        CartItemId = ci.CartItemId,
                        Title = ci.Movie.Title,
                        ImageUrl = ci.Movie.ImageURL,
                        Quantity = ci.Quantity,
                        ItemTotal = ci.ItemTotal
                    })
                    .ToList()
                })
                .FirstAsync();
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

        public async Task IncreaseCartItemQuantityAsync(int cartId, int cartItemId)
        {
            var item = await unitOfWork.All<CartItem>()
                .Include(ci => ci.Movie)
                .Where(ci => ci.CartId == cartId && ci.CartItemId == cartItemId)
                .FirstOrDefaultAsync();

            if (item != null)
            {
                item.Quantity++;
                item.ItemTotal = item.Quantity * item.Movie.Price;
                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DecreaseCartItemQuantityAsync(int cartId, int cartItemId)
        {
            var item = await unitOfWork.All<CartItem>()
                .Include(ci => ci.Movie)
                .Where(ci => ci.CartId == cartId && ci.CartItemId == cartItemId)
                .FirstAsync();
            
            if (item != null)
            {
                item.Quantity--;
                item.ItemTotal = item.Quantity * item.Movie.Price;

                if (item.Quantity <= 0)
                {
                    item.Quantity = 1;
                }

                await unitOfWork.SaveChangesAsync();
            }
            
        }

        public async Task DeleteCartAsync(int cartId, string userId)
        {
            var cart = await unitOfWork.All<Cart>()
                .Include(ci => ci.CartItems)
                .Where(c => c.CartId == cartId && c.UserId == userId)
                .FirstOrDefaultAsync();

            if (cart != null)
            {
               await unitOfWork.DeleteAsync<Cart>(cart.CartId);
               await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task RemoveFromCartAsync(int cartId, int cartItemId)
        {
            var cartItem = await unitOfWork.All<CartItem>()
                .Where(c => c.CartItemId == cartItemId && c.CartId == cartId)
                .FirstAsync();

            await unitOfWork.DeleteAsync<CartItem>(cartItem.CartItemId);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> CartItemExistsByIdAsync(int cartId, int cartItemId)
        {
            return await unitOfWork.AllReadOnly<CartItem>()
                .AnyAsync(ci => ci.CartItemId == cartItemId && ci.CartId == cartId);
        }

        public async Task<int> GetCartItemIdAsync(int cartId, int movieId)
        {
            var cartItem = await unitOfWork.AllReadOnly<CartItem>()
                .Where(ci => ci.CartId == cartId && ci.MovieId == movieId)
                .FirstAsync();

            return cartItem.CartItemId;
        }

        public async Task<int> GetCartItemsCountAsync(int cartId)
        {
            return await unitOfWork.AllReadOnly<CartItem>()
                .Where(ci => ci.CartId == cartId)
                .SumAsync(ci => ci.Quantity);
        }

        public async Task SumCartTotalAmountAsync(int cartId)
        {
            var cart = await unitOfWork.All<Cart>()
                .Include(c => c.CartItems)
                .Where(c => c.CartId == cartId)
                .FirstOrDefaultAsync();

            if (cart != null)
            {
                var cartTotalPrice = cart.CartItems.Sum(c => c.ItemTotal);
                cart.TotalAmount = cartTotalPrice;
                
                await unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<CartItemServiceModel> GetCartItemServiceModelAsync(int cartId, int cartItemId)
        {
            return await unitOfWork.AllReadOnly<CartItem>()
                .Where(ci => ci.CartItemId == cartItemId && ci.CartId == cartId)
                .Select(ci => new CartItemServiceModel()
                {
                    CartItemId = cartItemId,
                    Title = ci.Movie.Title,
                    Quantity = ci.Quantity,
                    ImageUrl = ci.Movie.ImageURL,
                    ItemTotal = ci.ItemTotal,
                })
                .FirstAsync();
        }

        public async Task<decimal> GetCartTotalAmountAsync(int cartId)
        {
            var cartTotalPrice = await unitOfWork.AllReadOnly<Cart>()
                .Where(c => c.CartId == cartId)
                .FirstAsync();

            return cartTotalPrice.TotalAmount;
        }
    }
}
