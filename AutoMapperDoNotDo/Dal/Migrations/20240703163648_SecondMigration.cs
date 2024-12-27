using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "JobRole", "Name", "RegistrationId" },
                values: new object[,]
                {
                    { 1, "Department1", "Software Engineer", "Employee1", 1 },
                    { 2, "Department2", "Software Engineer", "Employee2", 2 },
                    { 3, "Department3", "Software Engineer", "Employee3", 3 },
                    { 4, "Department4", "Software Engineer", "Employee4", 4 },
                    { 5, "Department5", "Software Engineer", "Employee5", 5 },
                    { 6, "Department6", "Software Engineer", "Employee6", 6 },
                    { 7, "Department7", "Software Engineer", "Employee7", 7 },
                    { 8, "Department8", "Software Engineer", "Employee8", 8 },
                    { 9, "Department9", "Software Engineer", "Employee9", 9 },
                    { 10, "Department10", "Software Engineer", "Employee10", 10 },
                    { 11, "Department11", "Software Engineer", "Employee11", 11 },
                    { 12, "Department12", "Software Engineer", "Employee12", 12 },
                    { 13, "Department13", "Software Engineer", "Employee13", 13 },
                    { 14, "Department14", "Software Engineer", "Employee14", 14 },
                    { 15, "Department15", "Software Engineer", "Employee15", 15 },
                    { 16, "Department16", "Software Engineer", "Employee16", 16 },
                    { 17, "Department17", "Software Engineer", "Employee17", 17 },
                    { 18, "Department18", "Software Engineer", "Employee18", 18 },
                    { 19, "Department19", "Software Engineer", "Employee19", 19 },
                    { 20, "Department20", "Software Engineer", "Employee20", 20 },
                    { 21, "Department21", "Software Engineer", "Employee21", 21 },
                    { 22, "Department22", "Software Engineer", "Employee22", 22 },
                    { 23, "Department23", "Software Engineer", "Employee23", 23 },
                    { 24, "Department24", "Software Engineer", "Employee24", 24 },
                    { 25, "Department25", "Software Engineer", "Employee25", 25 },
                    { 26, "Department26", "Software Engineer", "Employee26", 26 },
                    { 27, "Department27", "Software Engineer", "Employee27", 27 },
                    { 28, "Department28", "Software Engineer", "Employee28", 28 },
                    { 29, "Department29", "Software Engineer", "Employee29", 29 },
                    { 30, "Department30", "Software Engineer", "Employee30", 30 },
                    { 31, "Department31", "Software Engineer", "Employee31", 31 },
                    { 32, "Department32", "Software Engineer", "Employee32", 32 },
                    { 33, "Department33", "Software Engineer", "Employee33", 33 },
                    { 34, "Department34", "Software Engineer", "Employee34", 34 },
                    { 35, "Department35", "Software Engineer", "Employee35", 35 },
                    { 36, "Department36", "Software Engineer", "Employee36", 36 },
                    { 37, "Department37", "Software Engineer", "Employee37", 37 },
                    { 38, "Department38", "Software Engineer", "Employee38", 38 },
                    { 39, "Department39", "Software Engineer", "Employee39", 39 },
                    { 40, "Department40", "Software Engineer", "Employee40", 40 },
                    { 41, "Department41", "Software Engineer", "Employee41", 41 },
                    { 42, "Department42", "Software Engineer", "Employee42", 42 },
                    { 43, "Department43", "Software Engineer", "Employee43", 43 },
                    { 44, "Department44", "Software Engineer", "Employee44", 44 },
                    { 45, "Department45", "Software Engineer", "Employee45", 45 },
                    { 46, "Department46", "Software Engineer", "Employee46", 46 },
                    { 47, "Department47", "Software Engineer", "Employee47", 47 },
                    { 48, "Department48", "Software Engineer", "Employee48", 48 },
                    { 49, "Department49", "Software Engineer", "Employee49", 49 },
                    { 50, "Department50", "Software Engineer", "Employee50", 50 },
                    { 51, "Department51", "Software Engineer", "Employee51", 51 },
                    { 52, "Department52", "Software Engineer", "Employee52", 52 },
                    { 53, "Department53", "Software Engineer", "Employee53", 53 },
                    { 54, "Department54", "Software Engineer", "Employee54", 54 },
                    { 55, "Department55", "Software Engineer", "Employee55", 55 },
                    { 56, "Department56", "Software Engineer", "Employee56", 56 },
                    { 57, "Department57", "Software Engineer", "Employee57", 57 },
                    { 58, "Department58", "Software Engineer", "Employee58", 58 },
                    { 59, "Department59", "Software Engineer", "Employee59", 59 },
                    { 60, "Department60", "Software Engineer", "Employee60", 60 },
                    { 61, "Department61", "Software Engineer", "Employee61", 61 },
                    { 62, "Department62", "Software Engineer", "Employee62", 62 },
                    { 63, "Department63", "Software Engineer", "Employee63", 63 },
                    { 64, "Department64", "Software Engineer", "Employee64", 64 },
                    { 65, "Department65", "Software Engineer", "Employee65", 65 },
                    { 66, "Department66", "Software Engineer", "Employee66", 66 },
                    { 67, "Department67", "Software Engineer", "Employee67", 67 },
                    { 68, "Department68", "Software Engineer", "Employee68", 68 },
                    { 69, "Department69", "Software Engineer", "Employee69", 69 },
                    { 70, "Department70", "Software Engineer", "Employee70", 70 },
                    { 71, "Department71", "Software Engineer", "Employee71", 71 },
                    { 72, "Department72", "Software Engineer", "Employee72", 72 },
                    { 73, "Department73", "Software Engineer", "Employee73", 73 },
                    { 74, "Department74", "Software Engineer", "Employee74", 74 },
                    { 75, "Department75", "Software Engineer", "Employee75", 75 },
                    { 76, "Department76", "Software Engineer", "Employee76", 76 },
                    { 77, "Department77", "Software Engineer", "Employee77", 77 },
                    { 78, "Department78", "Software Engineer", "Employee78", 78 },
                    { 79, "Department79", "Software Engineer", "Employee79", 79 },
                    { 80, "Department80", "Software Engineer", "Employee80", 80 },
                    { 81, "Department81", "Software Engineer", "Employee81", 81 },
                    { 82, "Department82", "Software Engineer", "Employee82", 82 },
                    { 83, "Department83", "Software Engineer", "Employee83", 83 },
                    { 84, "Department84", "Software Engineer", "Employee84", 84 },
                    { 85, "Department85", "Software Engineer", "Employee85", 85 },
                    { 86, "Department86", "Software Engineer", "Employee86", 86 },
                    { 87, "Department87", "Software Engineer", "Employee87", 87 },
                    { 88, "Department88", "Software Engineer", "Employee88", 88 },
                    { 89, "Department89", "Software Engineer", "Employee89", 89 },
                    { 90, "Department90", "Software Engineer", "Employee90", 90 },
                    { 91, "Department91", "Software Engineer", "Employee91", 91 },
                    { 92, "Department92", "Software Engineer", "Employee92", 92 },
                    { 93, "Department93", "Software Engineer", "Employee93", 93 },
                    { 94, "Department94", "Software Engineer", "Employee94", 94 },
                    { 95, "Department95", "Software Engineer", "Employee95", 95 },
                    { 96, "Department96", "Software Engineer", "Employee96", 96 },
                    { 97, "Department97", "Software Engineer", "Employee97", 97 },
                    { 98, "Department98", "Software Engineer", "Employee98", 98 },
                    { 99, "Department99", "Software Engineer", "Employee99", 99 },
                    { 100, "Department100", "Software Engineer", "Employee100", 100 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "EmployeeId", "Number", "Street" },
                values: new object[,]
                {
                    { 1, "Timisoara", "Romania", 1, 1, "Street 1" },
                    { 2, "Timisoara", "Romania", 2, 2, "Street 2" },
                    { 3, "Timisoara", "Romania", 3, 3, "Street 3" },
                    { 4, "Timisoara", "Romania", 4, 4, "Street 4" },
                    { 5, "Timisoara", "Romania", 5, 5, "Street 5" },
                    { 6, "Timisoara", "Romania", 6, 6, "Street 6" },
                    { 7, "Timisoara", "Romania", 7, 7, "Street 7" },
                    { 8, "Timisoara", "Romania", 8, 8, "Street 8" },
                    { 9, "Timisoara", "Romania", 9, 9, "Street 9" },
                    { 10, "Timisoara", "Romania", 10, 10, "Street 10" },
                    { 11, "Timisoara", "Romania", 11, 11, "Street 11" },
                    { 12, "Timisoara", "Romania", 12, 12, "Street 12" },
                    { 13, "Timisoara", "Romania", 13, 13, "Street 13" },
                    { 14, "Timisoara", "Romania", 14, 14, "Street 14" },
                    { 15, "Timisoara", "Romania", 15, 15, "Street 15" },
                    { 16, "Timisoara", "Romania", 16, 16, "Street 16" },
                    { 17, "Timisoara", "Romania", 17, 17, "Street 17" },
                    { 18, "Timisoara", "Romania", 18, 18, "Street 18" },
                    { 19, "Timisoara", "Romania", 19, 19, "Street 19" },
                    { 20, "Timisoara", "Romania", 20, 20, "Street 20" },
                    { 21, "Timisoara", "Romania", 21, 21, "Street 21" },
                    { 22, "Timisoara", "Romania", 22, 22, "Street 22" },
                    { 23, "Timisoara", "Romania", 23, 23, "Street 23" },
                    { 24, "Timisoara", "Romania", 24, 24, "Street 24" },
                    { 25, "Timisoara", "Romania", 25, 25, "Street 25" },
                    { 26, "Timisoara", "Romania", 26, 26, "Street 26" },
                    { 27, "Timisoara", "Romania", 27, 27, "Street 27" },
                    { 28, "Timisoara", "Romania", 28, 28, "Street 28" },
                    { 29, "Timisoara", "Romania", 29, 29, "Street 29" },
                    { 30, "Timisoara", "Romania", 30, 30, "Street 30" },
                    { 31, "Timisoara", "Romania", 31, 31, "Street 31" },
                    { 32, "Timisoara", "Romania", 32, 32, "Street 32" },
                    { 33, "Timisoara", "Romania", 33, 33, "Street 33" },
                    { 34, "Timisoara", "Romania", 34, 34, "Street 34" },
                    { 35, "Timisoara", "Romania", 35, 35, "Street 35" },
                    { 36, "Timisoara", "Romania", 36, 36, "Street 36" },
                    { 37, "Timisoara", "Romania", 37, 37, "Street 37" },
                    { 38, "Timisoara", "Romania", 38, 38, "Street 38" },
                    { 39, "Timisoara", "Romania", 39, 39, "Street 39" },
                    { 40, "Timisoara", "Romania", 40, 40, "Street 40" },
                    { 41, "Timisoara", "Romania", 41, 41, "Street 41" },
                    { 42, "Timisoara", "Romania", 42, 42, "Street 42" },
                    { 43, "Timisoara", "Romania", 43, 43, "Street 43" },
                    { 44, "Timisoara", "Romania", 44, 44, "Street 44" },
                    { 45, "Timisoara", "Romania", 45, 45, "Street 45" },
                    { 46, "Timisoara", "Romania", 46, 46, "Street 46" },
                    { 47, "Timisoara", "Romania", 47, 47, "Street 47" },
                    { 48, "Timisoara", "Romania", 48, 48, "Street 48" },
                    { 49, "Timisoara", "Romania", 49, 49, "Street 49" },
                    { 50, "Timisoara", "Romania", 50, 50, "Street 50" },
                    { 51, "Timisoara", "Romania", 51, 51, "Street 51" },
                    { 52, "Timisoara", "Romania", 52, 52, "Street 52" },
                    { 53, "Timisoara", "Romania", 53, 53, "Street 53" },
                    { 54, "Timisoara", "Romania", 54, 54, "Street 54" },
                    { 55, "Timisoara", "Romania", 55, 55, "Street 55" },
                    { 56, "Timisoara", "Romania", 56, 56, "Street 56" },
                    { 57, "Timisoara", "Romania", 57, 57, "Street 57" },
                    { 58, "Timisoara", "Romania", 58, 58, "Street 58" },
                    { 59, "Timisoara", "Romania", 59, 59, "Street 59" },
                    { 60, "Timisoara", "Romania", 60, 60, "Street 60" },
                    { 61, "Timisoara", "Romania", 61, 61, "Street 61" },
                    { 62, "Timisoara", "Romania", 62, 62, "Street 62" },
                    { 63, "Timisoara", "Romania", 63, 63, "Street 63" },
                    { 64, "Timisoara", "Romania", 64, 64, "Street 64" },
                    { 65, "Timisoara", "Romania", 65, 65, "Street 65" },
                    { 66, "Timisoara", "Romania", 66, 66, "Street 66" },
                    { 67, "Timisoara", "Romania", 67, 67, "Street 67" },
                    { 68, "Timisoara", "Romania", 68, 68, "Street 68" },
                    { 69, "Timisoara", "Romania", 69, 69, "Street 69" },
                    { 70, "Timisoara", "Romania", 70, 70, "Street 70" },
                    { 71, "Timisoara", "Romania", 71, 71, "Street 71" },
                    { 72, "Timisoara", "Romania", 72, 72, "Street 72" },
                    { 73, "Timisoara", "Romania", 73, 73, "Street 73" },
                    { 74, "Timisoara", "Romania", 74, 74, "Street 74" },
                    { 75, "Timisoara", "Romania", 75, 75, "Street 75" },
                    { 76, "Timisoara", "Romania", 76, 76, "Street 76" },
                    { 77, "Timisoara", "Romania", 77, 77, "Street 77" },
                    { 78, "Timisoara", "Romania", 78, 78, "Street 78" },
                    { 79, "Timisoara", "Romania", 79, 79, "Street 79" },
                    { 80, "Timisoara", "Romania", 80, 80, "Street 80" },
                    { 81, "Timisoara", "Romania", 81, 81, "Street 81" },
                    { 82, "Timisoara", "Romania", 82, 82, "Street 82" },
                    { 83, "Timisoara", "Romania", 83, 83, "Street 83" },
                    { 84, "Timisoara", "Romania", 84, 84, "Street 84" },
                    { 85, "Timisoara", "Romania", 85, 85, "Street 85" },
                    { 86, "Timisoara", "Romania", 86, 86, "Street 86" },
                    { 87, "Timisoara", "Romania", 87, 87, "Street 87" },
                    { 88, "Timisoara", "Romania", 88, 88, "Street 88" },
                    { 89, "Timisoara", "Romania", 89, 89, "Street 89" },
                    { 90, "Timisoara", "Romania", 90, 90, "Street 90" },
                    { 91, "Timisoara", "Romania", 91, 91, "Street 91" },
                    { 92, "Timisoara", "Romania", 92, 92, "Street 92" },
                    { 93, "Timisoara", "Romania", 93, 93, "Street 93" },
                    { 94, "Timisoara", "Romania", 94, 94, "Street 94" },
                    { 95, "Timisoara", "Romania", 95, 95, "Street 95" },
                    { 96, "Timisoara", "Romania", 96, 96, "Street 96" },
                    { 97, "Timisoara", "Romania", 97, 97, "Street 97" },
                    { 98, "Timisoara", "Romania", 98, 98, "Street 98" },
                    { 99, "Timisoara", "Romania", 99, 99, "Street 99" },
                    { 100, "Timisoara", "Romania", 100, 100, "Street 100" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 100);
        }
    }
}
