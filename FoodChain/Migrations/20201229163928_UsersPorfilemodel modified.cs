using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class UsersPorfilemodelmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilePicture_AspNetUsers_UserId",
                table: "UserProfilePicture");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6492dbd-00c9-4996-a135-eb97b29425f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9d19e5e-6989-4996-8f71-18a7a4270f0f");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserProfilePicture",
                newName: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfilePicture_AspNetUsers_Id",
                table: "UserProfilePicture");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "424c8540-390a-4142-abd9-7e13700e3050");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6b50115-a0a0-4903-ac9c-47304dfb7059");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserProfilePicture",
                newName: "UserId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6492dbd-00c9-4996-a135-eb97b29425f2", "3f16dac6-c9a0-4586-8fe0-58b33a25c667", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9d19e5e-6989-4996-8f71-18a7a4270f0f", "56027a87-abfc-4847-b328-0765efe5407a", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfilePicture_AspNetUsers_UserId",
                table: "UserProfilePicture",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
