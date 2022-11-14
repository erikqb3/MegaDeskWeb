using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDeskWeb.Migrations
{
    public partial class alterDeskQuoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RushOptionId",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "depth",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "drawerCount",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "width",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "RushOptionId",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "depth",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "drawerCount",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "width",
                table: "DeskQuote");
        }
    }
}
