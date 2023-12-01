using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatEaze.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestarauntImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Restaraunts",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Restaraunts");
        }
    }
}
