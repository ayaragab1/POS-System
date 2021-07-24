using Microsoft.EntityFrameworkCore.Migrations;

namespace POS__System.Migrations
{
    public partial class UndoChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TQuantity_PerItem",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "TotalPaymant",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "TQuantity_PerItem",
                table: "Invoice_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Total_Payment",
                table: "Invoice_Details",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "Invoice_Details",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TQuantity_PerItem",
                table: "Invoice_Details");

            migrationBuilder.DropColumn(
                name: "Total_Payment",
                table: "Invoice_Details");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Invoice_Details");

            migrationBuilder.AddColumn<int>(
                name: "TQuantity_PerItem",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPaymant",
                table: "Invoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "UnitPrice",
                table: "Invoices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
