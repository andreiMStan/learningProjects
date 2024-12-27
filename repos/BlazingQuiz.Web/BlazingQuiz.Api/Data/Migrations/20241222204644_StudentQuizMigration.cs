using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingQuiz.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentQuizMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedOn",
                table: "StudentQuizzes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "StudentQuizzes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "StudentQuizQuestions",
                columns: table => new
                {
                    StudentQuizId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuizQuestions", x => new { x.StudentQuizId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_StudentQuizQuestions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentQuizQuestions_StudentQuizzes_StudentQuizId",
                        column: x => x.StudentQuizId,
                        principalTable: "StudentQuizzes",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEN5smiSt9AKYr0eNINExFacAP8+MW0rGFL21mJpYOSKQdcaZFiAYxmOdvNy6RzZ8oQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELPI/Vd67xzKS/09YlictjhfE5r5hPjlTI4FtdpQKjzfVT7gCWo/mzMNXFTrZzaGKw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPM+HWvH1gRxC/4d2KaSV+O0BPNuhfQ8XfxksvfsFvhcOy5HAbaa5C0ntsKpGHTj+Q==");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuizQuestions_QuestionId",
                table: "StudentQuizQuestions",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentQuizQuestions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "StudentQuizzes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CompletedOn",
                table: "StudentQuizzes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECu17zxlo98VSw/ygxFcaPIE5DLcwEWqfC/gpIq87y1k7rpRpVyOy7BEYmNtK323WQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKp5kQfKMztxSOVbhhKZ1boTrYsE0lLWboeFUK1sdYuC1Qy5FOrFclv4VKFh27DFCw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELOlgWg+VgHQeNbiSgYsqYONcaiFgyn+LrOSrXcvIZvpQsizRzlOtt+QpB5S89N6tQ==");
        }
    }
}
