using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class PackageSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ae5aa74a-0c1c-4e8a-a9e4-13af1c82b8f9", "1b73dbd1-6d47-4795-9a6e-987754079ed0", "Consumer", "CONSUMER" },
                    { "4be79a5d-525b-484c-b543-37c5ef879c15", "532a79e1-1c8e-4c11-ad23-523b6cdb61de", "Vendor", "VENDOR" },
                    { "f202fce2-dfd4-4811-87d0-29f8c2253f86", "14e63d25-a67f-445c-8b86-73410e39671d", "Distributor", "DISTRIBUTOR" }
                });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9"),
                columns: new[] { "ImagePath", "PackageName" },
                values: new object[] { "assets/images/photo2.jpg", "Rice and fish platter" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b"),
                columns: new[] { "ImagePath", "PackageName" },
                values: new object[] { "assets/images/photo1.jpg", "Chicken Burger" });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageId", "ImagePath", "PackageName" },
                values: new object[,]
                {
                    { new Guid("75dbbfa3-1d70-444a-8b25-49b8ae0f2021"), "assets/images/photo3.jpg", "Chicken biriany" },
                    { new Guid("bc171ae5-74d1-4c61-a3ef-65a4d245d1a3"), "assets/images/photo4.jpg", "Vat and vorta" },
                    { new Guid("99990751-0ce7-4172-ad8f-baed9476a397"), "assets/images/photo5.jpg", "Beef khichuri" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4be79a5d-525b-484c-b543-37c5ef879c15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae5aa74a-0c1c-4e8a-a9e4-13af1c82b8f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f202fce2-dfd4-4811-87d0-29f8c2253f86");

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: new Guid("75dbbfa3-1d70-444a-8b25-49b8ae0f2021"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: new Guid("99990751-0ce7-4172-ad8f-baed9476a397"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: new Guid("bc171ae5-74d1-4c61-a3ef-65a4d245d1a3"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e0b3f6b9-1297-46df-be13-1851dbba2753", "cc955bdc-5ee4-414a-b4a3-26477af3951d", "Consumer", "CONSUMER" },
                    { "5dd5493f-45d6-4879-af6e-ddce5c903145", "70f1bd58-1259-4891-a800-dd35cecbab32", "Vendor", "VENDOR" },
                    { "d019cb10-2458-4951-8159-911f7a113f02", "ea78d6fd-eb85-4cd2-813a-1fdc0f50a4e7", "Distributor", "DISTRIBUTOR" }
                });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9"),
                columns: new[] { "ImagePath", "PackageName" },
                values: new object[] { null, "Rice+Mutton Curry+Red Lentil" });

            migrationBuilder.UpdateData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b"),
                columns: new[] { "ImagePath", "PackageName" },
                values: new object[] { null, "Rice+Hilsha fish curry+Mashed Potato+Red Lentil" });
        }
    }
}
