using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    public partial class DomainTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Actor's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Actor's name"),
                    Bio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Actor's bio"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Actor's birthdate"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Actor's profile picture url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                },
                comment: "Movie's actor");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Genre's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false, comment: "Genre's name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                },
                comment: "Movie's genre");

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Producer's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Producer's name"),
                    Bio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Producer's bio"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Producer's birthday"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Producer's profile picture url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                },
                comment: "Movie's producer");

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Movie's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Movie's title"),
                    GenreId = table.Column<int>(type: "int", nullable: false, comment: "Movie's genre identifier"),
                    ReleaseDate = table.Column<int>(type: "int", maxLength: 4, nullable: false, comment: "Movie's release date"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price for single movie"),
                    Director = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Movie's director"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Movie's description"),
                    Rating = table.Column<double>(type: "float", nullable: false, comment: "Movie's rating"),
                    ProducerId = table.Column<int>(type: "int", nullable: false, comment: "Producer's identifier"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Movie's image url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movies_Producer_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Movie to buy");

            migrationBuilder.CreateTable(
                name: "MoviesActors",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "Movie's identifier"),
                    ActorId = table.Column<int>(type: "int", nullable: false, comment: "Actor's identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesActors", x => new { x.MovieId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_MoviesActors_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviesActors_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProducerId",
                table: "Movies",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesActors_ActorId",
                table: "MoviesActors",
                column: "ActorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviesActors");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Producer");
        }
    }
}
