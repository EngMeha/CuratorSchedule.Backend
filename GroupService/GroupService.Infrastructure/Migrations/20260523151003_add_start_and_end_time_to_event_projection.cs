using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_start_and_end_time_to_event_projection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "EndTime",
                table: "EventProjections",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartTime",
                table: "EventProjections",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "EventProjections");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "EventProjections");
        }
    }
}
