using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingQuiz.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seed3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "aa@gmail.com", "AQAAAAIAAYagAAAAEFfBfCo0rGziRo3AMvUTf0b1KIniiGKxcR/n8ZNR+TXvlSdz44qsgwjLeaO9vTk0uw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAECSlf1jGvorwNScsGYghKi4djgSei/oLWOqyJi7bSbBUUPEszmzCYIGIbivXyX0GrQ==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEANNijnxFJH18e+aYpweFknnjuBHWbKgbE28KDCcgyn6CRmj4Phlr6I2cx52q09Xgg==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "PasswordHash" },
                values: new object[] { "student@gmail.com", "AQAAAAIAAYagAAAAEF+uakt8ozWVpFCROmf6cGPU0wSgiJ1UpK9n1lYunICcVyg5H9wRKYKc+L6iNxW5Ag==" });
        }
    }
}
