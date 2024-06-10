using Microsoft.EntityFrameworkCore.Migrations;

namespace Demo.Migrations
{
    public partial class Property_Renamed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "PurchaseOrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseOrderId",
                table: "PurchaseOrderDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseOrderId",
                table: "PurchaseOrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "PurchaseOrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderDetails_PurchaseOrders_PurchaseOrderId",
                table: "PurchaseOrderDetails",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
