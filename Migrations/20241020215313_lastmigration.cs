using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class lastmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_productId",
                table: "orderDetails",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_products_productId",
                table: "orderDetails",
                column: "productId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_products_productId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_productId",
                table: "orderDetails");
        }
    }
}
