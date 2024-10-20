using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_purchases_purchaseId",
                table: "PurchaseDetails");

            migrationBuilder.RenameColumn(
                name: "purchaseId",
                table: "PurchaseDetails",
                newName: "Purchaseid");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetails_purchaseId",
                table: "PurchaseDetails",
                newName: "IX_PurchaseDetails_Purchaseid");

            migrationBuilder.AlterColumn<int>(
                name: "Purchaseid",
                table: "PurchaseDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Customerid",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orders_Customerid",
                table: "orders",
                column: "Customerid");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_Customerid",
                table: "orders",
                column: "Customerid",
                principalTable: "customers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_purchases_Purchaseid",
                table: "PurchaseDetails",
                column: "Purchaseid",
                principalTable: "purchases",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_Customerid",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_purchases_Purchaseid",
                table: "PurchaseDetails");

            migrationBuilder.DropIndex(
                name: "IX_orders_Customerid",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Customerid",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "Purchaseid",
                table: "PurchaseDetails",
                newName: "purchaseId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseDetails_Purchaseid",
                table: "PurchaseDetails",
                newName: "IX_PurchaseDetails_purchaseId");

            migrationBuilder.AlterColumn<int>(
                name: "purchaseId",
                table: "PurchaseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_purchases_purchaseId",
                table: "PurchaseDetails",
                column: "purchaseId",
                principalTable: "purchases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
