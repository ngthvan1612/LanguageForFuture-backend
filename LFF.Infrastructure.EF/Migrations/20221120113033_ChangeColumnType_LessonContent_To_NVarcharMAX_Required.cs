using Microsoft.EntityFrameworkCore.Migrations;

namespace LFF.Infrastructure.EF.Migrations
{
    public partial class ChangeColumnType_LessonContent_To_NVarcharMAX_Required : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LessonContent",
                table: "Lessons",
                type: "NVARCHAR(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LessonContent",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(MAX)");
        }
    }
}
