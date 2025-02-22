using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Cart;
using MovieMania.Core.Services;

namespace MovieMania.Tests.UnitTests
{
    [TestFixture]
    public class CartServiceTests : UnitTestsBase
    {
        private ICartService cartService;
        private IMovieService movieService;

        [OneTimeSetUp]
        public void SetUp()
        {
            cartService = new CartService(unitOfWork);
            movieService = new MovieService(unitOfWork);
        }
             
        [Test]
        public async Task CreateCartAsync_ShouldCreateNewCart()
        {
            // Arrange
            var userId = "AdminUserId2";

            var isExistBefore = await cartService.CartExistsAsync(userId);

            // Act
            var newCartId = await cartService.CreateCartAsync(userId);

            var isExistAfter = await cartService.CartExistsAsync(userId);

            var cartId = await cartService.GetCartIdAsync(userId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(isExistBefore, Is.False);
                Assert.That(newCartId, Is.EqualTo(cartId));
                Assert.That(isExistAfter, Is.True);
            });
        }

        [Test]
        public async Task CartExistsAsync_ShouldReturnFalse_WhenCartDoesNotExist()
        {
            // Arrange
            var userId = AdminUser.Id;

            // Act
            var isExist = await cartService.CartExistsAsync(userId);

            // Assert
            Assert.That(isExist, Is.False);
        }

        [Test]
        public async Task CartExistsAsync_ShouldReturnTrue_WhenCartExist()
        {
            // Arrange
            var userId = GuestUser.Id;

            // Act
            var isExist = await cartService.CartExistsAsync(userId);

            // Assert
            Assert.That(isExist, Is.True);
        }

        [Test]
        public async Task GetCartIdAsync_ShouldReturnCartId()
        {
            // Arrange
            var userId = "AdminUserId3";
            var newCartId = await cartService.CreateCartAsync(userId);

            // Act 
            var cartId = await cartService.GetCartIdAsync(userId);

            // Assert
            Assert.That(cartId, Is.EqualTo(newCartId));
        }

        [Test]
        public async Task GetCartServiceModelAsync_ShouldReturnCartServiceModel()
        {
            // Arrange
            var userId = "AdminUserId4";
            var newCartId = await cartService.CreateCartAsync(userId);

            // Act
            var cartModel = await cartService.GetCartServiceModelAsync(userId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(cartModel, Is.Not.Null);
                Assert.That(cartModel.CartId, Is.EqualTo(newCartId));
                Assert.That(cartModel, Is.InstanceOf<CartServiceModel>());
            });
        }

        [Test]
        public async Task CreateCartItemAsync_ShouldCreateCartItem()
        {
            // Arrange
            var userId = AdminUser.Id;
            var movieModel = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);
            var newCartId = await cartService.CreateCartAsync(userId);
            var isExistBefore = await cartService.CartItemExistsByMovieIdAsync(movieModel.Id, newCartId);
            
            // Act
            await cartService.CreateCartItemAsync(newCartId, movieModel);
            var isExistAfter = await cartService.CartItemExistsByMovieIdAsync(movieModel.Id, newCartId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(isExistBefore, Is.False);
                Assert.That(isExistAfter, Is.True);
            });
        }

        [Test]
        public async Task GetCartItemIdAsync_ShouldReturnCartItemId()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            var movieModel = await movieService.MoviesDetailsByIdAsync(FourthMovie.Id);
            await cartService.CreateCartItemAsync(newCartId, movieModel);

            // Act
            var cartItemId = await cartService.GetCartItemIdAsync(newCartId, movieModel.Id);
            var cartItem = await cartService.GetCartItemServiceModelAsync(newCartId, cartItemId);

            // Assert
            Assert.That(cartItemId, Is.EqualTo(cartItem.CartItemId));
        }

        [Test]
        public async Task CartItemExistsByMovieIdAsync_ShouldReturnTrue_WhenCartItemExist()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            var movieModel = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);

            await cartService.CreateCartItemAsync(newCartId, movieModel);

            // Act
            var isExist = await cartService.CartItemExistsByMovieIdAsync(movieModel.Id, newCartId);

            // Assert
            Assert.That(isExist, Is.True);
        }

        [Test]
        public async Task CartItemExistsByMovieIdAsync_ShouldReturnFalse_WhenCartItemDoesNotExist()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            var movieModel = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);

            // Act
            var isExist = await cartService.CartItemExistsByMovieIdAsync(movieModel.Id, newCartId);

            // Assert
            Assert.That(isExist, Is.False);
        }

        [Test]
        public async Task CartItemExistsByIdAsync_ShouldReturnTrue_WhenCartItemExist()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            var movieModel = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);

            await cartService.CreateCartItemAsync(newCartId, movieModel);

            var cartItemId = await cartService.GetCartItemIdAsync(newCartId, movieModel.Id);

            // Act
            var isExist = await cartService.CartItemExistsByIdAsync(newCartId, cartItemId);

            // Assert
            Assert.That(isExist, Is.True);
        }

        [Test]
        public async Task CartItemExistsByIdAsync_ShouldReturnFalse_WhenCartItemDoesNotExist()
        {
            // Arrange
            var userId = AdminUser.Id;
            var invalidCartItemId = 0;

            var newCartId = await cartService.CreateCartAsync(userId);

            // Act
            var isExist = await cartService.CartItemExistsByIdAsync(newCartId, invalidCartItemId);

            // Assert
            Assert.That(isExist, Is.False);
        }

        [Test]
        public async Task IncreaseCartItemQuantityAsync_ShouldIncreaseQuantity()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            var movieModel = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);

            await cartService.CreateCartItemAsync(newCartId, movieModel);

            var cartItemId = await cartService.GetCartItemIdAsync(newCartId, movieModel.Id);
            var cartItemOld = await cartService.GetCartItemServiceModelAsync(newCartId, cartItemId);
            
            // Act
            await cartService.IncreaseCartItemQuantityAsync(newCartId, cartItemId);
            var cartItemNew = await cartService.GetCartItemServiceModelAsync(newCartId, cartItemId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(cartItemOld.Quantity, Is.EqualTo(1));
                Assert.That(cartItemNew.Quantity, Is.EqualTo(2));
            });
        }

        [Test]
        public async Task DecreaseCartItemQuantityAsync_ShouldDecreaseQuantity()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            var movieModel = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);

            await cartService.CreateCartItemAsync(newCartId, movieModel);
            var cartItemId = await cartService.GetCartItemIdAsync(newCartId, movieModel.Id);

            await cartService.IncreaseCartItemQuantityAsync(newCartId, cartItemId);

            var cartItemOld = await cartService.GetCartItemServiceModelAsync(newCartId, cartItemId);

            // Act
            await cartService.DecreaseCartItemQuantityAsync(newCartId, cartItemId);
            var cartItemNew = await cartService.GetCartItemServiceModelAsync(newCartId, cartItemId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(cartItemOld.Quantity, Is.EqualTo(2));
                Assert.That(cartItemNew.Quantity, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task DeleteCartAsync_ShouldDeleteUserCart()
        {
            // Arrange
            var userId = "AdminUserId";
            var newCartId = await cartService.CreateCartAsync(userId);
            var thirdMovie = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);
            var fifthMovie = await movieService.MoviesDetailsByIdAsync(FifthMovie.Id);

            await cartService.CreateCartItemAsync(newCartId, thirdMovie);
            await cartService.CreateCartItemAsync(newCartId, fifthMovie);

            var firstCartItemId = await cartService.GetCartItemIdAsync(newCartId, thirdMovie.Id);
            var secondCartItemId = await cartService.GetCartItemIdAsync(newCartId, fifthMovie.Id);

            // Act
            await cartService.DeleteCartAsync(newCartId, userId);

            var isExist = await cartService.CartExistsAsync(userId);
            
            var isExistFirstCartItem = await cartService.CartItemExistsByIdAsync(newCartId, firstCartItemId);
            var isExistSecondCartItem = await cartService.CartItemExistsByIdAsync(newCartId, secondCartItemId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(isExist, Is.False);
                Assert.That(isExistFirstCartItem, Is.False);
                Assert.That(isExistSecondCartItem, Is.False);
            });
        }
        
        [Test]
        public async Task RemoveFromCartAsync_ShouldDeleteSingleCartItem()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            var thirdMovie = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);
            var fifthMovie = await movieService.MoviesDetailsByIdAsync(FifthMovie.Id);

            await cartService.CreateCartItemAsync(newCartId, thirdMovie);
            await cartService.CreateCartItemAsync(newCartId, fifthMovie);

            var firstCartItemId = await cartService.GetCartItemIdAsync(newCartId, thirdMovie.Id);
            var secondCartItemId = await cartService.GetCartItemIdAsync(newCartId, fifthMovie.Id);

            var cartCountBefore = await cartService.GetCartItemsCountAsync(newCartId);

            // Act
            await cartService.RemoveFromCartAsync(newCartId, firstCartItemId);

            var cartCountAfter = await cartService.GetCartItemsCountAsync(newCartId);

            var isExistFirstCartItem = await cartService.CartItemExistsByIdAsync(newCartId, firstCartItemId);
            var isExistSecondCartItem = await cartService.CartItemExistsByIdAsync(newCartId, secondCartItemId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(isExistFirstCartItem, Is.False);
                Assert.That(isExistSecondCartItem, Is.True);
                Assert.That(cartCountBefore, Is.EqualTo(2));
                Assert.That(cartCountAfter, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task GetCartItemsCountAsync_ShouldReturnCartItemsCount_WhenCartIsNotEmpty()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            var thirdMovie = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);
            var fifthMovie = await movieService.MoviesDetailsByIdAsync(FifthMovie.Id);

            await cartService.CreateCartItemAsync(newCartId, thirdMovie);
            await cartService.CreateCartItemAsync(newCartId, fifthMovie);

            // Act
            var cartCount = await cartService.GetCartItemsCountAsync(newCartId);       

            // Assert
            Assert.That(cartCount, Is.EqualTo(2));
        }

        [Test]
        public async Task GetCartItemsCountAsync_ShouldReturnZeroCount_WhenCartIsEmpty()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            
            // Act
            var cartCount = await cartService.GetCartItemsCountAsync(newCartId);

            // Assert
            Assert.That(cartCount, Is.EqualTo(0));
        }

        [Test]
        public async Task SumCartTotalAmountAsync_ShouldSumCartTotalAmount_WhenCartIsNotEmpty()
        {
            // Arrange
            var userId = "AdminUserId5";
            var newCartId = await cartService.CreateCartAsync(userId);
            var thirdMovie = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);
            var fifthMovie = await movieService.MoviesDetailsByIdAsync(FifthMovie.Id);

            await cartService.CreateCartItemAsync(newCartId, thirdMovie);
            await cartService.CreateCartItemAsync(newCartId, fifthMovie);

            // Act
            await cartService.SumCartTotalAmountAsync(newCartId);

            var cart = await cartService.GetCartServiceModelAsync(userId);
            var cartTotalAmount = await cartService.GetCartTotalAmountAsync(newCartId);
            
            // Assert
            Assert.That(cart.TotalAmount, Is.EqualTo(cartTotalAmount));
        }

        [Test]
        public async Task SumCartTotalAmountAsync_ShouldSumCartTotalAmount_WhenCartIsEmpty()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);

            // Act
            await cartService.SumCartTotalAmountAsync(newCartId);

            var cart = await cartService.GetCartServiceModelAsync(userId);
            var cartTotalAmount = await cartService.GetCartTotalAmountAsync(newCartId);

            // Assert
            Assert.That(cart.TotalAmount, Is.EqualTo(cartTotalAmount));
        }

        [Test]
        public async Task GetCartItemServiceModelAsync_ShouldReturnCartItemServiceModel()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            var thirdMovie = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);
            
            await cartService.CreateCartItemAsync(newCartId, thirdMovie);
            var cartItemId = await cartService.GetCartItemIdAsync(newCartId, thirdMovie.Id);
            
            // Act
            var cartItem = await cartService.GetCartItemServiceModelAsync(newCartId, cartItemId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(cartItem.CartItemId, Is.EqualTo(cartItemId));
                Assert.That(cartItem, Is.InstanceOf<CartItemServiceModel>());
            });
        }

        [Test]
        public async Task GetCartTotalAmountAsync_ShouldReturnCartTotalAmout_WhenCartIsNotEmpty()
        {
            // Arrange
            var userId = "AdminUserId6";
            var newCartId = await cartService.CreateCartAsync(userId);
            var thirdMovie = await movieService.MoviesDetailsByIdAsync(ThirdMovie.Id);
            var fifthMovie = await movieService.MoviesDetailsByIdAsync(FifthMovie.Id);

            await cartService.CreateCartItemAsync(newCartId, thirdMovie);
            await cartService.CreateCartItemAsync(newCartId, fifthMovie);
            await cartService.SumCartTotalAmountAsync(newCartId);

            var cart = await cartService.GetCartServiceModelAsync(userId);

            // Act
            var cartTotalAmount = await cartService.GetCartTotalAmountAsync(newCartId);

            // Assert
            Assert.That(cartTotalAmount, Is.EqualTo(cart.TotalAmount));            
        }

        [Test]
        public async Task GetCartTotalAmountAsync_ShouldReturnCartTotalAmout_WhenCartIsEmpty()
        {
            // Arrange
            var userId = AdminUser.Id;
            var newCartId = await cartService.CreateCartAsync(userId);
            var cart = await cartService.GetCartServiceModelAsync(userId);

            // Act
            var cartTotalAmount = await cartService.GetCartTotalAmountAsync(newCartId);

            // Assert
            Assert.That(cartTotalAmount, Is.EqualTo(cart.TotalAmount));
        }
    }
}
