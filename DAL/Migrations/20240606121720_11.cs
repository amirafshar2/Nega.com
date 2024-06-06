using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_AspNetUsers_UserId",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "blogs",
                newName: "Userid");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_UserId",
                table: "blogs",
                newName: "IX_blogs_Userid");

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "blogs",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_AspNetUsers_Userid",
                table: "blogs",
                column: "Userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_AspNetUsers_Userid",
                table: "blogs");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "blogs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_blogs_Userid",
                table: "blogs",
                newName: "IX_blogs_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "blogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_AspNetUsers_UserId",
                table: "blogs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
