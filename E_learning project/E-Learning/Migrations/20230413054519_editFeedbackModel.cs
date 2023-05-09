using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Learning.Migrations
{
    /// <inheritdoc />
    public partial class editFeedbackModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Feedbacks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
