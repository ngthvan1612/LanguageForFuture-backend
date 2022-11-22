using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LFF.Infrastructure.EF.Migrations
{
    public partial class Remove_Submitted_From_StudentTestResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmittedOn",
                table: "StudentTestResults");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedOn",
                table: "StudentTestResults",
                type: "datetime2",
                nullable: true);
        }
    }
}
