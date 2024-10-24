using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class last2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_Customerid",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "orders",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "orderDate",
                table: "orders",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "Customerid",
                table: "orders",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "orders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_Customerid",
                table: "orders",
                newName: "IX_orders_CustomerId");

            migrationBuilder.RenameColumn(
                name: "tax",
                table: "orderDetails",
                newName: "Tax");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "orderDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "orderDetails",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "orderDetails",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "orderDetails",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "finalPrice",
                table: "orderDetails",
                newName: "FinalPrice");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "orderDetails",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "orderDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updatedAt",
                table: "customers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "paymentStatus",
                table: "customers",
                newName: "PaymentStatus");

            migrationBuilder.RenameColumn(
                name: "orderStatus",
                table: "customers",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "deliveryDate",
                table: "customers",
                newName: "DeliveryDate");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "customers",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "contactInfo",
                table: "customers",
                newName: "ContactInfo");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "customers",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "customers",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "orderDetails",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "customers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_OrderId",
                table: "orderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderDetails_ProductId",
                table: "orderDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_orders_OrderId",
                table: "orderDetails",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderDetails_products_ProductId",
                table: "orderDetails",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_orders_OrderId",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orderDetails_products_ProductId",
                table: "orderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_OrderId",
                table: "orderDetails");

            migrationBuilder.DropIndex(
                name: "IX_orderDetails_ProductId",
                table: "orderDetails");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "orders",
                newName: "totalAmount");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "orders",
                newName: "orderDate");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "orders",
                newName: "Customerid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orders",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                newName: "IX_orders_Customerid");

            migrationBuilder.RenameColumn(
                name: "Tax",
                table: "orderDetails",
                newName: "tax");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "orderDetails",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "orderDetails",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "orderDetails",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "orderDetails",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "FinalPrice",
                table: "orderDetails",
                newName: "finalPrice");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "orderDetails",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orderDetails",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "customers",
                newName: "updatedAt");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "customers",
                newName: "paymentStatus");

            migrationBuilder.RenameColumn(
                name: "OrderStatus",
                table: "customers",
                newName: "orderStatus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "customers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "DeliveryDate",
                table: "customers",
                newName: "deliveryDate");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "customers",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "ContactInfo",
                table: "customers",
                newName: "contactInfo");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "customers",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "customers",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "Customerid",
                table: "orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "orderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_Customerid",
                table: "orders",
                column: "Customerid",
                principalTable: "customers",
                principalColumn: "id");
        }
    }
}
