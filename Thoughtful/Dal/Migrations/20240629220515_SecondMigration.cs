using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BlogId",
                table: "Authors",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Blog_BlogId",
                table: "Authors",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Blog_BlogId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_BlogId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Authors");
        }
    }
}
