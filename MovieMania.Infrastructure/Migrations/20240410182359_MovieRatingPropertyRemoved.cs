using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    public partial class MovieRatingPropertyRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Movies",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                comment: "Movie's rating");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "910df93c-401e-44fa-a7e5-ff39097f065a", "AQAAAAEAACcQAAAAEHcn4uPHLmVRSNich+Vkzo+vy+TC8ck0V3MK2E9X9hvWjsXW00CKnQx5xsGacw/hLQ==", "264be395-c655-4d88-b4d3-9eb61c807a81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "940fba24-8f41-4f38-9f0d-7666fd30cbde", "AQAAAAEAACcQAAAAELjoPaCNSZRc1ugaQ5ngLMS9W1VF139euvg5JlAzJ3sy6enf/459DTQgZzYhsi8g4A==", "c8067d0b-0301-4c00-90b8-f358db2633ed" });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1,
                column: "Rating",
                value: 6.4000000000000004);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2,
                column: "Rating",
                value: 8.1999999999999993);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3,
                column: "Rating",
                value: 5.7000000000000002);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4,
                column: "Rating",
                value: 8.8000000000000007);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5,
                column: "Rating",
                value: 6.2999999999999998);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "Rating",
                value: 6.7999999999999998);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "Rating",
                value: 8.3000000000000007);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "Rating",
                value: 8.4000000000000004);
        }
    }
}
