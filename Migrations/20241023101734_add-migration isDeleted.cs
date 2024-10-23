using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_Managment_System.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationisDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "products");
        }
    }
}
