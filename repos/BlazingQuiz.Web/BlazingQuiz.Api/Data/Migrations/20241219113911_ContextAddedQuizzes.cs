using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingQuiz.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ContextAddedQuizzes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quiz_QuizId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quiz_Categories_CategoryId",
                table: "Quiz");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuizzes_Quiz_QuizId",
                table: "StudentQuizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz");

            migrationBuilder.RenameTable(
                name: "Quiz",
                newName: "Quizzes");

            migrationBuilder.RenameIndex(
                name: "IX_Quiz_CategoryId",
                table: "Quizzes",
                newName: "IX_Quizzes_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Categories_CategoryId",
                table: "Quizzes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuizzes_Quizzes_QuizId",
                table: "StudentQuizzes",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Categories_CategoryId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentQuizzes_Quizzes_QuizId",
                table: "StudentQuizzes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quizzes",
                table: "Quizzes");

            migrationBuilder.RenameTable(
                name: "Quizzes",
                newName: "Quiz");

            migrationBuilder.RenameIndex(
                name: "IX_Quizzes_CategoryId",
                table: "Quiz",
                newName: "IX_Quiz_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quiz",
                table: "Quiz",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIlWba9ibo4SODBDxahnvXdX2kRorFHOKoPV+R0OZjGGbfovaI+cBF2xDS7H+Vy5ww==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI7U+5CzQzQNO1imWZbA0zWXgEySQXhPtRO9pPsJBxL9Ct+YYF2sbADga5m8ukSw7Q==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEFfBfCo0rGziRo3AMvUTf0b1KIniiGKxcR/n8ZNR+TXvlSdz44qsgwjLeaO9vTk0uw==");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quiz_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Quiz_Categories_CategoryId",
                table: "Quiz",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentQuizzes_Quiz_QuizId",
                table: "StudentQuizzes",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
