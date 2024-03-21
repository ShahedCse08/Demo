using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class UsersProfilePictureModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0ba75c4-0f79-4dca-8aa1-0590051ab86c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe5f6c80-d9b9-4ddd-850d-a492d390a20a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6492dbd-00c9-4996-a135-eb97b29425f2", "3f16dac6-c9a0-4586-8fe0-58b33a25c667", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9d19e5e-6989-4996-8f71-18a7a4270f0f", "56027a87-abfc-4847-b328-0765efe5407a", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6492dbd-00c9-4996-a135-eb97b29425f2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9d19e5e-6989-4996-8f71-18a7a4270f0f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe5f6c80-d9b9-4ddd-850d-a492d390a20a", "ad448d72-3104-4d10-ad17-b77578863d7d", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0ba75c4-0f79-4dca-8aa1-0590051ab86c", "5590b941-741d-4eac-adf8-76175ca6ac24", "Administrator", "ADMINISTRATOR" });
        }
    }
}
