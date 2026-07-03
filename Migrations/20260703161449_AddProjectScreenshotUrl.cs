using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_Project.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectScreenshotUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScreenshotUrl",
                table: "Projects",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenshotUrl",
                table: "Projects");
        }
    }
}
