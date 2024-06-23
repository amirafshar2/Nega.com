using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DelateStatus",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelateStatus",
                table: "AspNetUsers");
        }
    }
}
