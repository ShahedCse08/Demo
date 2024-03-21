using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class PaymentModelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(nullable: false),
                    PaymentBy = table.Column<string>(nullable: true),
                    PaymentTo = table.Column<string>(nullable: true),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    TransactionId = table.Column<string>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f56f0db-01fa-48db-9ae3-b1ca48baabf6", "71f4ae10-f84e-49f3-9e6f-47eb6f7333d4", "Consumer", "CONSUMER" },
                    { "7c8a1493-bb90-4335-9c81-c3a02f78e34d", "590f2617-0eaf-4c0a-8ebc-334a65850596", "Vendor", "VENDOR" },
                    { "22c17d38-bcfc-41d9-8d34-c3a951d3a265", "61fbd5b2-bca4-4556-b6a7-7f419e9e3a11", "Distributor", "DISTRIBUTOR" }
                });

            migrationBuilder.InsertData(
                table: "OrderStates",
                columns: new[] { "StateId", "StateName" },
                values: new object[] { new Guid("ba4b22aa-953c-41d7-9989-5c32ee97fe6b"), "Paid" });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_OrderId",
                table: "Payment",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "22c17d38-bcfc-41d9-8d34-c3a951d3a265");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f56f0db-01fa-48db-9ae3-b1ca48baabf6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c8a1493-bb90-4335-9c81-c3a02f78e34d");

            migrationBuilder.DeleteData(
                table: "OrderStates",
                keyColumn: "StateId",
                keyValue: new Guid("ba4b22aa-953c-41d7-9989-5c32ee97fe6b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae5aa74a-0c1c-4e8a-a9e4-13af1c82b8f9", "1b73dbd1-6d47-4795-9a6e-987754079ed0", "Consumer", "CONSUMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4be79a5d-525b-484c-b543-37c5ef879c15", "532a79e1-1c8e-4c11-ad23-523b6cdb61de", "Vendor", "VENDOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f202fce2-dfd4-4811-87d0-29f8c2253f86", "14e63d25-a67f-445c-8b86-73410e39671d", "Distributor", "DISTRIBUTOR" });
        }
    }
}
