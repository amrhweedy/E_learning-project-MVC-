using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.Migrations
{
    /// <inheritdoc />
    public partial class updateStudentmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseHistory",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EnrollmentHistory",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PaymentHistory",
                table: "Students");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseHistory",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EnrollmentHistory",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentHistory",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
