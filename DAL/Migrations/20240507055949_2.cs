using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comments_BlogId",
                table: "comments",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_CategoryId",
                table: "blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_UserId",
                table: "blogs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_categories_CategoryId",
                table: "blogs",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_users_UserId",
                table: "blogs",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_blogs_BlogId",
                table: "comments",
                column: "BlogId",
                principalTable: "blogs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_categories_CategoryId",
                table: "blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_blogs_users_UserId",
                table: "blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_blogs_BlogId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_BlogId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_blogs_CategoryId",
                table: "blogs");

            migrationBuilder.DropIndex(
                name: "IX_blogs_UserId",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "blogs");
        }
    }
}
