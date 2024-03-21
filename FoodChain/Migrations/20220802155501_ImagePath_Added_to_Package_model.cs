using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class ImagePath_Added_to_Package_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b2e9854-824a-478e-a241-74485fb45acd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8968235a-0bcf-4654-aae8-6cc6c1de5c1a");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Packages",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "873da833-fd73-4f35-aa7c-87bab4616035", "5c469f04-9765-4131-bca8-fbe44a2a893c", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5f64296b-8a72-49d5-823f-f5866b7cf000", "5146930e-07e7-4996-86ff-d91558b5dd9d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "PackageId", "ImagePath", "PackageName" },
                values: new object[] { new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9"), null, "Rice+Mutton Curry+Red Lentil" });

            migrationBuilder.InsertData(
                table: "PackageDetails",
                columns: new[] { "PackageDetailId", "ItemId", "PackageId" },
                values: new object[] { new Guid("a90130af-4fc7-4008-b8b0-936d73101318"), new Guid("6b9da871-8a3d-481f-b1b3-805440d55001"), new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9") });

            migrationBuilder.InsertData(
                table: "PackageDetails",
                columns: new[] { "PackageDetailId", "ItemId", "PackageId" },
                values: new object[] { new Guid("7c9d92ff-f251-47f2-9b89-d77897c62903"), new Guid("5e0911b0-2cad-4c63-9373-5b308fbda727"), new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9") });

            migrationBuilder.InsertData(
                table: "PackageDetails",
                columns: new[] { "PackageDetailId", "ItemId", "PackageId" },
                values: new object[] { new Guid("83934c9c-aedf-4c8c-aefc-83c4eac19f5d"), new Guid("649108f3-0fa3-4fe4-b9bd-cf47a6ce5925"), new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f64296b-8a72-49d5-823f-f5866b7cf000");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "873da833-fd73-4f35-aa7c-87bab4616035");

            migrationBuilder.DeleteData(
                table: "PackageDetails",
                keyColumn: "PackageDetailId",
                keyValue: new Guid("7c9d92ff-f251-47f2-9b89-d77897c62903"));

            migrationBuilder.DeleteData(
                table: "PackageDetails",
                keyColumn: "PackageDetailId",
                keyValue: new Guid("83934c9c-aedf-4c8c-aefc-83c4eac19f5d"));

            migrationBuilder.DeleteData(
                table: "PackageDetails",
                keyColumn: "PackageDetailId",
                keyValue: new Guid("a90130af-4fc7-4008-b8b0-936d73101318"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "PackageId",
                keyValue: new Guid("655e4451-9b59-4ef5-9d87-42d70ef13ac9"));

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Packages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6b2e9854-824a-478e-a241-74485fb45acd", "60c5e791-f27e-4949-83c5-286def1af508", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8968235a-0bcf-4654-aae8-6cc6c1de5c1a", "2dbbeed7-3b60-4e5a-8a0c-fca7d68c6cb6", "Administrator", "ADMINISTRATOR" });
        }
    }
}
