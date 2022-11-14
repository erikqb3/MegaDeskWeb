using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDeskWeb.Migrations
{
    public partial class AddRushOrderSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "calcPrice",
                table: "RushOption",
                newName: "modifier");

            migrationBuilder.AddColumn<int>(
                name: "basePrice",
                table: "RushOption",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "basePrice",
                table: "RushOption");

            migrationBuilder.RenameColumn(
                name: "modifier",
                table: "RushOption",
                newName: "calcPrice");
        }
    }
}
