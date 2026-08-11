using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_configurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryEvents_CategoryId",
                table: "CategoryEvents");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEvents_CategoryId_EventId",
                table: "CategoryEvents",
                columns: new[] { "CategoryId", "EventId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryEvents_CategoryId_EventId",
                table: "CategoryEvents");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEvents_CategoryId",
                table: "CategoryEvents",
                column: "CategoryId");
        }
    }
}
