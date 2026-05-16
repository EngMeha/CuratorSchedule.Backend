using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventProjections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProjections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CountStudents = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    EventProjectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlannedCount = table.Column<int>(type: "integer", nullable: false),
                    ActualCount = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false, defaultValue: "Planned"),
                    EventProjectionId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupEvents_EventProjections_EventProjectionId",
                        column: x => x.EventProjectionId,
                        principalTable: "EventProjections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroupEvents_EventProjections_EventProjectionId1",
                        column: x => x.EventProjectionId1,
                        principalTable: "EventProjections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupEvents_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventProjections_EventId",
                table: "EventProjections",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupEvents_EventProjectionId_GroupId",
                table: "GroupEvents",
                columns: new[] { "EventProjectionId", "GroupId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupEvents_EventProjectionId1",
                table: "GroupEvents",
                column: "EventProjectionId1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupEvents_GroupId",
                table: "GroupEvents",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupEvents");

            migrationBuilder.DropTable(
                name: "EventProjections");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
