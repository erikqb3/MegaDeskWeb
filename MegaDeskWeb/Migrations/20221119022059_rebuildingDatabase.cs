using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDeskWeb.Migrations
{
    public partial class rebuildingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desk_RushOption_RushOptionId",
                table: "Desk");

            migrationBuilder.DropIndex(
                name: "IX_Desk_RushOptionId",
                table: "Desk");

            migrationBuilder.DropColumn(
                name: "RushOptionId",
                table: "Desk");

            migrationBuilder.AddColumn<int>(
                name: "DeskId",
                table: "RushOption",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RushDays",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RushOptionId",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RushOption_DeskId",
                table: "RushOption",
                column: "DeskId");

            migrationBuilder.CreateIndex(
                name: "IX_DeskQuote_RushOptionId",
                table: "DeskQuote",
                column: "RushOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_RushOption_RushOptionId",
                table: "DeskQuote",
                column: "RushOptionId",
                principalTable: "RushOption",
                principalColumn: "RushOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_RushOption_Desk_DeskId",
                table: "RushOption",
                column: "DeskId",
                principalTable: "Desk",
                principalColumn: "DeskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_RushOption_RushOptionId",
                table: "DeskQuote");

            migrationBuilder.DropForeignKey(
                name: "FK_RushOption_Desk_DeskId",
                table: "RushOption");

            migrationBuilder.DropIndex(
                name: "IX_RushOption_DeskId",
                table: "RushOption");

            migrationBuilder.DropIndex(
                name: "IX_DeskQuote_RushOptionId",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "DeskId",
                table: "RushOption");

            migrationBuilder.DropColumn(
                name: "RushDays",
                table: "DeskQuote");

            migrationBuilder.DropColumn(
                name: "RushOptionId",
                table: "DeskQuote");

            migrationBuilder.AddColumn<int>(
                name: "RushOptionId",
                table: "Desk",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Desk_RushOptionId",
                table: "Desk",
                column: "RushOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desk_RushOption_RushOptionId",
                table: "Desk",
                column: "RushOptionId",
                principalTable: "RushOption",
                principalColumn: "RushOptionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
