using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMania.Infrastructure.Migrations
{
    public partial class AddedCartItemMoviesReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "User's state",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User's state");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                comment: "User's postal code",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User's postal code");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                comment: "User's city",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "User's city");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(95)",
                maxLength: 95,
                nullable: false,
                comment: "User's address",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "User's address");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                comment: "User's state",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "User's state");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                comment: "User's postal code",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldComment: "User's postal code");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "User's city",
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35,
                oldComment: "User's city");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "User's address",
                oldClrType: typeof(string),
                oldType: "nvarchar(95)",
                oldMaxLength: 95,
                oldComment: "User's address");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b3b204b-4331-4b1a-bba3-4f5f26971ab5", "AQAAAAEAACcQAAAAEEyOmxLsgVsdrMsGyCtOeuS+jXem4zHbHGQpQD8ig1qZLUCHMOR/zXyjrUCnrcwUzg==", "9273df2e-c501-4c03-93cc-edc055f82df7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6d9d2ee-3ae2-48e9-a2b5-13ec02f1c38b", "AQAAAAEAACcQAAAAEDmVg4qW85hdHIPL9glHMkdSfbyZQej/twxrxSVPdanZlt5GH5F74Yzlu0LdqC45ow==", "1075132f-4f66-4014-a30d-8a736814ea41" });
        }
    }
}
