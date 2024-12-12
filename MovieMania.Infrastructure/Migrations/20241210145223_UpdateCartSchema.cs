using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    public partial class UpdateCartSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "307551c5-be6a-48f6-9fce-22d1046700fe", "AQAAAAEAACcQAAAAEAHe6Bc09LYBL+MSBdIcVwuMMgMyX24hTBtFaV4u+4f0sucuVY+IV9IP9flvmmq82w==", "3a9cb536-1ce4-4a3f-8738-9df9347b0a2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f926a30-8ef9-42e2-8e02-5723c98c8e26", "AQAAAAEAACcQAAAAEElJ95Ujks5U9lmJHp88qr3i+rPDz+CDNK8lJi+k6gEfrspG5lD++ENZjWKTm2NDLg==", "9adf27ca-75de-41e4-9efe-94dc9dfdc79b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf1c3034-b0f3-4b61-9f4a-55bf07b4e5c7", "AQAAAAEAACcQAAAAEE2HMeyrmtDsslMownqmVuWYGv4vD4EoFjvjkVxOlc+8Ka6vkVJwGvYIMEWyZuyvsw==", "2ce37c20-7c7b-4d6b-85df-453f4c5bc2df" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ad30732-d6fd-4c09-83aa-365a88844c58", "AQAAAAEAACcQAAAAEENX4s+XJgV5/GRYqteaTyBS6TFMdaKOl6fp+JwDg0MSiF0SSQT2nwitfdlWkfIjcQ==", "f05b9b8e-b7ec-4115-aa07-da17a23df9d4" });
        }
    }
}
