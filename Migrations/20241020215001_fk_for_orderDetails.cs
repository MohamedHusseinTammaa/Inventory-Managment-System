using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class fk_for_orderDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_orderId",
                table: "orderDetails",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_orders_orderId",
                table: "orderDetails",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_orders_orderId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_orderId",
                table: "orderDetails");
        }
    }
}
