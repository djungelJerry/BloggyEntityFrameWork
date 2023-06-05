using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloggyEntityFrameWork.Migrations
{
    /// <inheritdoc />
    public partial class blogpåle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "blogs",
                newName: "BlogPostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogPostId",
                table: "blogs",
                newName: "BlogId");
        }
    }
}
