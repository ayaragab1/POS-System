using Microsoft.EntityFrameworkCore.Migrations;

namespace POS__System.Migrations
{
    public partial class newone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Type_ID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Type_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Type_ID",
                table: "Products",
                column: "Type_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Details_Products_Product_ID",
                table: "Invoice_Details",
                column: "Product_ID",
                principalTable: "Products",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Types_Type_ID",
                table: "Products",
                column: "Type_ID",
                principalTable: "Types",
                principalColumn: "Type_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Details_Products_Product_ID",
                table: "Invoice_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Types_Type_ID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Products_Type_ID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type_ID",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
