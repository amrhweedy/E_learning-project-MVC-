using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.Migrations
{
    /// <inheritdoc />
    public partial class updateEnrollment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Enrollments_EnrollmentId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_EnrollmentId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Enrollments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Enrollments");

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_EnrollmentId",
                table: "Courses",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Enrollments_EnrollmentId",
                table: "Courses",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
