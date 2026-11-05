using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Service3Api.Migrations
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
                table: "Provinces",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    new Guid("01962f9a-f7f8-7a2c-8b3d-4c5e6f789012"),
                    new Guid("01962f9a-f7f8-7a3b-5c4d-6789012ef012"),
                    new Guid("01962f9a-f7f8-7a7b-9c8d-0e1f23456789"),
                    new Guid("01962f9a-f7f8-7a9b-1c0d-2f01234567ab"),
                    new Guid("01962f9a-f7f8-7b0c-2d1e-f01234567abc"),
                    new Guid("01962f9a-f7f8-7b4c-6d5e-789012f01234"),
                    new Guid("01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7"),
                    new Guid("01962f9a-f7f8-7b8c-0d9e-1f2345678901"),
                    new Guid("01962f9a-f7f8-7c1d-3e2f-01234567abcd"),
                    new Guid("01962f9a-f7f8-7c3d-8e4f-6a7b8c9d0123"),
                    new Guid("01962f9a-f7f8-7c5d-7e6f-89012f012345"),
                    new Guid("01962f9a-f7f8-7c9d-1e0f-23456789012a"),
                    new Guid("01962f9a-f7f8-7d0e-2f1a-3456789012bc"),
                    new Guid("01962f9a-f7f8-7d1b-9c2a-5d6e7f890123"),
                    new Guid("01962f9a-f7f8-7d2e-4f3a-1234567abcde"),
                    new Guid("01962f9a-f7f8-7d6e-8f7a-9012f0123456"),
                    new Guid("01962f9a-f7f8-7e1f-3a2b-456789012cde"),
                    new Guid("01962f9a-f7f8-7e3f-5a4b-234567abcdef"),
                    new Guid("01962f9a-f7f8-7e54-a79d-575a8e882eb8"),
                    new Guid("01962f9a-f7f8-7e5f-9a6b-7c8d9e0f1234"),
                    new Guid("01962f9a-f7f8-7e7f-9a8b-012f01234567"),
                    new Guid("01962f9a-f7f8-7f2a-4b3c-56789012def0"),
                    new Guid("01962f9a-f7f8-7f4a-6b5c-34567abcdef0"),
                    new Guid("01962f9a-f7f8-7f61-941c-6a086fe96cd2"),
                    new Guid("01962f9a-f7f8-7f6a-8b7c-9d0e1f234567"),
                    new Guid("01962f9a-f7f8-7f8a-0b9c-12f012345678")
                });

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValues: new object[]
                {
                    "AU",
                    "CA",
                    "DE",
                    "FR",
                    "JP",
                    "UK",
                    "US",
                    "VN"
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "AU", "Australia" },
                    { "CA", "Canada" },
                    { "DE", "Germany" },
                    { "FR", "France" },
                    { "JP", "Japan" },
                    { "UK", "United Kingdom" },
                    { "US", "United States" },
                    { "VN", "Vietnam" }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("01962f9a-f7f8-7a2c-8b3d-4c5e6f789012"), "US", "Florida" },
                    { new Guid("01962f9a-f7f8-7a3b-5c4d-6789012ef012"), "DE", "Bavaria" },
                    { new Guid("01962f9a-f7f8-7a7b-9c8d-0e1f23456789"), "UK", "England" },
                    { new Guid("01962f9a-f7f8-7a9b-1c0d-2f01234567ab"), "JP", "Tokyo" },
                    { new Guid("01962f9a-f7f8-7b0c-2d1e-f01234567abc"), "JP", "Osaka" },
                    { new Guid("01962f9a-f7f8-7b4c-6d5e-789012f01234"), "DE", "North Rhine-Westphalia" },
                    { new Guid("01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7"), "US", "New York" },
                    { new Guid("01962f9a-f7f8-7b8c-0d9e-1f2345678901"), "UK", "Scotland" },
                    { new Guid("01962f9a-f7f8-7c1d-3e2f-01234567abcd"), "JP", "Hokkaido" },
                    { new Guid("01962f9a-f7f8-7c3d-8e4f-6a7b8c9d0123"), "CA", "Ontario" },
                    { new Guid("01962f9a-f7f8-7c5d-7e6f-89012f012345"), "DE", "Baden-Württemberg" },
                    { new Guid("01962f9a-f7f8-7c9d-1e0f-23456789012a"), "UK", "Wales" },
                    { new Guid("01962f9a-f7f8-7d0e-2f1a-3456789012bc"), "AU", "New South Wales" },
                    { new Guid("01962f9a-f7f8-7d1b-9c2a-5d6e7f890123"), "US", "Illinois" },
                    { new Guid("01962f9a-f7f8-7d2e-4f3a-1234567abcde"), "VN", "Ho Chi Minh City" },
                    { new Guid("01962f9a-f7f8-7d6e-8f7a-9012f0123456"), "FR", "Île-de-France" },
                    { new Guid("01962f9a-f7f8-7e1f-3a2b-456789012cde"), "AU", "Victoria" },
                    { new Guid("01962f9a-f7f8-7e3f-5a4b-234567abcdef"), "VN", "Hanoi" },
                    { new Guid("01962f9a-f7f8-7e54-a79d-575a8e882eb8"), "US", "Texas" },
                    { new Guid("01962f9a-f7f8-7e5f-9a6b-7c8d9e0f1234"), "CA", "Quebec" },
                    { new Guid("01962f9a-f7f8-7e7f-9a8b-012f01234567"), "FR", "Provence-Alpes-Côte d'Azur" },
                    { new Guid("01962f9a-f7f8-7f2a-4b3c-56789012def0"), "AU", "Queensland" },
                    { new Guid("01962f9a-f7f8-7f4a-6b5c-34567abcdef0"), "VN", "Da Nang" },
                    { new Guid("01962f9a-f7f8-7f61-941c-6a086fe96cd2"), "US", "California" },
                    { new Guid("01962f9a-f7f8-7f6a-8b7c-9d0e1f234567"), "CA", "British Columbia" },
                    { new Guid("01962f9a-f7f8-7f8a-0b9c-12f012345678"), "FR", "Nouvelle-Aquitaine" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7a2c-8b3d-4c5e6f789012"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7a3b-5c4d-6789012ef012"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7a7b-9c8d-0e1f23456789"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7a9b-1c0d-2f01234567ab"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7b0c-2d1e-f01234567abc"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7b4c-6d5e-789012f01234"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7b4c-9b4d-eae8ea6e5fc7"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7b8c-0d9e-1f2345678901"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7c1d-3e2f-01234567abcd"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7c3d-8e4f-6a7b8c9d0123"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7c5d-7e6f-89012f012345"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7c9d-1e0f-23456789012a"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7d0e-2f1a-3456789012bc"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7d1b-9c2a-5d6e7f890123"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7d2e-4f3a-1234567abcde"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7d6e-8f7a-9012f0123456"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7e1f-3a2b-456789012cde"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7e3f-5a4b-234567abcdef"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7e54-a79d-575a8e882eb8"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7e5f-9a6b-7c8d9e0f1234"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7e7f-9a8b-012f01234567"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7f2a-4b3c-56789012def0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7f4a-6b5c-34567abcdef0"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7f61-941c-6a086fe96cd2"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7f6a-8b7c-9d0e1f234567"));

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: new Guid("01962f9a-f7f8-7f8a-0b9c-12f012345678"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "AU");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "CA");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "DE");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "FR");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "JP");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "UK");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "US");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "VN");
        }
    }
}
