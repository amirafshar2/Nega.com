using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture10",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture2",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture3",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture4",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture5",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture6",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture7",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture8",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture9",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title10",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title3",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title4",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title5",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title6",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title7",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title8",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title9",
                table: "packages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture10",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Picture2",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Picture3",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Picture4",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Picture5",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Picture6",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Picture7",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Picture8",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Picture9",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Title10",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Title2",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Title3",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Title4",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Title5",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Title6",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Title7",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Title8",
                table: "packages");

            migrationBuilder.DropColumn(
                name: "Title9",
                table: "packages");
        }
    }
}
