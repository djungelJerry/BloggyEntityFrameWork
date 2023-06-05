using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloggyEntityFrameWork.Migrations
{
    /// <inheritdoc />
    public partial class @switch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BlogPostCategory",
                columns: table => new
                {
                    CategoriesCategoryId = table.Column<int>(type: "int", nullable: false),
                    blogPostsBlogPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostCategory", x => new { x.CategoriesCategoryId, x.blogPostsBlogPostId });
                    table.ForeignKey(
                        name: "FK_BlogPostCategory_blogs_blogPostsBlogPostId",
                        column: x => x.blogPostsBlogPostId,
                        principalTable: "blogs",
                        principalColumn: "BlogPostId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogPostCategory_categories_CategoriesCategoryId",
                        column: x => x.CategoriesCategoryId,
                        principalTable: "categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostCategory_blogPostsBlogPostId",
                table: "BlogPostCategory",
                column: "blogPostsBlogPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostCategory");

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
    }
}
