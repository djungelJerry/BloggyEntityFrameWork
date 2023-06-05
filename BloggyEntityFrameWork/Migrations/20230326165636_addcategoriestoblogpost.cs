using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloggyEntityFrameWork.Migrations
{
    /// <inheritdoc />
    public partial class addcategoriestoblogpost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_categories_BlogPostId",
                table: "categories",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_blogs_BlogPostId",
                table: "categories",
                column: "BlogPostId",
                principalTable: "blogs",
                principalColumn: "BlogPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_blogs_BlogPostId",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_BlogPostId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "categories");
        }
    }
}
