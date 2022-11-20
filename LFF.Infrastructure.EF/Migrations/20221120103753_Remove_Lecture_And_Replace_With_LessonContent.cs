using Microsoft.EntityFrameworkCore.Migrations;

namespace LFF.Infrastructure.EF.Migrations
{
    public partial class Remove_Lecture_And_Replace_With_LessonContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Lessons_LessonId",
                table: "Lectures");

            migrationBuilder.RenameTable(
                name: "Lectures",
                newName: "Lecture");

            migrationBuilder.RenameIndex(
                name: "IX_Lectures_LessonId",
                table: "Lecture",
                newName: "IX_Lecture_LessonId");

            migrationBuilder.AddColumn<string>(
                name: "LessonContent",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_Lessons_LessonId",
                table: "Lecture",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_Lessons_LessonId",
                table: "Lecture");

            migrationBuilder.DropColumn(
                name: "LessonContent",
                table: "Lessons");

            migrationBuilder.RenameTable(
                name: "Lecture",
                newName: "Lectures");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_LessonId",
                table: "Lectures",
                newName: "IX_Lectures_LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Lessons_LessonId",
                table: "Lectures",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }
    }
}
