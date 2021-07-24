using Microsoft.EntityFrameworkCore.Migrations;

namespace POS__System.Migrations
{
    public partial class FMG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Invoice_ID = table.Column<int>(type: "int", nullable: false),
                    Total_Price = table.Column<double>(type: "float", nullable: false),
                    Total_Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Invoice_ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Product_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit_Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoice_Details",
                columns: table => new
                {
                    Product_ID = table.Column<int>(type: "int", nullable: false),
                    Invoice_ID = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TPrice_PerTotalItems = table.Column<double>(type: "float", nullable: false),
                    TQuantity_PerItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice_Details", x => new { x.Product_ID, x.Invoice_ID });
                    table.ForeignKey(
                        name: "FK_Invoice_Details_Invoices_Invoice_ID",
                        column: x => x.Invoice_ID,
                        principalTable: "Invoices",
                        principalColumn: "Invoice_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_Details_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "Product_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Details_Invoice_ID",
                table: "Invoice_Details",
                column: "Invoice_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice_Details");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
