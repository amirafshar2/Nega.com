using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PortfolioCateoryid",
                table: "portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Portfoliocategoryid",
                table: "portfolios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "portfolioCateories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioCateories", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_portfolios_Portfoliocategoryid",
                table: "portfolios",
                column: "Portfoliocategoryid");

            migrationBuilder.CreateIndex(
                name: "IX_portfolios_PortfolioCateoryid",
                table: "portfolios",
                column: "PortfolioCateoryid");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_portfolios_portfolioCateories_PortfolioCateoryid",
                table: "portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_portfolios_portfolios_Portfoliocategoryid",
                table: "portfolios");

            migrationBuilder.DropTable(
                name: "portfolioCateories");

            migrationBuilder.DropIndex(
                name: "IX_portfolios_Portfoliocategoryid",
                table: "portfolios");

            migrationBuilder.DropIndex(
                name: "IX_portfolios_PortfolioCateoryid",
                table: "portfolios");

            migrationBuilder.DropColumn(
                name: "PortfolioCateoryid",
                table: "portfolios");

            migrationBuilder.DropColumn(
                name: "Portfoliocategoryid",
                table: "portfolios");
        }
    }
}
