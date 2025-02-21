using MovieMania.Core.Contracts;
using MovieMania.Core.Services;

namespace MovieMania.Tests.UnitTests
{
    [TestFixture]
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService userService;

        [OneTimeSetUp]
        public void SetUp()
           => userService = new UserService(unitOfWork);

        [Test]
        public async Task UserFullNameAsync_ShouldReturnUserNamesSuccessfully_WithValidId()
        {
            // Arrange
            var userId = GuestUser.Id;
            // Act
            var userFullName = await userService.UserFullNameAsync(userId);

            // Assert
            Assert.That(userFullName, Is.EqualTo($"{GuestUser.FirstName} {GuestUser.LastName}"));
        }

        [Test]
        public async Task UserFullNameAsync_ShouldReturnStringEmpty_WithInvalidId()
        {
            // Arrange
            var invalidId = "InvalidId";
            // Act
            var userFullName = await userService.UserFullNameAsync(invalidId);

            // Assert
            Assert.IsEmpty(userFullName);
        }

        [Test]
        public async Task AllAsync_ShouldReturnAllUsersSuccessfully()
        {
            // Arrange

            // Act
            var users = await userService.AllAsync();

            // Assert
            Assert.That(users.Any(), Is.True);
            Assert.That(!users.Any(), Is.False);
        }
    }
}
