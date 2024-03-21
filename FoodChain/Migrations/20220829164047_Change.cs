using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f64296b-8a72-49d5-823f-f5866b7cf000");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "873da833-fd73-4f35-aa7c-87bab4616035");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7629fe13-f19a-474b-a0cd-ff95a8fb2133", "5e064cf2-3e49-48e6-a051-08b77dbf0c95", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21f6bde5-a3bb-419c-acd0-f03eb4f51fd4", "746c9c28-0814-4e9e-bc86-3efaf3fd53a0", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21f6bde5-a3bb-419c-acd0-f03eb4f51fd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7629fe13-f19a-474b-a0cd-ff95a8fb2133");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "873da833-fd73-4f35-aa7c-87bab4616035", "5c469f04-9765-4131-bca8-fbe44a2a893c", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f64296b-8a72-49d5-823f-f5866b7cf000", "5146930e-07e7-4996-86ff-d91558b5dd9d", "Administrator", "ADMINISTRATOR" });
        }
    }
}
