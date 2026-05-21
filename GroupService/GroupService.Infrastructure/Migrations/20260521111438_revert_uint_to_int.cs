using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GroupService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class revert_uint_to_int : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupEvents_EventProjections_EventProjectionId1",
                table: "GroupEvents");

            migrationBuilder.DropIndex(
                name: "IX_GroupEvents_EventProjectionId1",
                table: "GroupEvents");

            migrationBuilder.DropColumn(
                name: "EventProjectionId1",
                table: "GroupEvents");

            migrationBuilder.AlterColumn<int>(
                name: "CountStudents",
                table: "Groups",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "PlannedCount",
                table: "GroupEvents",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "ActualCount",
                table: "GroupEvents",
                type: "integer",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CountStudents",
                table: "Groups",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "PlannedCount",
                table: "GroupEvents",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "ActualCount",
                table: "GroupEvents",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EventProjectionId1",
                table: "GroupEvents",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupEvents_EventProjectionId1",
                table: "GroupEvents",
                column: "EventProjectionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEvents_EventProjections_EventProjectionId1",
                table: "GroupEvents",
                column: "EventProjectionId1",
                principalTable: "EventProjections",
                principalColumn: "Id");
        }
    }
}
