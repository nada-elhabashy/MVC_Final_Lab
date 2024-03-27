using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Course_CoursesCrsId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Course_CrsId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CrsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesCrsId",
                table: "CourseDepartment",
                column: "CoursesCrsId",
                principalTable: "Courses",
                principalColumn: "CrsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CrsId",
                table: "StudentCourses",
                column: "CrsId",
                principalTable: "Courses",
                principalColumn: "CrsId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesCrsId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CrsId",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "CrsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Course_CoursesCrsId",
                table: "CourseDepartment",
                column: "CoursesCrsId",
                principalTable: "Course",
                principalColumn: "CrsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Course_CrsId",
                table: "StudentCourses",
                column: "CrsId",
                principalTable: "Course",
                principalColumn: "CrsId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
