using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Service1.OtherContextMigrations
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
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    "addr-001",
                    "addr-002",
                    "addr-003",
                    "addr-004",
                    "addr-005",
                    "addr-006",
                    "addr-007",
                    "addr-008",
                    "addr-009",
                    "addr-010",
                    "addr-011",
                    "addr-012",
                    "addr-013",
                    "addr-014",
                    "addr-015",
                    "addr-016",
                    "addr-017",
                    "addr-018",
                    "addr-019",
                    "addr-020",
                    "addr-021",
                    "addr-022",
                    "addr-023",
                    "addr-024",
                    "addr-025",
                    "addr-026",
                    "addr-027",
                    "addr-028",
                    "addr-029",
                    "addr-030",
                    "addr-031",
                    "addr-032",
                    "addr-033",
                    "addr-034",
                    "addr-035"
                });

            migrationBuilder.InsertData(
                table: "MemberAddresses",
                columns: new[] { "Id", "City", "ProvinceId", "Street", "ZipCode" },
                values: new object[,]
                {
                    { "addr-001", "San Francisco", "01962f9a-f7f8-7f61-941c-6a086fe96cd2", "123 Silicon Valley Blvd", "94102" },
                    { "addr-002", "Los Angeles", "01962f9a-f7f8-7f61-941c-6a086fe96cd2", "456 Hollywood Dr", "90028" },
                    { "addr-003", "San Diego", "01962f9a-f7f8-7f61-941c-6a086fe96cd2", "789 Beach Ave", "92101" },
                    { "addr-004", "Palo Alto", "01962f9a-f7f8-7f61-941c-6a086fe96cd2", "321 Tech Park Way", "94301" },
                    { "addr-005", "New York", "01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7", "100 Wall Street", "10005" },
                    { "addr-006", "New York", "01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7", "200 Broadway", "10007" },
                    { "addr-007", "New York", "01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7", "300 Park Ave", "10022" },
                    { "addr-008", "New York", "01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7", "400 Madison Ave", "10017" },
                    { "addr-009", "Houston", "01962f9a-f7f8-7e54-a79d-575a8e882eb8", "500 Main St", "77002" },
                    { "addr-010", "Austin", "01962f9a-f7f8-7e54-a79d-575a8e882eb8", "600 Congress Ave", "78701" },
                    { "addr-011", "Dallas", "01962f9a-f7f8-7e54-a79d-575a8e882eb8", "700 Dallas Parkway", "75201" },
                    { "addr-012", "Miami", "01962f9a-f7f8-7a2c-8b3d-4c5e6f789012", "800 Ocean Drive", "33139" },
                    { "addr-013", "Orlando", "01962f9a-f7f8-7a2c-8b3d-4c5e6f789012", "900 Orange Ave", "32801" },
                    { "addr-014", "Chicago", "01962f9a-f7f8-7d1b-9c2a-5d6e7f890123", "1000 Michigan Ave", "60601" },
                    { "addr-015", "Chicago", "01962f9a-f7f8-7d1b-9c2a-5d6e7f890123", "1100 State St", "60605" },
                    { "addr-016", "Toronto", "01962f9a-f7f8-7c3d-8e4f-6a7b8c9d0123", "1200 Bay St", "M5J 2R8" },
                    { "addr-017", "Toronto", "01962f9a-f7f8-7c3d-8e4f-6a7b8c9d0123", "1300 Yonge St", "M4T 1W6" },
                    { "addr-018", "Montreal", "01962f9a-f7f8-7e5f-9a6b-7c8d9e0f1234", "1400 Rue Saint-Denis", "H2X 3K2" },
                    { "addr-019", "Quebec City", "01962f9a-f7f8-7e5f-9a6b-7c8d9e0f1234", "1500 Grande Allée", "G1R 2J5" },
                    { "addr-020", "Vancouver", "01962f9a-f7f8-7f6a-8b7c-9d0e1f234567", "1600 Robson St", "V6G 1C7" },
                    { "addr-021", "Victoria", "01962f9a-f7f8-7f6a-8b7c-9d0e1f234567", "1700 Government St", "V8W 1Y4" },
                    { "addr-022", "London", "01962f9a-f7f8-7a7b-9c8d-0e1f23456789", "1800 Oxford St", "W1D 1BS" },
                    { "addr-023", "London", "01962f9a-f7f8-7a7b-9c8d-0e1f23456789", "1900 Baker St", "NW1 6XE" },
                    { "addr-024", "Edinburgh", "01962f9a-f7f8-7b8c-0d9e-1f2345678901", "2000 Royal Mile", "EH1 1RE" },
                    { "addr-025", "Glasgow", "01962f9a-f7f8-7b8c-0d9e-1f2345678901", "2100 Buchanan St", "G1 3HL" },
                    { "addr-026", "Cardiff", "01962f9a-f7f8-7c9d-1e0f-23456789012a", "2200 Queen St", "CF10 2BH" },
                    { "addr-027", "Sydney", "01962f9a-f7f8-7d0e-2f1a-3456789012bc", "2300 George St", "2000" },
                    { "addr-028", "Melbourne", "01962f9a-f7f8-7e1f-3a2b-456789012cde", "2400 Collins St", "3000" },
                    { "addr-029", "Brisbane", "01962f9a-f7f8-7f2a-4b3c-56789012def0", "2500 Queen St", "4000" },
                    { "addr-030", "Munich", "01962f9a-f7f8-7a3b-5c4d-6789012ef012", "2600 Marienplatz", "80331" },
                    { "addr-031", "Paris", "01962f9a-f7f8-7d6e-8f7a-9012f0123456", "2700 Champs-Élysées", "75008" },
                    { "addr-032", "Tokyo", "01962f9a-f7f8-7a9b-1c0d-2f01234567ab", "2800 Shibuya", "150-0002" },
                    { "addr-033", "Osaka", "01962f9a-f7f8-7b0c-2d1e-f01234567abc", "2900 Dotonbori", "542-0071" },
                    { "addr-034", "Ho Chi Minh City", "01962f9a-f7f8-7d2e-4f3a-1234567abcde", "3000 Nguyen Hue", "700000" },
                    { "addr-035", "Hanoi", "01962f9a-f7f8-7e3f-5a4b-234567abcdef", "3100 Hoan Kiem", "100000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-001");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-002");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-003");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-004");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-005");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-006");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-007");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-008");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-009");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-010");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-011");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-012");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-013");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-014");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-015");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-016");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-017");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-018");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-019");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-020");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-021");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-022");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-023");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-024");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-025");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-026");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-027");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-028");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-029");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-030");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-031");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-032");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-033");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-034");

            migrationBuilder.DeleteData(
                table: "MemberAddresses",
                keyColumn: "Id",
                keyValue: "addr-035");
        }
    }
}
