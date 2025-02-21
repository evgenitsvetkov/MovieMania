using Microsoft.AspNetCore.Identity;
using MovieMania.Infrastructure.Data;
using MovieMania.Infrastructure.Data.Common;
using MovieMania.Infrastructure.Data.Models.Actors;
using MovieMania.Infrastructure.Data.Models.Carts;
using MovieMania.Infrastructure.Data.Models.CustomUser;
using MovieMania.Infrastructure.Data.Models.Directors;
using MovieMania.Infrastructure.Data.Models.Mappings;
using MovieMania.Infrastructure.Data.Models.Movies;
using MovieMania.Tests.Mocks;
using System.Globalization;
using System.Xml.Linq;

namespace MovieMania.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected MovieManiaDbContext data;
        protected IUnitOfWork unitOfWork;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            data = DatabaseMock.Instance;
            unitOfWork = new UnitOfWork(data);
            SeedDatabase();
        }

        public ApplicationUser AdminUser { get; private set; }

        public ApplicationUser GuestUser { get; private set; }

        public IdentityUserClaim<string> AdminUserClaim { get; set; } = null!;

        public IdentityUserClaim<string> GuestUserClaim { get; set; } = null!;

        public Movie FirstMovie { get; private set; }

        public Movie SecondMovie { get; private set; }

        public Movie ThirdMovie { get; private set; }

        public Movie FourthMovie { get; private set; }

        public Movie FifthMovie { get; private set; }

        public Movie SixthMovie { get; private set; }

        public Director FirstDirector { get; private set; }

        public Director SecondDirector { get; private set; }

        public Director ThirdDirector { get; private set; }

        public Actor FirstActor { get; private set; }

        public Actor SecondActor { get; private set;}

        public Actor ThirdActor { get; private set; }

        public Genre FirstGenre { get; private set; }

        public Genre SecondGenre { get; private set; }

        public Genre ThirdGenre { get; private set; }

        public MovieActor FirstMovieActor { get; private set; } = null!;

        public MovieActor SecondMovieActor { get; private set; } = null!;

        public MovieActor ThirdMovieActor { get; private set; } = null!;

        public Cart FirstCart { get; private set; } = null!;

        public CartItem FirstCartItem { get; private set; } = null!;

        public CartItem SecondCartItem { get; private set; } = null!;

        private void SeedDatabase()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "AdminUserId",
                Email = "admin@user.bg",
                FirstName = "Admin",
                LastName = "User"
            };

            data.Users.Add(AdminUser);

            GuestUser = new ApplicationUser()
            {
                Id = "GuestUserId",
                Email = "guest@user.bg",
                FirstName = "Guest",
                LastName = "User"
            };

            data.Users.Add(GuestUser);

            FirstMovie = new Movie()
            {
                Title = "First Test Movie",
                GenreId = 1,
                ReleaseDate = 2011,
                Price = 29.99M,
                Description = "This is a test description. This is a test description. This is a test description.",
                DirectorId = 1,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/b/b8/Just_Go_with_It_Poster.jpg"
            };

            data.Movies.Add(FirstMovie);

            SecondMovie = new Movie()
            {
                Title = "Second Test Movie",
                GenreId = 2,
                ReleaseDate = 2012,
                Price = 39.99M,
                Description = "This is a test description. This is a test description. This is a test description.",
                DirectorId = 2,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/b/b8/Just_Go_with_It_Poster.jpg"
            };

            data.Movies.Add(SecondMovie);

            ThirdMovie = new Movie()
            {
                Title = "Third Test Movie",
                GenreId = 3,
                ReleaseDate = 2013,
                Price = 49.99M,
                Description = "This is a test description. This is a test description. This is a test description.",
                DirectorId = 3,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/b/b8/Just_Go_with_It_Poster.jpg"
            };

            data.Movies.Add(ThirdMovie);

            FourthMovie = new Movie()
            {
                Title = "Fourth Test Movie",
                GenreId = 1,
                ReleaseDate = 2008,
                Price = 19.99M,
                Description = "This is a test description. This is a test description. This is a test description.",
                DirectorId = 1,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/b/b8/Just_Go_with_It_Poster.jpg"
            };

            data.Movies.Add(FourthMovie);

            FifthMovie = new Movie()
            {
                Title = "Fifth Test Movie",
                GenreId = 2,
                ReleaseDate = 2007,
                Price = 19.99M,
                Description = "This is a test description. This is a test description. This is a test description.",
                DirectorId = 2,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/b/b8/Just_Go_with_It_Poster.jpg"
            };

            data.Movies.Add(FifthMovie);

            SixthMovie = new Movie()
            {
                Title = "Sixth Test Movie",
                GenreId = 3,
                ReleaseDate = 2006,
                Price = 39.99M,
                Description = "This is a test description. This is a test description. This is a test description.",
                DirectorId = 3,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/b/b8/Just_Go_with_It_Poster.jpg"
            };

            data.Movies.Add(SixthMovie);

            FirstDirector = new Director()
            {
                Name = "First Test Director",
                Bio = "This is a test description. This is a test description. This is a test description.",
                BirthDate = DateTime.ParseExact("20/10/1979", "20/10/1979", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/8/8f/Anna_Boden.jpg/revision/latest?cb=20190305123354"
            };

            data.Directors.Add(FirstDirector);

            SecondDirector = new Director()
            {
                Name = "Second Test Director",
                Bio = "This is a test description. This is a test description. This is a test description.",
                BirthDate = DateTime.ParseExact("10/5/2000", "10/5/2000", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/8/8f/Anna_Boden.jpg/revision/latest?cb=20190305123354"
            };

            data.Directors.Add(SecondDirector);

            ThirdDirector = new Director()
            {
                Name = "Third Test Director",
                Bio = "This is a test description. This is a test description. This is a test description.",
                BirthDate = DateTime.ParseExact("5/5/2001", "5/5/2001", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/8/8f/Anna_Boden.jpg/revision/latest?cb=20190305123354"
            };

            data.Directors.Add(ThirdDirector);

            FirstActor = new Actor()
            {
                Name = "First Test Actor",
                Bio = "This is a test description. This is a test description. This is a test description.",
                BirthDate = DateTime.ParseExact("11/02/1969", "11/02/1969", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/16/JenniferAnistonHWoFFeb2012.jpg"
            };

            data.Actors.Add(FirstActor);

            SecondActor = new Actor()
            {
                Name = "Second Test Actor",
                Bio = "This is a test description. This is a test description. This is a test description.",
                BirthDate = DateTime.ParseExact("20/10/1979", "20/10/1979", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/16/JenniferAnistonHWoFFeb2012.jpg"
            };

            data.Actors.Add(SecondActor);

            ThirdActor = new Actor()
            {
                Name = "Third Test Actor",
                Bio = "This is a test description. This is a test description. This is a test description.",
                BirthDate = DateTime.ParseExact("10/5/2000", "10/5/2000", CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/16/JenniferAnistonHWoFFeb2012.jpg"
            };

            data.Actors.Add(ThirdActor);

            FirstGenre = new Genre()
            {
                Name = "First Test Genre",
            };

            data.Genres.Add(FirstGenre);

            SecondGenre = new Genre()
            {
                Name = "Second Test Genre",
            };

            data.Genres.Add(SecondGenre);

            ThirdGenre = new Genre()
            {
                Name = "Third Test Genre",
            };

            data.Genres.Add(ThirdGenre);

            FirstCart = new Cart()
            {
                CartId = 2,
                UserId = GuestUser.Id,
                CartItems = new List<CartItem>(),
                TotalAmount = 0,
            };

            data.Carts.Add(FirstCart);

            FirstCartItem = new CartItem()
            {
                CartItemId = 1,
                CartId = 2,
                Quantity = 1,
                MovieId = FirstMovie.Id,
                ItemTotal = FirstMovie.Price,
            };

            data.CartItems.Add(FirstCartItem);

            SecondCartItem = new CartItem()
            {
                CartItemId = 2,
                CartId = 2,
                Quantity = 1,
                MovieId = SecondMovie.Id,
                ItemTotal = SecondMovie.Price,
            };

            data.CartItems.Add(SecondCartItem);

            data.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase()
          => data.Dispose();
    }
}
