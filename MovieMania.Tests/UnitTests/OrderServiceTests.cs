using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Order;
using MovieMania.Core.Services;

namespace MovieMania.Tests.UnitTests
{
    [TestFixture]
    public class OrderServiceTests : UnitTestsBase
    {
        private IOrderService orderService;
        private ICartService cartService;

        [OneTimeSetUp]
        public void SetUp()
        {
            orderService = new OrderService(unitOfWork);
            cartService = new CartService(unitOfWork);
        }

        [Test]
        public async Task CreateAsync_ShouldCreateNewOrder()
        {
            // Arrange
            var userId = GuestUser.Id;
            var cartId = await cartService.GetCartIdAsync(userId);
            var totalCartAmount = await cartService.GetCartTotalAmountAsync(cartId);

            var orderModel = new OrderFormModel()
            {
                FirstName = GuestUser.FirstName,
                LastName = GuestUser.LastName,
                UserId = userId,
                Email = GuestUser.Email,
                Address = "Test Adress",
                City = "Test City",
                Country = "Test Country",
                Phone = "089123456",
                PostalCode = "1000",
                State = "Test State",
            };

            // Act
            var orderId = await orderService.CreateAsync(orderModel, userId, totalCartAmount);
            var isExist = await orderService.ExistsAsync(orderId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(isExist, Is.True);
                Assert.That(orderId, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue_WhenOrderExist()
        {
            var userId = GuestUser.Id;

            var cartId = await cartService.GetCartIdAsync(userId);
            var totalCartAmount = await cartService.GetCartTotalAmountAsync(cartId);

            var orderModel = new OrderFormModel()
            {
                FirstName = "Test user first name",
                LastName = GuestUser.LastName,
                UserId = userId,
                Email = GuestUser.Email,
                Address = "Test Adress Test",
                City = "Test City Test",
                Country = "Test Country Test",
                Phone = "089654321",
                PostalCode = "2000",
                State = "Test State Test",
            };

            var orderId = await orderService.CreateAsync(orderModel, userId, totalCartAmount);
            var order = await orderService.GetOrderServiceModelAsync(orderId, userId);

            // Act
            var isExist = await orderService.ExistsAsync(orderId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(isExist, Is.True);
                Assert.That(order.FirstName, Is.EqualTo(orderModel.FirstName));
                Assert.That(orderId, Is.EqualTo(order.OrderId));
            });
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalse_WhenOrderDoesNotExist()
        {
            // Arrange
            var invalidOrderId = 0;

            // Act
            var isExist = await orderService.ExistsAsync(invalidOrderId);

            // Assert
            Assert.That(isExist, Is.False);
        }

        [Test]
        public async Task CreateOrderDetailsAsync_ShouldCreateOrderDetails()
        {
            // Arrange
            var userId = GuestUser.Id;
            var cartId = await cartService.GetCartIdAsync(userId);
            var cartTotalAmount = await cartService.GetCartTotalAmountAsync(cartId);

            var orderModel = new OrderFormModel()
            {
                FirstName = "UserFirstNameTest",
                LastName = GuestUser.LastName,
                UserId = userId,
                Email = GuestUser.Email,
                Address = "UserAddressTest",
                City = "UserCityTest",
                Country = "UserCountryTest",
                Phone = "089654321",
                PostalCode = "2000",
                State = "UserStateTest",
            };

            var orderId = await orderService.CreateAsync(orderModel, userId, cartTotalAmount);
           
            // Act
            await orderService.CreateOrderDetailsAsync(cartId, orderId);

            var order = await orderService.GetOrderServiceModelAsync(orderId, userId);

            var firstOrderDetail = order.OrderDetails.Where(od => od.Title == FirstMovie.Title).FirstOrDefault();
            var secondOrderDetail = order.OrderDetails.Where(od => od.Title == SecondMovie.Title).FirstOrDefault();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(firstOrderDetail, Is.Not.Null);
                Assert.That(secondOrderDetail, Is.Not.Null);
            });
        }

        [Test]
        public async Task GetOrderServiceModelAsync_ShouldReturnOrderServiceModel()
        {
            // Arrange
            var userId = GuestUser.Id;
            var cartId = await cartService.GetCartIdAsync(userId);
            var cartTotalAmount = await cartService.GetCartTotalAmountAsync(cartId);

            var orderModel = new OrderFormModel()
            {
                FirstName = "UserFirstNameTest",
                LastName = GuestUser.LastName,
                UserId = userId,
                Email = GuestUser.Email,
                Address = "UserAddressTest",
                City = "UserCityTest",
                Country = "UserCountryTest",
                Phone = "089654321",
                PostalCode = "2000",
                State = "UserStateTest",
            };

            var orderId = await orderService.CreateAsync(orderModel, userId, cartTotalAmount);

            // Act
            var order = await orderService.GetOrderServiceModelAsync(orderId, userId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(order, Is.InstanceOf<OrderServiceModel>());
                Assert.That(order, Is.Not.Null);
            });
        }

        [Test]
        public async Task AllAsync_ShouldReturnAllOrders()
        {
            // Arrange

            // Act 
            var orders = await orderService.AllAsync();

            // Assert
            Assert.That(orders, Is.InstanceOf<IEnumerable<OrderServiceModel>>());
            Assert.That(orders, Is.Not.Null);
        }

        [Test]
        public async Task AllUserOrdersAsync_ShouldReturnUserOrders()
        {
            // Arrange
            string userId = GuestUser.Id;

            // Act 
            var orders = await orderService.AllUserOrdersAsync(userId);

            // Assert
            Assert.That(orders, Is.InstanceOf<IEnumerable<OrderServiceModel>>());
            Assert.That(orders, Is.Not.Null);
        }
    }
}
