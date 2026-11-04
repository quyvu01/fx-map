using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Service2.Migrations
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
                table: "Users",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    "user-001",
                    "user-002",
                    "user-003",
                    "user-004",
                    "user-005",
                    "user-006",
                    "user-007",
                    "user-008",
                    "user-009",
                    "user-010",
                    "user-011",
                    "user-012",
                    "user-013",
                    "user-014",
                    "user-015",
                    "user-016",
                    "user-017",
                    "user-018",
                    "user-019",
                    "user-020",
                    "user-021",
                    "user-022",
                    "user-023",
                    "user-024",
                    "user-025",
                    "user-026",
                    "user-027",
                    "user-028",
                    "user-029",
                    "user-030",
                    "user-031",
                    "user-032",
                    "user-033",
                    "user-034",
                    "user-035",
                    "user-036",
                    "user-037",
                    "user-038",
                    "user-039",
                    "user-040",
                    "user-041",
                    "user-042",
                    "user-043",
                    "user-044",
                    "user-045",
                    "user-046",
                    "user-047",
                    "user-048",
                    "user-049",
                    "user-050",
                    "user-051",
                    "user-052",
                    "user-053",
                    "user-054"
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedTime", "Email", "Name", "ProvinceId" },
                values: new object[,]
                {
                    { "user-001", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "john.smith@email.com", "John Smith", "01962f9a-f7f8-7f61-941c-6a086fe96cd2" },
                    { "user-002", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "sarah.j@email.com", "Sarah Johnson", "01962f9a-f7f8-7f61-941c-6a086fe96cd2" },
                    { "user-003", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "michael.b@email.com", "Michael Brown", "01962f9a-f7f8-7f61-941c-6a086fe96cd2" },
                    { "user-004", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "emily.davis@email.com", "Emily Davis", "01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7" },
                    { "user-005", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "david.w@email.com", "David Wilson", "01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7" },
                    { "user-006", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "jennifer.m@email.com", "Jennifer Martinez", "01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7" },
                    { "user-007", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "robert.a@email.com", "Robert Anderson", "01962f9a-f7f8-7e54-a79d-575a8e882eb8" },
                    { "user-008", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "lisa.t@email.com", "Lisa Taylor", "01962f9a-f7f8-7e54-a79d-575a8e882eb8" },
                    { "user-009", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "james.t@email.com", "James Thomas", "01962f9a-f7f8-7a2c-8b3d-4c5e6f789012" },
                    { "user-010", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "mary.j@email.com", "Mary Jackson", "01962f9a-f7f8-7a2c-8b3d-4c5e6f789012" },
                    { "user-011", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "william.w@email.com", "William White", "01962f9a-f7f8-7d1b-9c2a-5d6e7f890123" },
                    { "user-012", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "patricia.h@email.com", "Patricia Harris", "01962f9a-f7f8-7d1b-9c2a-5d6e7f890123" },
                    { "user-013", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "daniel.m@email.com", "Daniel Martin", "01962f9a-f7f8-7c3d-8e4f-6a7b8c9d0123" },
                    { "user-014", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "linda.t@email.com", "Linda Thompson", "01962f9a-f7f8-7c3d-8e4f-6a7b8c9d0123" },
                    { "user-015", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "charles.g@email.com", "Charles Garcia", "01962f9a-f7f8-7e5f-9a6b-7c8d9e0f1234" },
                    { "user-016", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "barbara.m@email.com", "Barbara Martinez", "01962f9a-f7f8-7e5f-9a6b-7c8d9e0f1234" },
                    { "user-017", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "thomas.r@email.com", "Thomas Robinson", "01962f9a-f7f8-7f6a-8b7c-9d0e1f234567" },
                    { "user-018", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "susan.c@email.com", "Susan Clark", "01962f9a-f7f8-7f6a-8b7c-9d0e1f234567" },
                    { "user-019", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "christopher.r@email.com", "Christopher Rodriguez", "01962f9a-f7f8-7a7b-9c8d-0e1f23456789" },
                    { "user-020", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "jessica.l@email.com", "Jessica Lewis", "01962f9a-f7f8-7a7b-9c8d-0e1f23456789" },
                    { "user-021", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "matthew.l@email.com", "Matthew Lee", "01962f9a-f7f8-7b8c-0d9e-1f2345678901" },
                    { "user-022", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "karen.w@email.com", "Karen Walker", "01962f9a-f7f8-7b8c-0d9e-1f2345678901" },
                    { "user-023", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "joshua.h@email.com", "Joshua Hall", "01962f9a-f7f8-7c9d-1e0f-23456789012a" },
                    { "user-024", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "nancy.a@email.com", "Nancy Allen", "01962f9a-f7f8-7c9d-1e0f-23456789012a" },
                    { "user-025", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "andrew.y@email.com", "Andrew Young", "01962f9a-f7f8-7d0e-2f1a-3456789012bc" },
                    { "user-026", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "betty.h@email.com", "Betty Hernandez", "01962f9a-f7f8-7d0e-2f1a-3456789012bc" },
                    { "user-027", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "ryan.k@email.com", "Ryan King", "01962f9a-f7f8-7e1f-3a2b-456789012cde" },
                    { "user-028", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "helen.w@email.com", "Helen Wright", "01962f9a-f7f8-7e1f-3a2b-456789012cde" },
                    { "user-029", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "kevin.l@email.com", "Kevin Lopez", "01962f9a-f7f8-7f2a-4b3c-56789012def0" },
                    { "user-030", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "dorothy.h@email.com", "Dorothy Hill", "01962f9a-f7f8-7f2a-4b3c-56789012def0" },
                    { "user-031", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "brian.s@email.com", "Brian Scott", "01962f9a-f7f8-7a3b-5c4d-6789012ef012" },
                    { "user-032", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "sandra.g@email.com", "Sandra Green", "01962f9a-f7f8-7a3b-5c4d-6789012ef012" },
                    { "user-033", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "george.a@email.com", "George Adams", "01962f9a-f7f8-7b4c-6d5e-789012f01234" },
                    { "user-034", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "ashley.b@email.com", "Ashley Baker", "01962f9a-f7f8-7b4c-6d5e-789012f01234" },
                    { "user-035", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "kenneth.g@email.com", "Kenneth Gonzalez", "01962f9a-f7f8-7c5d-7e6f-89012f012345" },
                    { "user-036", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "kimberly.n@email.com", "Kimberly Nelson", "01962f9a-f7f8-7c5d-7e6f-89012f012345" },
                    { "user-037", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "steven.c@email.com", "Steven Carter", "01962f9a-f7f8-7d6e-8f7a-9012f0123456" },
                    { "user-038", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "donna.m@email.com", "Donna Mitchell", "01962f9a-f7f8-7d6e-8f7a-9012f0123456" },
                    { "user-039", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "edward.p@email.com", "Edward Perez", "01962f9a-f7f8-7e7f-9a8b-012f01234567" },
                    { "user-040", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "carol.r@email.com", "Carol Roberts", "01962f9a-f7f8-7e7f-9a8b-012f01234567" },
                    { "user-041", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "jason.t@email.com", "Jason Turner", "01962f9a-f7f8-7f8a-0b9c-12f012345678" },
                    { "user-042", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "michelle.p@email.com", "Michelle Phillips", "01962f9a-f7f8-7f8a-0b9c-12f012345678" },
                    { "user-043", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "jeffrey.c@email.com", "Jeffrey Campbell", "01962f9a-f7f8-7a9b-1c0d-2f01234567ab" },
                    { "user-044", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "sarah.p@email.com", "Sarah Parker", "01962f9a-f7f8-7a9b-1c0d-2f01234567ab" },
                    { "user-045", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "timothy.e@email.com", "Timothy Evans", "01962f9a-f7f8-7b0c-2d1e-f01234567abc" },
                    { "user-046", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "laura.e@email.com", "Laura Edwards", "01962f9a-f7f8-7b0c-2d1e-f01234567abc" },
                    { "user-047", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "gary.c@email.com", "Gary Collins", "01962f9a-f7f8-7c1d-3e2f-01234567abcd" },
                    { "user-048", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "rebecca.s@email.com", "Rebecca Stewart", "01962f9a-f7f8-7c1d-3e2f-01234567abcd" },
                    { "user-049", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "jeffrey.s@email.com", "Jeffrey Sanchez", "01962f9a-f7f8-7d2e-4f3a-1234567abcde" },
                    { "user-050", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "deborah.m@email.com", "Deborah Morris", "01962f9a-f7f8-7d2e-4f3a-1234567abcde" },
                    { "user-051", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "eric.r@email.com", "Eric Rogers", "01962f9a-f7f8-7e3f-5a4b-234567abcdef" },
                    { "user-052", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "stephanie.r@email.com", "Stephanie Reed", "01962f9a-f7f8-7e3f-5a4b-234567abcdef" },
                    { "user-053", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "stephen.c@email.com", "Stephen Cook", "01962f9a-f7f8-7f4a-6b5c-34567abcdef0" },
                    { "user-054", new DateTime(2026, 1, 28, 0, 0, 0, 0, DateTimeKind.Utc), "sharon.m@email.com", "Sharon Morgan", "01962f9a-f7f8-7f4a-6b5c-34567abcdef0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-001");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-002");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-003");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-004");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-005");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-006");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-007");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-008");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-009");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-010");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-011");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-012");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-013");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-014");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-015");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-016");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-017");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-018");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-019");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-020");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-021");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-022");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-023");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-024");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-025");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-026");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-027");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-028");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-029");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-030");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-031");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-032");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-033");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-034");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-035");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-036");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-037");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-038");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-039");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-040");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-041");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-042");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-043");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-044");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-045");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-046");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-047");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-048");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-049");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-050");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-051");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-052");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-053");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user-054");
        }
    }
}
