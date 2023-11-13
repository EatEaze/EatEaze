using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatEaze.Data.Migrations
{
    /// <inheritdoc />
    public partial class PriceMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Positions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Positions");
        }
    }
}
