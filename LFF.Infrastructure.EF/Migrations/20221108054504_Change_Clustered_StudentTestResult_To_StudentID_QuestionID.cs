using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LFF.Infrastructure.EF.Migrations
{
    public partial class Change_Clustered_StudentTestResult_To_StudentID_QuestionID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTestResult_Id",
                table: "StudentTestResults");

            migrationBuilder.DropIndex(
                name: "IX_StudentTestResults_QuestionId",
                table: "StudentTestResults");

            migrationBuilder.AlterColumn<int>(
                name: "Time",
                table: "Tests",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_StudentTestResults_QuestionId_StudentTestId",
                table: "StudentTestResults",
                columns: new[] { "QuestionId", "StudentTestId" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTestResult_Id",
                table: "StudentTestResults",
                column: "Id")
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_StudentTestResults_QuestionId_StudentTestId",
                table: "StudentTestResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentTestResult_Id",
                table: "StudentTestResults");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Time",
                table: "Tests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentTestResult_Id",
                table: "StudentTestResults",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTestResults_QuestionId",
                table: "StudentTestResults",
                column: "QuestionId");
        }
    }
}
