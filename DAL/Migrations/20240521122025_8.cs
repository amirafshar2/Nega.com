using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolios_portfolioCateories_PortfolioCateoryid",
                table: "portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_portfolios_portfolios_Portfoliocategoryid",
                table: "portfolios");

            migrationBuilder.DropIndex(
                name: "IX_portfolios_Portfoliocategoryid",
                table: "portfolios");

            migrationBuilder.DropColumn(
                name: "Portfoliocategoryid",
                table: "portfolios");

            migrationBuilder.AlterColumn<int>(
                name: "PortfolioCateoryid",
                table: "portfolios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_portfolios_portfolioCateories_PortfolioCateoryid",
                table: "portfolios",
                column: "PortfolioCateoryid",
                principalTable: "portfolioCateories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolios_portfolioCateories_PortfolioCateoryid",
                table: "portfolios");

            migrationBuilder.AlterColumn<int>(
                name: "PortfolioCateoryid",
                table: "portfolios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Portfoliocategoryid",
                table: "portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_portfolios_Portfoliocategoryid",
                table: "portfolios",
                column: "Portfoliocategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_portfolios_portfolioCateories_PortfolioCateoryid",
                table: "portfolios",
                column: "PortfolioCateoryid",
                principalTable: "portfolioCateories",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_portfolios_portfolios_Portfoliocategoryid",
                table: "portfolios",
                column: "Portfoliocategoryid",
                principalTable: "portfolios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
