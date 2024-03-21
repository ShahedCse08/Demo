using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class W : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad753cc3-ffad-472a-86de-c61a4ad5ff91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1c001a1-93e3-48f8-9ac2-ae5cd9c5d207");

            migrationBuilder.AddColumn<string>(
                name: "To",
                table: "EmailContent",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "698fd2ed-2516-4211-b7f4-ceb38e7800e4", "66df3995-5d09-4be8-8e90-d4b4765ef571", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "db4f3012-c06d-4a07-9d9f-bd14778c6ffc", "a368ddf6-d97a-4bb3-8f5b-12196c28eb70", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "698fd2ed-2516-4211-b7f4-ceb38e7800e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db4f3012-c06d-4a07-9d9f-bd14778c6ffc");

            migrationBuilder.DropColumn(
                name: "To",
                table: "EmailContent");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1c001a1-93e3-48f8-9ac2-ae5cd9c5d207", "11da5372-c1bb-40ec-8b77-eb5895c25be4", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad753cc3-ffad-472a-86de-c61a4ad5ff91", "8e42809c-717a-456f-8bcb-872257131673", "Administrator", "ADMINISTRATOR" });
        }
    }
}
