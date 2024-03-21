using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class VendorNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fc91fd8-9bf1-4428-bf07-925101af2fe9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3bc9a66-6820-4d1c-b5b9-83689acc13d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8a83c65-3b29-44d5-a14f-cd54252ea8c8");

            migrationBuilder.AddColumn<string>(
                name: "VendorName",
                table: "FoodMenus",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0b3f6b9-1297-46df-be13-1851dbba2753", "cc955bdc-5ee4-414a-b4a3-26477af3951d", "Consumer", "CONSUMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5dd5493f-45d6-4879-af6e-ddce5c903145", "70f1bd58-1259-4891-a800-dd35cecbab32", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d019cb10-2458-4951-8159-911f7a113f02", "ea78d6fd-eb85-4cd2-813a-1fdc0f50a4e7", "Distributor", "DISTRIBUTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dd5493f-45d6-4879-af6e-ddce5c903145");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d019cb10-2458-4951-8159-911f7a113f02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0b3f6b9-1297-46df-be13-1851dbba2753");

            migrationBuilder.DropColumn(
                name: "VendorName",
                table: "FoodMenus");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e8a83c65-3b29-44d5-a14f-cd54252ea8c8", "0c1c8395-1a59-4953-a144-3f1d4094f44c", "Consumer", "CONSUMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fc91fd8-9bf1-4428-bf07-925101af2fe9", "6fed204f-448c-4819-b333-0c43b05edeef", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d3bc9a66-6820-4d1c-b5b9-83689acc13d1", "86544ab6-bfed-4a88-ac4d-1ef2ce4cdc60", "Distributor", "DISTRIBUTOR" });
        }
    }
}
