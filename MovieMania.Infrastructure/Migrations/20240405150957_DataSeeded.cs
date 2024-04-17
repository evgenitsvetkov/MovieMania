using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "Movie's description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Movie's description");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Director",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                comment: "Director's bio",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "Director's bio");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Actors",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                comment: "Actor's bio",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "Actor's bio");

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Bio", "BirthDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Jennifer Aniston is an American actress. She rose to international fame for her role as Rachel Green on the television sitcom Friends from 1994 to 2004, which earned her Primetime Emmy, Golden Globe, and Screen Actors Guild awards.", new DateTime(1969, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/1/16/JenniferAnistonHWoFFeb2012.jpg", "Jeniffer Aniston" },
                    { 2, "Adam Sandler is an American actor and comedian. Primarily a comedic leading actor in films, his accolades include nominations for three Grammy Awards, five Primetime Emmy Awards, a Golden Globe Award, and a Screen Actors Guild Award. Sandler was awarded the Mark Twain Prize for American Humor.", new DateTime(1966, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/thumb/3/39/Adam_Sandler_at_Berlinale_2024.jpg/800px-Adam_Sandler_at_Berlinale_2024.jpg", "Adam Sandler" },
                    { 3, "Jonah Hill is an American actor, director and screenwriter. He is known for his comedic roles in films including Superbad, Knocked Up, 21 Jump Street. For his performances in Moneyball and The Wolf of Wall Street, he was nominated for the Academy Award for Best Supporting Actor.", new DateTime(1983, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Jonah_Hill-4939_%28cropped%29_%28cropped%29.jpg/1024px-Jonah_Hill-4939_%28cropped%29_%28cropped%29.jpg", "Jonah Hill" },
                    { 4, "Leonardo DiCaprio is an American actor and film producer. Known for his work in biographical and period films, he is the recipient of numerous accolades, including an Academy Award, a British Academy Film Award, and three Golden Globe Awards. ", new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://www.usmagazine.com/wp-content/uploads/2024/01/Stars-Who-Are-Continually-Snubbed-by-the-Oscars-Leonardo-DiCaprio-Margot-Robbie-and-More-4.jpg?w=800&h=1421&crop=1&quality=86&strip=all", "Leonardo DiCaprio" },
                    { 5, "Cillian Murphy is an Irish actor. He made his professional debut in Enda Walsh's 1996 play Disco Pigs, a role he later reprised in the 2001 screen adaptation. He gained greater prominence for his role as Tommy Shelby in the BBC period drama series Peaky Blinders.", new DateTime(1976, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://i0.wp.com/www.thewrap.com/wp-content/uploads/2016/04/Cillian-Murphy.jpg?w=618&ssl=1", "Cillian Murphy" },
                    { 6, "Robert Downey Jr. is an American actor. His career has been characterized by some early success, a period of drug-related problems and run-ins with the law, and a surge in population and commercial success in the 2000s. In 2008, Downey was named by Time magazine as one of the 100 most influential people in the world.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/9/94/Robert_Downey_Jr_2014_Comic_Con_%28cropped%29.jpg", "Robert Downey Jr." },
                    { 7, "Samuel L. Jackson is an American actor. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time. In 2022, he received the Academy Honorary Award as a cultural icon whose dynamic work has resonated across genres and generations and audiences worldwide.", new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/SamuelLJackson.jpg/800px-SamuelLJackson.jpg", "Samuel L. Jackson" },
                    { 8, "Brianne Desaulniers, known professionally as Brie Larson, is an American actress. Known for her supporting roles in comedies as a teenager, she has since expanded to leading roles in independent films and blockbusters. She has received various accolades, including an Academy Award, a Golden Globe Award, and a Primetime Emmy Award.", new DateTime(1989, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/Captain_Marvel_trailer_at_the_National_Air_and_Space_Museum_4_%28cropped%29.jpg/1024px-Captain_Marvel_trailer_at_the_National_Air_and_Space_Museum_4_%28cropped%29.jpg", "Brie Larson" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "910df93c-401e-44fa-a7e5-ff39097f065a", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEHcn4uPHLmVRSNich+Vkzo+vy+TC8ck0V3MK2E9X9hvWjsXW00CKnQx5xsGacw/hLQ==", null, false, "264be395-c655-4d88-b4d3-9eb61c807a81", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "940fba24-8f41-4f38-9f0d-7666fd30cbde", "admin@mail.com", false, false, null, "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAELjoPaCNSZRc1ugaQ5ngLMS9W1VF139euvg5JlAzJ3sy6enf/459DTQgZzYhsi8g4A==", null, false, "c8067d0b-0301-4c00-90b8-f358db2633ed", false, "admin@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "Bio", "BirthDate", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Anna Boden is an American film director, cinematographer, editor, andscreenwriter best known as the co-writer of the 2006 film Half Nelson.She is known for her collaborations with fellow filmmaker Ryan Fleck.", new DateTime(1979, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://static.wikia.nocookie.net/marvelcinematicuniverse/images/8/8f/Anna_Boden.jpg/revision/latest?cb=20190305123354", "Anna Boden" },
                    { 2, "Judd Apatow is an American director, producer and screenwriter, best known for his work in comedy films. He is the founder of Apatow Productions. Throughout his career, Apatow has received nominations for 11 Primetime Emmy Awards, five Writers Guild of America Awards, two Producers Guild of America Awards, one Golden Globe Award and one Grammy Award.", new DateTime(1967, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/3/3b/2024-03-08_SXSW-2024_comedy-directors_3.jpg", "Judd Apatow" },
                    { 3, "After graduating from college, Garelick began his career working as an assistant in Creative Artists Agency's Motion Picture Literary department. He served as the assistant to director Joel Schumacher on Tigerland, Bad Company, and Phone Booth. He was the second unit director on Schumacher’s 2003 movie Veronica Guerin.", new DateTime(1975, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/c/c4/Jeremy_Garelick.png", "Jeremy Garelick" },
                    { 4, "Martin Scorsese is an American filmmaker. he emerged as one of the major figures of the New Hollywood era. Scorsese has received many accolades, including an Academy Award, four BAFTA Awards, three Emmy Awards, a Grammy Award, three Golden Globe Awards, and two Directors Guild of America Awards. He has been honored with the AFI Life Achievement Award in 1997.", new DateTime(1942, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/thumb/5/57/Martin_Scorsese-68754.jpg/800px-Martin_Scorsese-68754.jpg", "Martin Scorsese" },
                    { 5, "Christopher Nolan is a British and American filmmaker. Known for his Hollywood blockbusters with complex storytelling, he is considered a leading filmmaker of the 21st century.  His accolades include two Academy Awards and two British Academy Film Awards. Nolan was appointed as a Commander of the Order of the British Empire in 2019, and received a knighthood in 2024 for his contributions to film.", new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/commons/9/95/Christopher_Nolan_Cannes_2018.jpg", "Christopher Nolan" },
                    { 6, "Anthony Russo and Joseph Russo collectively known as the Russo brothers, are American directors, producers, and screenwriters. They direct most of their work together. They are best known for directing four films in the Marvel Cinematic Universe: Captain America: The Winter Soldier, Captain America: Civil War, Avengers: Infinity War, and Avengers: Endgame.", new DateTime(1970, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://imageio.forbes.com/specials-images/imageserve/62ca4312f62dcb9b9e34a6e9/Russo-Brothers---Exterior-horizontal/960x0.jpg?format=jpg&width=1440", "Anthony Russo" },
                    { 7, "Dennis Dugan is an American film director, actor, and comedian. He is known for directing the films Problem Child, Brain Donors, Beverly Hills Ninja and National Security, and his partnership with comedic actor Adam Sandler, for whom he directed the films Happy Gilmore, Big Daddy, The Benchwarmers, I Now Pronounce You Chuck & Larry etc.", new DateTime(1943, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://images.hobbydb.com/processed_uploads/subject_photo/subject_photo/image/49245/1553650458-4334-5610/Dennis_20Dugan_large.jpg", "Dennis Dugan" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Comedy" },
                    { 4, "Drama" },
                    { 5, "Crime" },
                    { 6, "Biography" },
                    { 7, "History" },
                    { 8, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "DirectorId", "GenreId", "ImageURL", "Price", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, "On a weekend trip to Hawaii, a plastic surgeon convinces his loyal assistant to pose as his soon-to-be-divorced wife in order to cover up a careless lie he told to his much-younger girlfriend.", 7, 3, "https://upload.wikimedia.org/wikipedia/en/b/b8/Just_Go_with_It_Poster.jpg", 29.99m, 6.4000000000000004, 2011, "Just Go with It" },
                    { 2, "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.", 4, 6, "https://moviesfilmsandflix.files.wordpress.com/2013/12/wolf-of-wall-street.jpg", 35.99m, 8.1999999999999993, 2013, "The Wolf of Wall Street" },
                    { 3, "Full-time detectives Nick and Audrey are struggling to get their private eye agency off the ground. They find themselves at the center of international abduction when their friend Maharaja is kidnapped at his own lavish wedding.", 3, 3, "https://upload.wikimedia.org/wikipedia/en/7/71/Murder_Mystery_2_poster.png", 59.99m, 5.7000000000000002, 2023, "Murder Mystery 2" },
                    { 4, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O., but his tragic past may doom the project and his team to disaster.", 5, 1, "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg", 25.99m, 8.8000000000000007, 2010, "Inception" },
                    { 5, "When seasoned comedian George Simmons learns of his terminal, inoperable health condition, his desire to form a genuine friendship causes him to take a relatively green performer under his wing as his opening act.", 2, 3, "https://upload.wikimedia.org/wikipedia/en/2/26/PosterFunnyPeople.jpg", 19.99m, 6.2999999999999998, 2009, "Funny People" },
                    { 6, "Carol Danvers becomes one of the universe's most powerful heroes when Earth is caught in the middle of a galactic war between two alien races.", 1, 2, "https://upload.wikimedia.org/wikipedia/en/4/4e/Captain_Marvel_%28film%29_poster.jpg", 49.99m, 6.7999999999999998, 2019, "Captain Marvel" },
                    { 7, "The story of American scientist J. Robert Oppenheimer and his role in the development of the atomic bomb.", 5, 4, "https://upload.wikimedia.org/wikipedia/en/4/4a/Oppenheimer_%28film%29.jpg", 69.99m, 8.3000000000000007, 2023, "Oppenheimer" },
                    { 8, "After the devastating events of Avengers: Infinity War, the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.", 6, 1, "https://upload.wikimedia.org/wikipedia/en/0/0d/Avengers_Endgame_poster.jpg", 65.99m, 8.4000000000000004, 2019, "Avengers: Endgame" }
                });

            migrationBuilder.InsertData(
                table: "MoviesActors",
                columns: new[] { "ActorId", "MovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 4, 4 },
                    { 5, 4 },
                    { 2, 5 },
                    { 3, 5 },
                    { 7, 6 },
                    { 8, 6 },
                    { 5, 7 },
                    { 6, 7 },
                    { 6, 8 },
                    { 7, 8 },
                    { 8, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "MoviesActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Movie's description",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldComment: "Movie's description");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Director",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "Director's bio",
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldComment: "Director's bio");

            migrationBuilder.AlterColumn<string>(
                name: "Bio",
                table: "Actors",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                comment: "Actor's bio",
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldComment: "Actor's bio");
        }
    }
}
