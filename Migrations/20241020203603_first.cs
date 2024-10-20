using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentCategory = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orderDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    finalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    stockQuantity = table.Column<int>(type: "int", nullable: false),
                    minimumStockLevel = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false),
                    brandId = table.Column<int>(type: "int", nullable: false),
                    supplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.id);
                    table.ForeignKey(
                        name: "FK_products_brands_brandId",
                        column: x => x.brandId,
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_categories_categoryId",
                        column: x => x.categoryId,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchases",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalCost = table.Column<double>(type: "float", nullable: false),
                    purchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    supplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchases", x => x.id);
                    table.ForeignKey(
                        name: "FK_purchases_suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    costPrice = table.Column<double>(type: "float", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    finalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    purchaseId = table.Column<int>(type: "int", nullable: false),
                    productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_products_productId",
                        column: x => x.productId,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetails_purchases_purchaseId",
                        column: x => x.purchaseId,
                        principalTable: "purchases",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_brandId",
                table: "products",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_products_categoryId",
                table: "products",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_products_supplierId",
                table: "products",
                column: "supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_productId",
                table: "PurchaseDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetails_purchaseId",
                table: "PurchaseDetails",
                column: "purchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_purchases_supplierId",
                table: "purchases",
                column: "supplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "orderDetails");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "PurchaseDetails");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "purchases");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
