using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MegaDeskWeb.Migrations
{
    public partial class changingRushOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "DeskId",
                table: "RushOption");

            migrationBuilder.DropColumn(
                name: "RushDays",
                table: "DeskQuote");

            migrationBuilder.AlterColumn<int>(
                name: "RushOptionId",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeskQuote_RushOption_RushOptionId",
                table: "DeskQuote",
                column: "RushOptionId",
                principalTable: "RushOption",
                principalColumn: "RushOptionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeskQuote_RushOption_RushOptionId",
                table: "DeskQuote");

            migrationBuilder.AddColumn<int>(
                name: "DeskId",
                table: "RushOption",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RushOptionId",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "RushDays",
                table: "DeskQuote",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RushOption_DeskId",
                table: "RushOption",
                column: "DeskId");

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
    }
}
