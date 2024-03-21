using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class UsersProfilePicurePrimarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilePicture_AspNetUsers_Id",
                table: "UserProfilePicture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfilePicture",
                table: "UserProfilePicture");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "424c8540-390a-4142-abd9-7e13700e3050");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b50115-a0a0-4903-ac9c-47304dfb7059");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserProfilePicture");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserProfilePicture",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfilePicture",
                table: "UserProfilePicture",
                column: "UserProfilePictureId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ea3337fb-ce60-45bf-a758-fd0025ea16e7", "060c4f19-4325-4c9b-b253-2e0b4870be2a", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "178f186f-5e81-49c5-a8ae-8fba7ad5b11f", "8af4f9c6-c454-4eb7-aaf2-de11df501518", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfilePicture",
                table: "UserProfilePicture");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "178f186f-5e81-49c5-a8ae-8fba7ad5b11f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea3337fb-ce60-45bf-a758-fd0025ea16e7");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserProfilePicture");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "UserProfilePicture",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfilePicture",
                table: "UserProfilePicture",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6b50115-a0a0-4903-ac9c-47304dfb7059", "a2f47ac5-ebf4-447a-8e5a-9208df27e2c0", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "424c8540-390a-4142-abd9-7e13700e3050", "8f4b2fa5-c2c7-4960-bf99-20e4e0b88a72", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilePicture_AspNetUsers_Id",
                table: "UserProfilePicture",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
