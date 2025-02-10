using MovieMania.Core.Models.Cart;
using MovieMania.Core.Models.Movie;
using MovieMania.Core.Services;

namespace MovieMania.Core.Contracts
{
    public interface ICartService
    {
        Task<CartServiceModel> AllAsync(int cartId);

        Task<int> CreateCartAsync(string userId);

        Task<bool> CartExistsAsync(string userId);

        Task<int> GetCartIdAsync(string userId);

        Task<int> GetCartItemIdAsync(int cartId, int movieId);

        Task CreateCartItemAsync(int cartId, MovieServiceModel model);

        Task<bool> CartItemExistsByMovieIdAsync(int movieId, int cartId);

        Task<bool> CartItemExistsByIdAsync(int cartId, int cartItemId);

        Task IncreaseCartItemQuantityAsync(int cartId, int cartItemId);

        Task DecreaseCartItemQuantityAsync(int cartId, int cartItemId);

        Task ClearCartAsync(int cartId);

        Task RemoveFromCartAsync(int cartId, int cartItemId);

        Task<int> GetCartItemsCountAsync(int cartId);

        Task SumCartTotalPriceAsync(int cartId);

        Task<CartItemServiceModel> GetCartItemByIdAsync(int cartId, int cartItemId);

        Task<decimal> GetCartTotalAmountAsync(int cartId);
    }
}
