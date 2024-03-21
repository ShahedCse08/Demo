using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class DistributorIdAddedToOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fecc052-4cbe-4f90-ad81-3dc49c02333a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff6663f4-64c5-4ca6-acb3-4a74904ca170");

            migrationBuilder.AddColumn<Guid>(
                name: "DistributorId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackageName",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e8a83c65-3b29-44d5-a14f-cd54252ea8c8", "0c1c8395-1a59-4953-a144-3f1d4094f44c", "Consumer", "CONSUMER" },
                    { "5fc91fd8-9bf1-4428-bf07-925101af2fe9", "6fed204f-448c-4819-b333-0c43b05edeef", "Vendor", "VENDOR" },
                    { "d3bc9a66-6820-4d1c-b5b9-83689acc13d1", "86544ab6-bfed-4a88-ac4d-1ef2ce4cdc60", "Distributor", "DISTRIBUTOR" }
                });

            migrationBuilder.InsertData(
                table: "OrderStates",
                columns: new[] { "StateId", "StateName" },
                values: new object[] { new Guid("96b4b93e-144d-415c-9f24-08fce568a4ae"), "Add to cart" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "OrderStates",
                keyColumn: "StateId",
                keyValue: new Guid("96b4b93e-144d-415c-9f24-08fce568a4ae"));

            migrationBuilder.DropColumn(
                name: "DistributorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "PackageName",
                table: "OrderDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5fecc052-4cbe-4f90-ad81-3dc49c02333a", "f137cab1-dc51-415c-af45-c0e53e128ba3", "Consumer", "CONSUMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ff6663f4-64c5-4ca6-acb3-4a74904ca170", "755e7813-af53-4e11-8ce6-e72feda0ed0b", "Vendor", "VENDOR" });
        }
    }
}
