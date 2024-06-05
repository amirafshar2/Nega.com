using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "İmage4",
                table: "blogs",
                newName: "Title9");

            migrationBuilder.RenameColumn(
                name: "İmage3",
                table: "blogs",
                newName: "Title8");

            migrationBuilder.RenameColumn(
                name: "İmage2",
                table: "blogs",
                newName: "Title7");

            migrationBuilder.RenameColumn(
                name: "İmage1",
                table: "blogs",
                newName: "Title6");

            migrationBuilder.RenameColumn(
                name: "İmage",
                table: "blogs",
                newName: "Title5");

            migrationBuilder.RenameColumn(
                name: "TompNailİmage",
                table: "blogs",
                newName: "Title4");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "blogs",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Content10",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content5",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content6",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content7",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content8",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content9",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture10",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture2",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture3",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture4",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture5",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture6",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture7",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture8",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Picture9",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title10",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title3",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content10",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Content5",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Content6",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Content7",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Content8",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Content9",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Picture10",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Picture2",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Picture3",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Picture4",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Picture5",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Picture6",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Picture7",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Picture8",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Picture9",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Title10",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "Title3",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "Title9",
                table: "blogs",
                newName: "İmage4");

            migrationBuilder.RenameColumn(
                name: "Title8",
                table: "blogs",
                newName: "İmage3");

            migrationBuilder.RenameColumn(
                name: "Title7",
                table: "blogs",
                newName: "İmage2");

            migrationBuilder.RenameColumn(
                name: "Title6",
                table: "blogs",
                newName: "İmage1");

            migrationBuilder.RenameColumn(
                name: "Title5",
                table: "blogs",
                newName: "İmage");

            migrationBuilder.RenameColumn(
                name: "Title4",
                table: "blogs",
                newName: "TompNailİmage");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "blogs",
                newName: "CreateDate");
        }
    }
}
