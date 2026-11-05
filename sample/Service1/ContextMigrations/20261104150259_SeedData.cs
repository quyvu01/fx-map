using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Service1.ContextMigrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Before this migration the services seeded these rows in code when they started. Removing them first lets the
            // inserts below run on a database that the old seeding already filled.
            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    "member-001",
                    "member-002",
                    "member-003",
                    "member-004",
                    "member-005",
                    "member-006",
                    "member-007",
                    "member-008",
                    "member-009",
                    "member-010",
                    "member-011",
                    "member-012",
                    "member-013",
                    "member-014",
                    "member-015",
                    "member-016",
                    "member-017",
                    "member-018",
                    "member-019",
                    "member-020"
                });

            migrationBuilder.InsertData(
                table: "MemberAdditionalDatas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "member-001", "Alice Cooper" },
                    { "member-002", "Bob Dylan" },
                    { "member-003", "Charlie Chaplin" },
                    { "member-004", "Diana Prince" },
                    { "member-005", "Edward Norton" },
                    { "member-006", "Fiona Apple" },
                    { "member-007", "George Harrison" },
                    { "member-008", "Helen Mirren" },
                    { "member-009", "Isaac Newton" },
                    { "member-010", "Julia Roberts" },
                    { "member-011", "Kevin Bacon" },
                    { "member-012", "Laura Dern" },
                    { "member-013", "Michael Jordan" },
                    { "member-014", "Natalie Portman" },
                    { "member-015", "Oscar Wilde" },
                    { "member-016", "Patricia Arquette" },
                    { "member-017", "Quentin Tarantino" },
                    { "member-018", "Rachel Green" },
                    { "member-019", "Samuel Jackson" },
                    { "member-020", "Tina Turner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-001");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-002");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-003");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-004");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-005");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-006");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-007");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-008");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-009");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-010");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-011");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-012");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-013");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-014");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-015");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-016");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-017");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-018");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-019");

            migrationBuilder.DeleteData(
                table: "MemberAdditionalDatas",
                keyColumn: "Id",
                keyValue: "member-020");
        }
    }
}
