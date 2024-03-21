using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class EmailContentEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21f6bde5-a3bb-419c-acd0-f03eb4f51fd4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7629fe13-f19a-474b-a0cd-ff95a8fb2133");

            migrationBuilder.CreateTable(
                name: "EmailContent",
                columns: table => new
                {
                    EmailContentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Cc = table.Column<string>(nullable: true),
                    Bcc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailContent", x => x.EmailContentId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d1c001a1-93e3-48f8-9ac2-ae5cd9c5d207", "11da5372-c1bb-40ec-8b77-eb5895c25be4", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad753cc3-ffad-472a-86de-c61a4ad5ff91", "8e42809c-717a-456f-8bcb-872257131673", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailContent");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad753cc3-ffad-472a-86de-c61a4ad5ff91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1c001a1-93e3-48f8-9ac2-ae5cd9c5d207");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7629fe13-f19a-474b-a0cd-ff95a8fb2133", "5e064cf2-3e49-48e6-a051-08b77dbf0c95", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "21f6bde5-a3bb-419c-acd0-f03eb4f51fd4", "746c9c28-0814-4e9e-bc86-3efaf3fd53a0", "Administrator", "ADMINISTRATOR" });
        }
    }
}
