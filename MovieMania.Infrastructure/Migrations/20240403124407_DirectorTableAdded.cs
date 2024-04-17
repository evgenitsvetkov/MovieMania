using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    public partial class DirectorTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Producer_ProducerId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ProducerId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Director's identifier");

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Director's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Director's name"),
                    Bio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Director's bio"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Director's birthday"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Director's profile picture url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                },
                comment: "Movie's director");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Director_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Director",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Director_DirectorId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Movie's director");

            migrationBuilder.AddColumn<int>(
                name: "ProducerId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Producer's identifier");

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Producer's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bio = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "Producer's bio"),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Producer's birthday"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Producer's profile picture url"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Producer's name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.Id);
                },
                comment: "Movie's producer");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProducerId",
                table: "Movies",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Producer_ProducerId",
                table: "Movies",
                column: "ProducerId",
                principalTable: "Producer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
