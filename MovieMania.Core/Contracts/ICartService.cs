using MovieMania.Core.Models.Cart;
using MovieMania.Core.Models.Movie;
using MovieMania.Core.Services;

namespace MovieMania.Core.Contracts
{
    public interface ICartService
    {
        Task<CartItemQueryServiceModel> AllAsync(int cartId);

        Task IncreaseQuantity();

        Task<bool> ExistsCartItemByMovieId(int cartId, int movieId);

        Task<int> CreateCartAsync(string userId);

        Task<bool> CartExistsAsync(string userId);

        Task<int> GetCartIdAsync(string userId);

        Task AddToCartAsync(string userId, MovieDetailsServiceModel model);

        Task<bool> CartItemExistsByMovieIdAsync(int movieId, int cartId);

        Task<bool> CartItemExistsByIdAsync(int cartId, int cartItemId);
        Task UpdateCartItemQuantity(int cartId, int cartItemId);

        Task<CartItemServiceModel> GetCartItemServiceModelAsync(int cartId, int movieId);

        Task ClearCartAsync(int cartId);

        Task RemoveFromCartAsync(int cartId, int cartItemId);
    }
}
