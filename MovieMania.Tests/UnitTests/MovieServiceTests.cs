using MovieMania.Core.Contracts;
using MovieMania.Core.Models.Movie;
using MovieMania.Core.Services;
using NUnit.Framework.Internal;

namespace MovieMania.Tests.UnitTests
{
    [TestFixture]
    public class MovieServiceTests : UnitTestsBase
    {
        private IMovieService movieService;
        private IActorService actorService;
        private IDirectorService directorService;

        [OneTimeSetUp]
        public void SetUp()
        {
            actorService = new ActorService(unitOfWork);
            directorService = new DirectorService(unitOfWork);
            movieService = new MovieService(unitOfWork, actorService, directorService);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue_WithValidId()
        {
            // Arrange
            var movieId = FifthMovie.Id;

            // Act
            var movie = await movieService.ExistsAsync(movieId);

            // Assert
            Assert.IsTrue(movie);
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalse_WithInvalidId()
        {
            // Arrange
            var invalidId = 300;

            // Act
            var movie = await movieService.ExistsAsync(invalidId);

            // Assert
            Assert.IsFalse(movie);
        }

        [Test]
        public async Task AllGenresAsync_ShouldReturnAllGenres()
        {
            // Arrange

            // Act
            var genres = await movieService.AllGenresAsync();

            // Assert
            Assert.IsTrue(genres.Any());
        }

        [Test]
        public async Task GenreExistsAsync_ShouldReturnTrue_WithValidId()
        {
            // Arrange 
            var genreId = FirstGenre.Id;

            // Act
            var genre = await movieService.GenreExistsAsync(genreId);

            // Assert
            Assert.IsTrue(genre);
        }

        [Test]
        public async Task GenreExistsAsync_ShouldReturnFalse_WithInvalidId()
        {
            // Arrange 
            var invalidId = 300;

            // Act
            var genre = await movieService.GenreExistsAsync(invalidId);

            // Assert
            Assert.IsFalse(genre);
        }

        [Test]
        public async Task CreateAsync_ShouldCreateMovieSuccessfully()
        {
            // Arrange
            var movieFormModel = new MovieFormModel() 
            {
                Title = "New Test Movie Title",
                GenreId = 2,
                DirectorId = 2,
                ReleaseDate = 2001,
                Price = 29.99M,
                Description = "This is test description for the new movie. This is test description for the new movie. This is test description for the new movie.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b8/Just_Go_with_It_Poster.jpg"
            };

            //Act 
            var newMovieId = await movieService.CreateAsync(movieFormModel);
            var movieModel = await movieService.MoviesDetailsByIdAsync(newMovieId);

            // Assert
            Assert.IsNotNull(movieModel);
            Assert.That(newMovieId, Is.EqualTo(movieModel.Id));
        }

        [Test]
        public async Task AllAsync_ShouldReturnAllMovies_WithValidGenre()
        {
            // Arrange
            string firstGenreName = FirstGenre.Name;

            // Act
            var movies = await movieService.AllAsync(firstGenreName);
            var movieGenre = movies.Movies.First(c => c.Genre == firstGenreName);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(movies.TotalMoviesCount, Is.EqualTo(2));
                Assert.That(movieGenre.Genre, Is.EqualTo(firstGenreName));
                Assert.That(movies, Is.InstanceOf<MovieQueryServiceModel>());
            });
        }

        [Test]
        public async Task AllAsync_ShouldReturnEmpty_WithInvalidGenre()
        {
            // Arrange
            string invalidGenre = "Invalid Genre";

            // Act
            var movies = await movieService.AllAsync(invalidGenre);
            
            // Assert
            Assert.That(movies.TotalMoviesCount, Is.EqualTo(0));
            Assert.That(movies.Movies, Is.Empty);
        }

        [Test]
        public async Task AllGenresNamesAsync_ShouldReturnAllGenresNames()
        {
            // Arrange

            // Act
            var genreNames = await movieService.AllGenresNamesAsync();

            // Assert
            Assert.IsTrue(genreNames.Any());
        }

        [Test]
        public async Task MoviesDetailsByIdAsync_ShouldReturnMovieDetails_WithValidId()
        {
            // Arrange
            var movieId = ThirdMovie.Id;

            // Act 
            var movie = await movieService.MoviesDetailsByIdAsync(movieId);

            // Assert
            Assert.That(movie.Id, Is.EqualTo(movieId));
            Assert.IsInstanceOf<MovieDetailsServiceModel>(movie);
        }

        [Test]
        public async Task EditAsync_ShouldEditMovieSuccessfully()
        {
            // Arrange
            var newMovieFormModel = new MovieFormModel()
            {
                Title = "New Edited Test Movie Title",
                GenreId = 1,
                DirectorId = 1,
                ReleaseDate = 2011,
                Price = 29.99M,
                Description = "This is a edited test description. This is a edited test description. This is a edited test description.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b8/Just_Go_with_It_Poster.jpg"
            };

            // Act
            await movieService.EditAsync(SixthMovie.Id, newMovieFormModel);

            // Assert
            Assert.That(SixthMovie.Title, Is.EqualTo(newMovieFormModel.Title));
        }

        [Test]
        public async Task GetMovieFormModelByIdAsync_ShouldReturnCorrectMovieFormModel_WithValidId()
        {
            // Arrange
            var movieId = SecondMovie.Id;
            var secondMovieTitle = SecondMovie.Title;

            // Act
            var movie = await movieService.GetMovieFormModelByIdAsync(movieId);

            // Assert
            Assert.IsNotNull(movie);
            Assert.IsInstanceOf<MovieFormModel>(movie);
            Assert.That(movie.Title, Is.EqualTo(secondMovieTitle));
        }

        [Test]
        public async Task GetMovieFormModelByIdAsync_ShouldReturnNull_WithInvalidId()
        {
            // Arrange
            var invalidId = 300;

            // Act
            var movie = await movieService.GetMovieFormModelByIdAsync(invalidId);

            // Assert
            Assert.IsNull(movie);
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteMovieSuccessfully()
        {
            // Arrange
            var movieId = FirstMovie.Id;

            // Act
            await movieService.DeleteAsync(movieId);
            var movie = await movieService.ExistsAsync(movieId);

            // Assert
            Assert.IsFalse(movie);
        }

        [Test]
        public async Task LastFiveMoviesAsync_ShouldReturnCorrectMovies()
        {
            // Arrange

            // Act
            var movies = await movieService.LastFiveMoviesAsync();

            //Assert
            Assert.That(movies.Count(), Is.EqualTo(5));
        }
    }
}
