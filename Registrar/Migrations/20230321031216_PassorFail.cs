using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registrar.Migrations
{
    public partial class PassorFail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PassFail",
                table: "StudentCourses",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassFail",
                table: "StudentCourses");
        }
    }
}
