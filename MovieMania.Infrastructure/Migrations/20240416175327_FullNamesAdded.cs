using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    public partial class FullNamesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de399190-56c7-4a45-b546-5321ec2a6279", "Guest", "Guestt", "AQAAAAEAACcQAAAAEJXGxDflkiPsWBhtFI7SiUv1e/sX0FSD5hPRoAbFlREfBbskQRyGK/r10iwIOLdEXw==", "03744c2f-c824-4954-a853-7393bbc06aa2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3d77602-4a4d-4cff-9202-5508d3782881", "Evgeni", "Tsvetkov", "AQAAAAEAACcQAAAAEG+N8kdmZKgLXw0RXvo/trvW6nvsntgmCc7snHfa+m1JDgZ6JHWDkP8HH61n36g+TQ==", "5281894a-0e7e-41fb-9e79-430cb05ed351" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e068c16-b480-409a-8023-67f1801b4e69", "", "", "AQAAAAEAACcQAAAAEDvLatvY4Vs5d1HscyYAhGzOAg23qM3bKcp9TeHGlgb3sK+3zErQviLwZJJVrcUfKw==", "43302bb8-bd9f-4016-8c72-6377189b9461" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ad2e125-33e4-4e1e-80df-db4c57e89b25", "", "", "AQAAAAEAACcQAAAAEF1WVFpRcw1Uo+49mkX28YREyhTUIaWmZ6whnVQYkwPHZMwo2FAChF7PC3M37AZFUw==", "5a197b68-513e-45f8-b089-9629f5f9fde9" });
        }
    }
}
