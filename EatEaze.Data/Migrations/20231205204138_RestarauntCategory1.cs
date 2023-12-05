using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatEaze.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestarauntCategory1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Restaraunts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Restaraunts_CategoryId",
                table: "Restaraunts",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaraunts_Categories_CategoryId",
                table: "Restaraunts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaraunts_Categories_CategoryId",
                table: "Restaraunts");

            migrationBuilder.DropIndex(
                name: "IX_Restaraunts_CategoryId",
                table: "Restaraunts");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Restaraunts");
        }
    }
}
