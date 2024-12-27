using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_Achivements_Driver",
                table: "Achivements");

            migrationBuilder.AddForeignKey(
                name: "FK_Achivements_Driver",
                table: "Achivements",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achivements_Driver",
                table: "Achivements");

            migrationBuilder.AddForeignKey(
                name: "Fk_Achivements_Driver",
                table: "Achivements",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id");
        }
    }
}
