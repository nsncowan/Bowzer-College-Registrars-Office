using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registrar.Migrations
{
    public partial class department_new_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId1",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentId1",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId1",
                table: "Courses",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId1",
                table: "Courses",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "DepartmentId");
        }
    }
}
