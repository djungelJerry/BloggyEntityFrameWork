using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloggyEntityFrameWork.Migrations
{
    /// <inheritdoc />
    public partial class addingContentColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "blogs");
        }
    }
}
