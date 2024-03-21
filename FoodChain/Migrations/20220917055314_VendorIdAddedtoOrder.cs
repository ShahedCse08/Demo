using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class VendorIdAddedtoOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "698fd2ed-2516-4211-b7f4-ceb38e7800e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db4f3012-c06d-4a07-9d9f-bd14778c6ffc");

            migrationBuilder.AddColumn<Guid>(
                name: "VendorId",
                table: "Orders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2e6eaae6-328b-42c4-a627-79212b0e69c4", "c7bd8074-f8c0-4d59-9528-7f6037d035eb", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d8e226f2-e9a0-4c1c-80d4-747118362ce8", "09bdd619-2ab2-40e8-b69b-5ad41df46c04", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e6eaae6-328b-42c4-a627-79212b0e69c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d8e226f2-e9a0-4c1c-80d4-747118362ce8");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "698fd2ed-2516-4211-b7f4-ceb38e7800e4", "66df3995-5d09-4be8-8e90-d4b4765ef571", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db4f3012-c06d-4a07-9d9f-bd14778c6ffc", "a368ddf6-d97a-4bb3-8f5b-12196c28eb70", "Administrator", "ADMINISTRATOR" });
        }
    }
}
