using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Director;
using MovieMania.Core.Services;
using System.Globalization;

namespace MovieMania.Tests.UnitTests
{
    public class DirectorServiceTests : UnitTestsBase
    {
        private IDirectorService directorService;

        [OneTimeSetUp]
        public void SetUp()
           => directorService = new DirectorService(unitOfWork);

        [Test]
        public async Task AllAsync_ShouldReturnAllDirectors()
        {
            // Arrange

            // Act
            var directors = await directorService.AllAsync();

            // Assert
            Assert.That(directors.TotalDirectorsCount, Is.EqualTo(3));
            Assert.IsInstanceOf<DirectorQueryServiceModel>(directors);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue_WithValidId()
        {
            // Arrange
            var directorId = FirstDirector.Id;

            // Act
            var director = await directorService.ExistsAsync(directorId);

            // Assert
            Assert.IsTrue(director);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalse_WithInvalidId()
        {
            // Arrange
            var invalidId = 400;

            // Act
            var director = await directorService.ExistsAsync(invalidId);

            // Assert
            Assert.IsFalse(director);
        }

        [Test]
        public async Task DirectorsDetailsByIdAsync_ShouldReturnCorrectDirector_WithValidId()
        {
            // Arrange
            var directorId = FirstDirector.Id;

            // Act
            var director = await directorService.DirectorsDetailsByIdAsync(directorId);

            // Assert
            Assert.IsNotNull(director);
            Assert.IsInstanceOf<DirectorDetailsServiceModel>(director);
        }

        [Test]
        public async Task CreateAsync_ShouldCreateDirectorSuccessfully()
        {
            // Arrange
            var directorFormModel = new DirectorFormModel() 
            {
                Name = "New Test Director Name",
                Bio = "This is a description of the new director. This is a description of the new director. This is a description of the new director.",
                BirthDate = DateTime.ParseExact("20/10/1944", "20/10/1944", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = ""
            };

            // Act
            var directorId = await directorService.CreateAsync(directorFormModel);
            var director = await directorService.ExistsAsync(directorId);

            // Assert
            Assert.IsTrue(director);
        }

        [Test]
        public async Task GetDirectorFormModelByIdAsync_ShouldReturnCorrectDirectorFormModel_WithValidId()
        {
            // Arrange
            var directorId = FirstDirector.Id;

            // Act
            var director = await directorService.GetDirectorFormModelByIdAsync(directorId);

            // Assert
            Assert.IsNotNull(director);
            Assert.IsInstanceOf<DirectorFormModel>(director);
        }

        [Test]
        public async Task GetDirectorFormModelByIdAsync_ShouldReturnNull_WithInvalidId()
        {
            // Arrange
            var invalidId = 400;

            // Act
            var director = await directorService.GetDirectorFormModelByIdAsync(invalidId);

            // Assert
            Assert.IsNull(director);
        }

        [Test]
        public async Task EditAsync_ShouldEditDirectorSuccessfully()
        {
            // Arrange
            var directorId = FirstDirector.Id;

            var directorFormModel = new DirectorFormModel()
            {
                Name = "Edited First Test Director",
                Bio = "This is a edited test description. This is a edited test description. This is a edited test description.",
                BirthDate = DateTime.ParseExact("20/10/1979", "20/10/1979", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/8/8f/Anna_Boden.jpg/revision/latest?cb=20190305123354"
            };

            // Act
            await directorService.EditAsync(directorId, directorFormModel);
            var editedDirector = await directorService.GetDirectorFormModelByIdAsync(directorId);

            // Assert
            Assert.That(editedDirector.Name, Is.EqualTo(directorFormModel.Name));
            Assert.That(editedDirector.Bio, Is.EqualTo(directorFormModel.Bio));
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteDirectorSuccessfully()
        {
            // Arrange
            var directorId = SecondDirector.Id;

            // Act
            await directorService.DeleteAsync(directorId);
            var director = await directorService.ExistsAsync(directorId);

            // Assert
            Assert.IsFalse(director);
        }

    }
}
