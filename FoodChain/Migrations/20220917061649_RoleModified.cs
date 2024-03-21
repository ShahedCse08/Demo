using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class RoleModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e6eaae6-328b-42c4-a627-79212b0e69c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8e226f2-e9a0-4c1c-80d4-747118362ce8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1ec6c3f-05cc-4b83-bd83-05a9712a6a6d", "a37e4ac2-b68e-4a17-9ae7-60a4e71b9111", "Consumer", "CONSUMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37f78396-c6bd-4987-b788-2c1c3949073d", "39e30ec6-0464-444d-b6f9-c8b74ebead95", "Vendor", "VENDOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37f78396-c6bd-4987-b788-2c1c3949073d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1ec6c3f-05cc-4b83-bd83-05a9712a6a6d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e6eaae6-328b-42c4-a627-79212b0e69c4", "c7bd8074-f8c0-4d59-9528-7f6037d035eb", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8e226f2-e9a0-4c1c-80d4-747118362ce8", "09bdd619-2ab2-40e8-b69b-5ad41df46c04", "Administrator", "ADMINISTRATOR" });
        }
    }
}
