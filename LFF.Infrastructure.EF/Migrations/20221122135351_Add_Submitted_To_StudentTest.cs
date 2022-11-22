using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LFF.Infrastructure.EF.Migrations
{
    public partial class Add_Submitted_To_StudentTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedOn",
                table: "StudentTests",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmittedOn",
                table: "StudentTests");
        }
    }
}
