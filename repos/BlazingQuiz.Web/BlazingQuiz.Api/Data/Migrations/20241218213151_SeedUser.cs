using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingQuiz.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "PasswordHash" },
                values: new object[] { "Andrei", "AQAAAAIAAYagAAAAECSlf1jGvorwNScsGYghKi4djgSei/oLWOqyJi7bSbBUUPEszmzCYIGIbivXyX0GrQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEANNijnxFJH18e+aYpweFknnjuBHWbKgbE28KDCcgyn6CRmj4Phlr6I2cx52q09Xgg==");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsApproved", "Name", "PasswordHash", "Phone", "Role" },
                values: new object[] { 3, "student@gmail.com", true, "Bnadsaaaaareaai ", "AQAAAAIAAYagAAAAEF+uakt8ozWVpFCROmf6cGPU0wSgiJ1UpK9n1lYunICcVyg5H9wRKYKc+L6iNxW5Ag==", "12341445", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "PasswordHash" },
                values: new object[] { "Andrei Stan", "AQAAAAIAAYagAAAAELnl7sDo0eycAqyQ2o7hJeTiCbbfsabcV0UQmzT2DenwLKbLj6d4YfuGpbP6OMHvHg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELV3ekrgMmTEVm1yl5E/vJZdg+OIM/wpSm8T6wUfzMMsyPmQoq8n5fXb4Pwm7fD4/Q==");
        }
    }
}
