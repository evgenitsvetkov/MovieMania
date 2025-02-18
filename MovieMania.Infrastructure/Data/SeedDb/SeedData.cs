using Microsoft.AspNetCore.Identity;
using MovieMania.Infrastructure.Data.Models.Actors;
using MovieMania.Infrastructure.Data.Models.CustomUser;
using MovieMania.Infrastructure.Data.Models.Directors;
using MovieMania.Infrastructure.Data.Models.Mappings;
using MovieMania.Infrastructure.Data.Models.Movies;
using System.Globalization;
using static MovieMania.Infrastructure.Constants.CustomClaims;
using static MovieMania.Infrastructure.Constants.DataConstants;

namespace MovieMania.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public ApplicationUser AdminUser { get; set; }

        public ApplicationUser GuestUser { get; set; }

        public IdentityUserClaim<string> AdminUserClaim { get; set; }

        public IdentityUserClaim<string> GuestUserClaim { get; set; }

        public Actor FirstActor { get; set; }

        public Actor SecondActor { get; set; }

        public Actor ThirdActor { get; set; }

        public Actor FourthActor { get; set; }

        public Actor FifthActor { get; set; }

        public Actor SixthActor { get; set; }

        public Actor SeventhActor { get; set; }

        public Actor EighthActor { get; set; }

        public Director FirstDirector { get; set; }

        public Director SecondDirector { get; set; }

        public Director ThirdDirector { get; set; }

        public Director FourthDirector { get; set; }

        public Director FifthDirector { get; set; }

        public Director SixthDirector { get; set; }

        public Director SeventhDirector { get; set; }

        public Genre ActionGenre { get; set; }

        public Genre ComedyGenre { get; set; }

        public Genre AdventureGenre { get; set; }

        public Genre DramaGenre { get; set; }

        public Genre HistoryGenre { get; set; }

        public Genre BiographyGenre { get; set; }

        public Genre RomanceGenre { get; set; }

        public Genre CrimeGenre { get; set; }

        public Movie FirstMovie { get; set; }

        public Movie SecondMovie { get; set; }

        public Movie ThirdMovie { get; set; }

        public Movie FourthMovie { get; set; }

        public Movie FifthMovie { get; set; }

        public Movie SixthMovie { get; set; }

        public Movie SeventhMovie { get; set; }

        public Movie EighthMovie { get; set; }

        public MovieActor FirstMovieActor { get; set; }

        public MovieActor SecondMovieActor { get; set; }

        public MovieActor ThirdMovieActor { get; set; }

        public MovieActor FourthMovieActor { get; set; }

        public MovieActor FifthMovieActor { get; set; }

        public MovieActor SixthMovieActor { get; set; }

        public MovieActor SeventhMovieActor { get; set; }

        public MovieActor EighthMovieActor { get; set; }

        public MovieActor NinthMovieActor { get; set; }

        public MovieActor TenthMovieActor { get; set; }

        public MovieActor EleventhMovieActor { get; set; }

        public MovieActor TwelfthMovieActor { get; set; }

        public MovieActor ThirteenthMovieActor { get; set; }

        public MovieActor FourteenthMovieActor { get; set; }

        public MovieActor FifteenthMovieActor { get; set; }

        public MovieActor SixteenthMovieActor { get; set; }

        public MovieActor SeventeenthMovieActor { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedActors();
            SeedDirectors();
            SeedGenres();
            SeedMovies();
            SeedMovieActors();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com",
                FirstName = "Evgeni",
                LastName = "Tsvetkov"
            };

            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 1,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Evgeni Tsvetkov",
                UserId = "dea12856-c198-4129-b3f3-b893d8395082",
            };

            AdminUser.PasswordHash =
                hasher.HashPassword(AdminUser, "admin1233");

            GuestUser = new ApplicationUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Guest",
                LastName = "Guestt"
            };

            GuestUserClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Guest Guestt",
                UserId = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"
            };

            GuestUser.PasswordHash =
                hasher.HashPassword(GuestUser, "guest1233");
        }

        private void SeedActors()
        {
            FirstActor = new Actor()
            {
                Id = 1,
                Name = "Jeniffer Aniston",
                Bio = "Jennifer Aniston is an American actress. She rose to international fame for her role as Rachel Green on the television sitcom Friends from 1994 to 2004, which earned her Primetime Emmy, Golden Globe, and Screen Actors Guild awards.",
                BirthDate = DateTime.ParseExact("11.02.1969", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/1/16/JenniferAnistonHWoFFeb2012.jpg"
            };

            SecondActor = new Actor()
            {
                Id = 2,
                Name = "Adam Sandler",
                Bio = "Adam Sandler is an American actor and comedian. Primarily a comedic leading actor in films, his accolades include nominations for three Grammy Awards, five Primetime Emmy Awards, a Golden Globe Award, and a Screen Actors Guild Award. Sandler was awarded the Mark Twain Prize for American Humor.",
                BirthDate = DateTime.ParseExact("09.09.1966", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/39/Adam_Sandler_at_Berlinale_2024.jpg/800px-Adam_Sandler_at_Berlinale_2024.jpg"
            };

            ThirdActor = new Actor()
            {
                Id = 3,
                Name = "Jonah Hill",
                Bio = "Jonah Hill is an American actor, director and screenwriter. He is known for his comedic roles in films including Superbad, Knocked Up, 21 Jump Street. For his performances in Moneyball and The Wolf of Wall Street, he was nominated for the Academy Award for Best Supporting Actor.",
                BirthDate = DateTime.ParseExact("20.12.1983", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Jonah_Hill-4939_%28cropped%29_%28cropped%29.jpg/1024px-Jonah_Hill-4939_%28cropped%29_%28cropped%29.jpg"
            };

            FourthActor = new Actor()
            {
                Id = 4,
                Name = "Leonardo DiCaprio",
                Bio = "Leonardo DiCaprio is an American actor and film producer. Known for his work in biographical and period films, he is the recipient of numerous accolades, including an Academy Award, a British Academy Film Award, and three Golden Globe Awards. ",
                BirthDate = DateTime.ParseExact("11.11.1974", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://www.usmagazine.com/wp-content/uploads/2024/01/Stars-Who-Are-Continually-Snubbed-by-the-Oscars-Leonardo-DiCaprio-Margot-Robbie-and-More-4.jpg?w=800&h=1421&crop=1&quality=86&strip=all"
            };

            FifthActor = new Actor()
            {
                Id = 5,
                Name = "Cillian Murphy",
                Bio = "Cillian Murphy is an Irish actor. He made his professional debut in Enda Walsh's 1996 play Disco Pigs, a role he later reprised in the 2001 screen adaptation. He gained greater prominence for his role as Tommy Shelby in the BBC period drama series Peaky Blinders.",
                BirthDate = DateTime.ParseExact("25.05.1976", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://i0.wp.com/www.thewrap.com/wp-content/uploads/2016/04/Cillian-Murphy.jpg?w=618&ssl=1"
            };

            SixthActor = new Actor()
            {
                Id = 6,
                Name = "Robert Downey Jr.",
                Bio = "Robert Downey Jr. is an American actor. His career has been characterized by some early success, a period of drug-related problems and run-ins with the law, and a surge in population and commercial success in the 2000s. In 2008, Downey was named by Time magazine as one of the 100 most influential people in the world.",
                BirthDate = DateTime.ParseExact("04.04.1965", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/94/Robert_Downey_Jr_2014_Comic_Con_%28cropped%29.jpg"
            };

            SeventhActor = new Actor()
            {
                Id = 7,
                Name = "Samuel L. Jackson",
                Bio = "Samuel L. Jackson is an American actor. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time. In 2022, he received the Academy Honorary Award as a cultural icon whose dynamic work has resonated across genres and generations and audiences worldwide.",
                BirthDate = DateTime.ParseExact("21.12.1948", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/SamuelLJackson.jpg/800px-SamuelLJackson.jpg"
            };

            EighthActor = new Actor()
            {
                Id = 8,
                Name = "Brie Larson",
                Bio = "Brianne Desaulniers, known professionally as Brie Larson, is an American actress. Known for her supporting roles in comedies as a teenager, she has since expanded to leading roles in independent films and blockbusters. She has received various accolades, including an Academy Award, a Golden Globe Award, and a Primetime Emmy Award.",
                BirthDate = DateTime.ParseExact("01.10.1989", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Captain_Marvel_trailer_at_the_National_Air_and_Space_Museum_4_%28cropped%29.jpg/1024px-Captain_Marvel_trailer_at_the_National_Air_and_Space_Museum_4_%28cropped%29.jpg"
            };
        }

        private void SeedDirectors()
        {
            FirstDirector = new Director()
            {
                Id = 1,
                Name = "Anna Boden",
                Bio = "Anna Boden is an American film director, cinematographer, editor, andscreenwriter best known as the co-writer of the 2006 film Half Nelson.She is known for her collaborations with fellow filmmaker Ryan Fleck.",
                BirthDate = DateTime.ParseExact("20.10.1979", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/8/8f/Anna_Boden.jpg/revision/latest?cb=20190305123354"
            };

            SecondDirector = new Director()
            {
                Id = 2,
                Name = "Judd Apatow",
                Bio = "Judd Apatow is an American director, producer and screenwriter, best known for his work in comedy films. He is the founder of Apatow Productions. Throughout his career, Apatow has received nominations for 11 Primetime Emmy Awards, five Writers Guild of America Awards, two Producers Guild of America Awards, one Golden Globe Award and one Grammy Award.",
                BirthDate = DateTime.ParseExact("09.12.1967", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/3/3b/2024-03-08_SXSW-2024_comedy-directors_3.jpg"
            };

            ThirdDirector = new Director()
            {
                Id = 3,
                Name = "Jeremy Garelick",
                Bio = "After graduating from college, Garelick began his career working as an assistant in Creative Artists Agency's Motion Picture Literary department. He served as the assistant to director Joel Schumacher on Tigerland, Bad Company, and Phone Booth. He was the second unit director on Schumacher’s 2003 movie Veronica Guerin.",
                BirthDate = DateTime.ParseExact("30.11.1975", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/c/c4/Jeremy_Garelick.png"
            };

            FourthDirector = new Director()
            {
                Id = 4,
                Name = "Martin Scorsese",
                Bio = "Martin Scorsese is an American filmmaker. he emerged as one of the major figures of the New Hollywood era. Scorsese has received many accolades, including an Academy Award, four BAFTA Awards, three Emmy Awards, a Grammy Award, three Golden Globe Awards, and two Directors Guild of America Awards. He has been honored with the AFI Life Achievement Award in 1997.",
                BirthDate = DateTime.ParseExact("17.11.1942", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/57/Martin_Scorsese-68754.jpg/800px-Martin_Scorsese-68754.jpg"
            };

            FifthDirector = new Director()
            {
                Id = 5,
                Name = "Christopher Nolan",
                Bio = "Christopher Nolan is a British and American filmmaker. Known for his Hollywood blockbusters with complex storytelling, he is considered a leading filmmaker of the 21st century.  His accolades include two Academy Awards and two British Academy Film Awards. Nolan was appointed as a Commander of the Order of the British Empire in 2019, and received a knighthood in 2024 for his contributions to film.",
                BirthDate = DateTime.ParseExact("30.07.1970", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/95/Christopher_Nolan_Cannes_2018.jpg"
            };

            SixthDirector = new Director()
            {
                Id = 6,
                Name = "Anthony Russo",
                Bio = "Anthony Russo and Joseph Russo collectively known as the Russo brothers, are American directors, producers, and screenwriters. They direct most of their work together. They are best known for directing four films in the Marvel Cinematic Universe: Captain America: The Winter Soldier, Captain America: Civil War, Avengers: Infinity War, and Avengers: Endgame.",
                BirthDate = DateTime.ParseExact("03.02.1970", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://imageio.forbes.com/specials-images/imageserve/62ca4312f62dcb9b9e34a6e9/Russo-Brothers---Exterior-horizontal/960x0.jpg?format=jpg&width=1440"
            };

            SeventhDirector = new Director()
            {
                Id = 7,
                Name = "Dennis Dugan",
                Bio = "Dennis Dugan is an American film director, actor, and comedian. He is known for directing the films Problem Child, Brain Donors, Beverly Hills Ninja and National Security, and his partnership with comedic actor Adam Sandler, for whom he directed the films Happy Gilmore, Big Daddy, The Benchwarmers, I Now Pronounce You Chuck & Larry etc.",
                BirthDate = DateTime.ParseExact("05.09.1943", DateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None),
                ImageUrl = "https://images.hobbydb.com/processed_uploads/subject_photo/subject_photo/image/49245/1553650458-4334-5610/Dennis_20Dugan_large.jpg"
            };
        }

        private void SeedGenres()
        {
            ActionGenre = new Genre()
            {
                Id = 1,
                Name = "Action"
            };

            AdventureGenre = new Genre()
            {
                Id = 2,
                Name = "Adventure"
            };

            ComedyGenre = new Genre()
            {
                Id = 3,
                Name = "Comedy"
            };

            DramaGenre = new Genre()
            {
                Id = 4,
                Name = "Drama"
            };

            CrimeGenre = new Genre()
            {
                Id = 5,
                Name = "Crime"
            };

            BiographyGenre = new Genre()
            {
                Id = 6,
                Name = "Biography"
            };

            HistoryGenre = new Genre()
            {
                Id = 7,
                Name = "History"
            };

            RomanceGenre = new Genre()
            {
                Id = 8,
                Name = "Romance"
            };
        }

        private void SeedMovies()
        {
            FirstMovie = new Movie()
            {
                Id = 1,
                Title = "Just Go with It",
                GenreId = 3,
                ReleaseDate = 2011,
                Price = 29.99M,
                Description = "On a weekend trip to Hawaii, a plastic surgeon convinces his loyal assistant to pose as his soon-to-be-divorced wife in order to cover up a careless lie he told to his much-younger girlfriend.",
                DirectorId = 7,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/b/b8/Just_Go_with_It_Poster.jpg"
            };

            SecondMovie = new Movie()
            {
                Id = 2,
                Title = "The Wolf of Wall Street",
                GenreId = 6,
                ReleaseDate = 2013,
                Price = 35.99M,
                Description = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.",
                DirectorId = 4,
                ImageURL = "https://moviesfilmsandflix.files.wordpress.com/2013/12/wolf-of-wall-street.jpg"
            };

            ThirdMovie = new Movie()
            {
                Id = 3,
                Title = "Murder Mystery 2",
                GenreId = 3,
                ReleaseDate = 2023,
                Price = 59.99M,
                Description = "Full-time detectives Nick and Audrey are struggling to get their private eye agency off the ground. They find themselves at the center of international abduction when their friend Maharaja is kidnapped at his own lavish wedding.",
                DirectorId = 3,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/7/71/Murder_Mystery_2_poster.png"
            };

            FourthMovie = new Movie()
            {
                Id = 4,
                Title = "Inception",
                GenreId = 1,
                ReleaseDate = 2010,
                Price = 25.99M,
                Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.",
                DirectorId = 5,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg"
            };

            FifthMovie = new Movie()
            {
                Id = 5,
                Title = "Funny People",
                GenreId = 3,
                ReleaseDate = 2009,
                Price = 19.99M,
                Description = "When seasoned comedian George Simmons learns of his terminal, inoperable health condition, his desire to form a genuine friendship causes him to take a relatively green performer under his wing as his opening act.",
                DirectorId = 2,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/2/26/PosterFunnyPeople.jpg"
            };

            SixthMovie = new Movie()
            {
                Id = 6,
                Title = "Captain Marvel",
                GenreId = 2,
                ReleaseDate = 2019,
                Price = 49.99M,
                Description = "Carol Danvers becomes one of the universe's most powerful heroes when Earth is caught in the middle of a galactic war between two alien races.",
                DirectorId = 1,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/4/4e/Captain_Marvel_%28film%29_poster.jpg"
            };

            SeventhMovie = new Movie()
            {
                Id = 7,
                Title = "Oppenheimer",
                GenreId = 4,
                ReleaseDate = 2023,
                Price = 69.99M,
                Description = "The story of American scientist J. Robert Oppenheimer and his role in the development of the atomic bomb.",
                DirectorId = 5,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/4/4a/Oppenheimer_%28film%29.jpg"
            };

            EighthMovie = new Movie()
            {
                Id = 8,
                Title = "Avengers: Endgame",
                GenreId = 1,
                ReleaseDate = 2019,
                Price = 65.99M,
                Description = "After the devastating events of Avengers: Infinity War, the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                DirectorId = 6,
                ImageURL = "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg"
            };
        }

        private void SeedMovieActors()
        {
            FirstMovieActor = new MovieActor()
            {
                ActorId = 1,
                MovieId = 1,
            };

            SecondMovieActor = new MovieActor()
            {
                ActorId = 2,
                MovieId = 1,
            };

            ThirdMovieActor = new MovieActor()
            {
                ActorId = 3,
                MovieId = 2,
            };

            FourthMovieActor = new MovieActor()
            {
                ActorId = 4,
                MovieId = 2,
            };

            FifthMovieActor = new MovieActor()
            {
                ActorId = 1,
                MovieId = 3,
            };

            SixthMovieActor = new MovieActor()
            {
                ActorId = 2,
                MovieId = 3,
            };

            SeventhMovieActor = new MovieActor()
            {
                ActorId = 4,
                MovieId = 4,
            };

            EighthMovieActor = new MovieActor()
            {
                ActorId = 5,
                MovieId = 4,
            };

            NinthMovieActor = new MovieActor()
            {
                ActorId = 2,
                MovieId = 5,
            };

            TenthMovieActor = new MovieActor()
            {
                ActorId = 3,
                MovieId = 5,
            };

            EleventhMovieActor = new MovieActor()
            {
                ActorId = 7,
                MovieId = 6,
            };

            TwelfthMovieActor = new MovieActor()
            {
                ActorId = 8,
                MovieId = 6,
            };

            ThirteenthMovieActor = new MovieActor()
            {
                ActorId = 5,
                MovieId = 7,
            };

            FourteenthMovieActor = new MovieActor()
            {
                ActorId = 6,
                MovieId = 7,
            };

            FifteenthMovieActor = new MovieActor()
            {
                ActorId = 6,
                MovieId = 8,
            };

            SixteenthMovieActor = new MovieActor()
            {
                ActorId = 7,
                MovieId = 8,
            };

            SeventeenthMovieActor = new MovieActor()
            {
                ActorId = 8,
                MovieId = 8,
            };
        }

    }
}
