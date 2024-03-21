using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class PackageSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3dfe8737-de33-4441-b02a-72125dddadf0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee42d90f-5d56-4d24-a4e1-4c71bcb836da");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b2e9854-824a-478e-a241-74485fb45acd", "60c5e791-f27e-4949-83c5-286def1af508", "Manager", "MANAGER" },
                    { "8968235a-0bcf-4654-aae8-6cc6c1de5c1a", "2dbbeed7-3b60-4e5a-8a0c-fca7d68c6cb6", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemName" },
                values: new object[] { new Guid("5e0911b0-2cad-4c63-9373-5b308fbda727"), "Mutton Curry" });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageId", "PackageName" },
                values: new object[] { new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b"), "Rice+Hilsha fish curry+Mashed Potato+Red Lentil" });

            migrationBuilder.InsertData(
                table: "PackageDetails",
                columns: new[] { "PackageDetailId", "ItemId", "PackageId" },
                values: new object[,]
                {
                    { new Guid("7e87299b-2609-49e5-ba7e-5139a9a3995a"), new Guid("6b9da871-8a3d-481f-b1b3-805440d55001"), new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b") },
                    { new Guid("42083e40-eeed-431d-899c-dddb72a0d4ce"), new Guid("973ddbdb-a252-4fd1-9b30-0700fbd5d0c7"), new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b") },
                    { new Guid("488ec5d4-ce3e-43c7-968e-5ee60d956fce"), new Guid("3ea42539-e4a5-43df-9306-dc711a880c47"), new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b") },
                    { new Guid("f0ef12e1-a24b-4fbf-a29f-284ca2ecf721"), new Guid("649108f3-0fa3-4fe4-b9bd-cf47a6ce5925"), new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b2e9854-824a-478e-a241-74485fb45acd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8968235a-0bcf-4654-aae8-6cc6c1de5c1a");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("5e0911b0-2cad-4c63-9373-5b308fbda727"));

            migrationBuilder.DeleteData(
                table: "PackageDetails",
                keyColumn: "PackageDetailId",
                keyValue: new Guid("42083e40-eeed-431d-899c-dddb72a0d4ce"));

            migrationBuilder.DeleteData(
                table: "PackageDetails",
                keyColumn: "PackageDetailId",
                keyValue: new Guid("488ec5d4-ce3e-43c7-968e-5ee60d956fce"));

            migrationBuilder.DeleteData(
                table: "PackageDetails",
                keyColumn: "PackageDetailId",
                keyValue: new Guid("7e87299b-2609-49e5-ba7e-5139a9a3995a"));

            migrationBuilder.DeleteData(
                table: "PackageDetails",
                keyColumn: "PackageDetailId",
                keyValue: new Guid("f0ef12e1-a24b-4fbf-a29f-284ca2ecf721"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: new Guid("fb5356c5-d813-4f9c-ae07-a523d0532c5b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee42d90f-5d56-4d24-a4e1-4c71bcb836da", "ce2b1bf3-1043-49c3-9074-1a2e99df4f16", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3dfe8737-de33-4441-b02a-72125dddadf0", "a3f0bdb3-1e9a-4e6b-9a65-ca15da29acd9", "Administrator", "ADMINISTRATOR" });
        }
    }
}
