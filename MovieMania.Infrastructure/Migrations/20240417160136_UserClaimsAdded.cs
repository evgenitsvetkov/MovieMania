using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    public partial class UserClaimsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Evgeni Tsvetkov", "dea12856-c198-4129-b3f3-b893d8395082" },
                    { 2, "user:fullname", "Guest Guestt", "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e" }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de399190-56c7-4a45-b546-5321ec2a6279", "AQAAAAEAACcQAAAAEJXGxDflkiPsWBhtFI7SiUv1e/sX0FSD5hPRoAbFlREfBbskQRyGK/r10iwIOLdEXw==", "03744c2f-c824-4954-a853-7393bbc06aa2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3d77602-4a4d-4cff-9202-5508d3782881", "AQAAAAEAACcQAAAAEG+N8kdmZKgLXw0RXvo/trvW6nvsntgmCc7snHfa+m1JDgZ6JHWDkP8HH61n36g+TQ==", "5281894a-0e7e-41fb-9e79-430cb05ed351" });
        }
    }
}
