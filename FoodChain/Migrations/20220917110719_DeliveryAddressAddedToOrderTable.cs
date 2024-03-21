using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class DeliveryAddressAddedToOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37f78396-c6bd-4987-b788-2c1c3949073d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1ec6c3f-05cc-4b83-bd83-05a9712a6a6d");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "Orders",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fecc052-4cbe-4f90-ad81-3dc49c02333a", "f137cab1-dc51-415c-af45-c0e53e128ba3", "Consumer", "CONSUMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff6663f4-64c5-4ca6-acb3-4a74904ca170", "755e7813-af53-4e11-8ce6-e72feda0ed0b", "Vendor", "VENDOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fecc052-4cbe-4f90-ad81-3dc49c02333a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff6663f4-64c5-4ca6-acb3-4a74904ca170");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1ec6c3f-05cc-4b83-bd83-05a9712a6a6d", "a37e4ac2-b68e-4a17-9ae7-60a4e71b9111", "Consumer", "CONSUMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37f78396-c6bd-4987-b788-2c1c3949073d", "39e30ec6-0464-444d-b6f9-c8b74ebead95", "Vendor", "VENDOR" });
        }
    }
}
