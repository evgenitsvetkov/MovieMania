using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    public partial class ShoppingCartTablesTweaked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CartDetails");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderStatusId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Carts",
                newName: "RecordId");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                comment: "User's address");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "User's city");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "User's country");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "User's email");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "User's first name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "User's last name");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "User's phone");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "User's postal code");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "User's state");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Order's total price");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "User's username");

            migrationBuilder.AddColumn<string>(
                name: "CartId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Cart item's identifier");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Count of items");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Date of cart's creation");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Movie's identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1ef9be3-e020-4535-9bca-b42cc8a3026b", "AQAAAAEAACcQAAAAEG+rFoLhSGJT37rsSTj2+95Zb8OQ5MjUfyRWoUtoFC/cHSONaj+k8yB7y6Smkqv6oA==", "f12f8cdd-727a-4afa-97d6-c174354eddb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ab6c1b3-5762-4b7e-8092-f4660ccd8df8", "AQAAAAEAACcQAAAAEHHTZFJvV/fc8H0eCKHxFKq4MPNFGZJyd43KJagdujGHW0adhICFlNWWuHiOaQY93A==", "147a30a1-e9ed-4ec8-98c2-f1dd8b3e7660" });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_MovieId",
                table: "Carts",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Movies_MovieId",
                table: "Carts",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Movies_MovieId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_MovieId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Carts");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "Carts",
                newName: "Id");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Order status identifier");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "User's identifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "User's identifier");

            migrationBuilder.CreateTable(
                name: "CartDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Cart detail's identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false, comment: "Movie's identifier"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false, comment: "Shopping cart's identifier"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity of movies in the cart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDetails_Carts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetails_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Detail of user's shopping cart");

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order status identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Order status name"),
                    StatusId = table.Column<int>(type: "int", nullable: false, comment: "Status identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                },
                comment: "Status of user's order");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3562b055-1c82-409c-ba2a-5f5a03b446dd", "AQAAAAEAACcQAAAAELaA4KlI3wbNTynmXs2WMaxXWALgXjtZDfFSLdrYpu53ZiHElBawbNFkD83kd43VRA==", "fcc531ef-b3ef-4475-8549-21358b6896d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "560f33e0-5280-4c3b-9dd0-1fa1c2ab2ebd", "AQAAAAEAACcQAAAAEBTEabJGcn9QCRXZ4M6hAlvHwvh9EsZUJrTEjAQfB8lP5Y9ZaP5YNpzK/kiQfHJfTw==", "19f993d7-bbcb-4805-a7bd-3fc83a1db78e" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_MovieId",
                table: "CartDetails",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_ShoppingCartId",
                table: "CartDetails",
                column: "ShoppingCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
