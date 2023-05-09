using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.Migrations
{
    /// <inheritdoc />
    public partial class updateEnrollmentmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Enrollments_EnrollmentId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_EnrollmentId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "EnrollmentId",
                table: "Payments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnrollmentId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EnrollmentId",
                table: "Payments",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Enrollments_EnrollmentId",
                table: "Payments",
                column: "EnrollmentId",
                principalTable: "Enrollments",
                principalColumn: "Id");
        }
    }
}
