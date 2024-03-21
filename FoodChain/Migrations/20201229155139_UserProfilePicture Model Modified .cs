using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class UserProfilePictureModelModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0347e839-943c-43a6-9ad8-191c468afa6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "191474ae-3bb4-4576-88de-cf9ea34af0c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fe5f6c80-d9b9-4ddd-850d-a492d390a20a", "ad448d72-3104-4d10-ad17-b77578863d7d", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b0ba75c4-0f79-4dca-8aa1-0590051ab86c", "5590b941-741d-4eac-adf8-76175ca6ac24", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "0347e839-943c-43a6-9ad8-191c468afa6b", "f77df764-c165-460d-8acf-be6cbf36fc54", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "191474ae-3bb4-4576-88de-cf9ea34af0c0", "b207232c-6642-44e9-848a-1daab2246633", "Administrator", "ADMINISTRATOR" });
        }
    }
}
