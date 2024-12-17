using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Actor;
using MovieMania.Core.Services;
using System.Globalization;

namespace MovieMania.Tests.UnitTests
{
    public class ActorServiceTests : UnitTestsBase
    {
        private IActorService actorService;

        [OneTimeSetUp]
        public void SetUp()
            => actorService = new ActorService(unitOfWork);

        [Test]
        public async Task AllAsync_ShouldReturnAllActors()
        {
            // Arrange

            // Act
            var actors = await actorService.AllAsync();

            // Assert
            Assert.That(actors.TotalActorsCount, Is.EqualTo(3));
            Assert.IsInstanceOf<ActorQueryServiceModel>(actors);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue_WithValidId()
        {
            // Arrange
            var actorId = FirstActor.Id;

            // Act
            var actor = await actorService.ExistsAsync(actorId);

            // Assert
            Assert.IsTrue(actor);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalse_WithInvalidId()
        {
            // Arrange
            var invalidId = 200;

            // Act
            var actor = await actorService.ExistsAsync(invalidId);

            // Assert
            Assert.IsFalse(actor);
        }

        [Test]
        public async Task ActorsDetailsByIdAsync_ShouldReturnCorrectActor_WithValidId()
        {
            // Arrange
            var actorId = SecondActor.Id;

            // Act
            var actorDetails = await actorService.ActorsDetailsByIdAsync(actorId);

            // Assert
            Assert.IsNotNull(actorDetails);
            Assert.IsInstanceOf<ActorDetailsServiceModel>(actorDetails);
        }

        [Test]
        public async Task CreateAsync_ShouldCreateActorSuccessfully()
        {
            // Arrange
            var actorFormModel = new ActorFormModel()
            {
                Name = "New Test Actor",
                Bio = "This is newest test actor. This is newest test actor. This is newest test actor.",
                BirthDate = DateTime.Now,
                ImageUrl = ""
            };

            // Act
            var newActorId = await actorService.CreateAsync(actorFormModel);
            var actor = await actorService.ExistsAsync(newActorId);

            // Assert
            Assert.IsTrue(actor);
        }

        [Test]
        public async Task GetActorFormModelByIdAsync_ShouldReturnCorrectActorFormModel_WithValidId()
        {
            // Arrange
            var actorId = SecondActor.Id;

            // Act
            var actorFormModel = await actorService.GetActorFormModelByIdAsync(actorId);

            // Assert
            Assert.IsNotNull(actorFormModel);
            Assert.IsInstanceOf<ActorFormModel>(actorFormModel);
        }

        [Test]
        public async Task GetActorFormModelByIdAsync_ShouldReturnNull_WithInvalidId()
        {
            // Arrange
            var actorId = 200;

            // Act
            var actorFormModel = await actorService.GetActorFormModelByIdAsync(actorId);

            // Assert
            Assert.IsNull(actorFormModel);
        }

        [Test]
        public async Task EditAsync_ShouldEditActorSuccessfully()
        {
            // Arrange
            var actorFormModel = new ActorFormModel()
            {
                Name = "Edited Second Test Actor",
                Bio = "This is a edited test description. This is a edited test description. This is a edited test description.",
                BirthDate = DateTime.ParseExact("20/10/1979", "20/10/1979", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/16/JenniferAnistonHWoFFeb2012.jpg"
            };

            // Act
            await actorService.EditAsync(SecondActor.Id, actorFormModel);
            var editedActor = await actorService.GetActorFormModelByIdAsync(SecondActor.Id);

            // Assert
            Assert.That(editedActor.Name, Is.EqualTo(actorFormModel.Name));
            Assert.That(editedActor.Bio, Is.EqualTo(actorFormModel.Bio));
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteActorSuccessfully()
        {
            // Arrange
            var actorId = ThirdActor.Id;

            // Act
            await actorService.DeleteAsync(actorId);
            var actor = await actorService.ExistsAsync(actorId);

            // Assert
            Assert.IsFalse(actor);
        }
    }
}
