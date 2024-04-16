using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    public partial class UserExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "268b1806-dde3-4f29-9a5c-95026ac399e7", "AQAAAAEAACcQAAAAEFatN+IFr+NiO9f5BPU0tsRnDUmUVcQZXkz/QGoYjUWnpO7hHs4z5Jb0YNXoPiC3uw==", "d8e87851-770a-4247-b4f4-97085e507031" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a220d71-12d5-470a-a114-7bd7b383c1b2", "AQAAAAEAACcQAAAAEDUHXHSu44CzbwHlbwwhQB4lhu1BSyIzR3WsODOkM9fJ53CsLlq7KAFgZoX7WkNCiw==", "974b068b-60a9-4eaf-9e29-e5b77a5e0065" });
        }
    }
}
