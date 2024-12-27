using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingQuiz.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELnl7sDo0eycAqyQ2o7hJeTiCbbfsabcV0UQmzT2DenwLKbLj6d4YfuGpbP6OMHvHg==");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsApproved", "Name", "PasswordHash", "Phone", "Role" },
                values: new object[] { 2, "student@gmail.com", true, "Andreaai ", "AQAAAAIAAYagAAAAELV3ekrgMmTEVm1yl5E/vJZdg+OIM/wpSm8T6wUfzMMsyPmQoq8n5fXb4Pwm7fD4/Q==", "12341445", "Student" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEIHTqjiRDYaGB2SR/eQg08hPnPxLyeG9XF0a0pxZIUzazP/oJc5FMr/ln7UVW9AN5g==");
        }
    }
}
