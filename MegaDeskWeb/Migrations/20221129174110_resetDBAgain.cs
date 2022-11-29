using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDeskWeb.Migrations
{
    public partial class resetDBAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "price",
                table: "Material",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "quoteTotalPrice",
                table: "DeskQuote",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "Material",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<float>(
                name: "quoteTotalPrice",
                table: "DeskQuote",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "decimal(18, 2)");
        }
    }
}
