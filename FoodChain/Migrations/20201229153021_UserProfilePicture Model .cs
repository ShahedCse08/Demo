using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class UserProfilePictureModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02746524-4e1a-48b2-a053-598b22b9a610");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8db5d78f-9961-4f6b-b62b-6df6b414930d");

            migrationBuilder.CreateTable(
                name: "UserProfilePicture",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    UserProfilePictureId = table.Column<Guid>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfilePicture", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserProfilePicture_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0347e839-943c-43a6-9ad8-191c468afa6b", "f77df764-c165-460d-8acf-be6cbf36fc54", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "191474ae-3bb4-4576-88de-cf9ea34af0c0", "b207232c-6642-44e9-848a-1daab2246633", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfilePicture");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0347e839-943c-43a6-9ad8-191c468afa6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "191474ae-3bb4-4576-88de-cf9ea34af0c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8db5d78f-9961-4f6b-b62b-6df6b414930d", "fbde0d31-dc77-4385-8b89-2a2ae6f94e30", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "02746524-4e1a-48b2-a053-598b22b9a610", "92d6a7eb-48a7-4834-b802-d8fab7948c70", "Administrator", "ADMINISTRATOR" });
        }
    }
}
