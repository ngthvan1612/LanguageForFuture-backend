using Microsoft.EntityFrameworkCore.Migrations;

namespace LFF.Infrastructure.EF.Migrations
{
    public partial class Add_Approval_To_Lesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Lessons",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForNotApproving",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "ReasonForNotApproving",
                table: "Lessons");
        }
    }
}
