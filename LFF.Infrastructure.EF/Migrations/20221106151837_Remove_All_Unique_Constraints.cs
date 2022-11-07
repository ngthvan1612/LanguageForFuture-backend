using Microsoft.EntityFrameworkCore.Migrations;

namespace LFF.Infrastructure.EF.Migrations
{
    public partial class Remove_All_Unique_Constraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "IX_User_CMND",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "IX_User_Email",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "IX_User_Username",
                table: "Users");

            migrationBuilder.DropUniqueConstraint(
                name: "IX_Course_Name",
                table: "Courses");

            migrationBuilder.DropUniqueConstraint(
                name: "IX_Classroom_Name",
                table: "Classrooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "IX_User_CMND",
                table: "Users",
                column: "CMND");

            migrationBuilder.AddUniqueConstraint(
                name: "IX_User_Email",
                table: "Users",
                column: "Email");

            migrationBuilder.AddUniqueConstraint(
                name: "IX_User_Username",
                table: "Users",
                column: "Username");

            migrationBuilder.AddUniqueConstraint(
                name: "IX_Course_Name",
                table: "Courses",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "IX_Classroom_Name",
                table: "Classrooms",
                column: "Name");
        }
    }
}
