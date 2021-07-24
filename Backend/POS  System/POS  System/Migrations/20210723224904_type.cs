using Microsoft.EntityFrameworkCore.Migrations;

namespace POS__System.Migrations
{
    public partial class type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Details_Products_Product_ID",
                table: "Invoice_Details");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Product_Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Type_ID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Product_Types",
                columns: table => new
                {
                    Type_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Types", x => x.Type_ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Type_ID",
                table: "Products",
                column: "Type_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Product_Types_Type_ID",
                table: "Products",
                column: "Type_ID",
                principalTable: "Product_Types",
                principalColumn: "Type_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Product_Types_Type_ID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Product_Types");

            migrationBuilder.DropIndex(
                name: "IX_Products_Type_ID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Type_ID",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Product_Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Details_Products_Product_ID",
                table: "Invoice_Details",
                column: "Product_ID",
                principalTable: "Products",
                principalColumn: "Product_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
