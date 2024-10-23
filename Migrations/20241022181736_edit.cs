using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetails_purchases_Purchaseid",
                table: "PurchaseDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetails_Purchaseid",
                table: "PurchaseDetails");

            migrationBuilder.DropColumn(
                name: "Purchaseid",
                table: "PurchaseDetails");

            migrationBuilder.AddColumn<int>(
                name: "LastUserId",
                table: "brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "createdUserId",
                table: "brands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUserId",
                table: "brands");

            migrationBuilder.DropColumn(
                name: "createdUserId",
                table: "brands");

            migrationBuilder.AddColumn<int>(
                name: "Purchaseid",
                table: "PurchaseDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_Purchaseid",
                table: "PurchaseDetails",
                column: "Purchaseid");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetails_purchases_Purchaseid",
                table: "PurchaseDetails",
                column: "Purchaseid",
                principalTable: "purchases",
                principalColumn: "id");
        }
    }
}
