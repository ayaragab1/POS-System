using Microsoft.EntityFrameworkCore.Migrations;

namespace POS__System.Migrations
{
    public partial class EditsOnColums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Details_Invoices_Invoice_ID",
                table: "Invoice_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice_Details",
                table: "Invoice_Details");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_Details_Invoice_ID",
                table: "Invoice_Details");

            migrationBuilder.DropColumn(
                name: "Invoice_ID",
                table: "Invoice_Details");

            migrationBuilder.DropColumn(
                name: "TPrice_PerTotalItems",
                table: "Invoice_Details");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Invoice_Details");

            migrationBuilder.RenameColumn(
                name: "Total_Quantity",
                table: "Invoices",
                newName: "TQuantity_PerItem");

            migrationBuilder.RenameColumn(
                name: "Invoice_ID",
                table: "Invoices",
                newName: "Invoice_Number");

            migrationBuilder.RenameColumn(
                name: "TQuantity_PerItem",
                table: "Invoice_Details",
                newName: "Invoice_Number");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice_Details",
                table: "Invoice_Details",
                columns: new[] { "Product_ID", "Invoice_Number" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Details_Invoice_Number",
                table: "Invoice_Details",
                column: "Invoice_Number");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Details_Invoices_Invoice_Number",
                table: "Invoice_Details",
                column: "Invoice_Number",
                principalTable: "Invoices",
                principalColumn: "Invoice_Number",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Details_Invoices_Invoice_Number",
                table: "Invoice_Details");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoice_Details",
                table: "Invoice_Details");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_Details_Invoice_Number",
                table: "Invoice_Details");

            migrationBuilder.DropColumn(
                name: "TotalPaymant",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "TQuantity_PerItem",
                table: "Invoices",
                newName: "Total_Quantity");

            migrationBuilder.RenameColumn(
                name: "Invoice_Number",
                table: "Invoices",
                newName: "Invoice_ID");

            migrationBuilder.RenameColumn(
                name: "Invoice_Number",
                table: "Invoice_Details",
                newName: "TQuantity_PerItem");

            migrationBuilder.AddColumn<int>(
                name: "Invoice_ID",
                table: "Invoice_Details",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TPrice_PerTotalItems",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoice_Details",
                table: "Invoice_Details",
                columns: new[] { "Product_ID", "Invoice_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Details_Invoice_ID",
                table: "Invoice_Details",
                column: "Invoice_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Details_Invoices_Invoice_ID",
                table: "Invoice_Details",
                column: "Invoice_ID",
                principalTable: "Invoices",
                principalColumn: "Invoice_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
