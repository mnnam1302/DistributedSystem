using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DistributedSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataUpdateAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "ACT001");

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "ACT002");

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "IsActive", "Name", "SortOrder" },
                values: new object[,]
                {
                    { "9c955674-7377-4b52-b5f4-82eab10fe6ed", true, "Allowed", 1 },
                    { "c2195e73-ce36-489f-a628-419c252bbcb6", true, "Disallowed", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "9c955674-7377-4b52-b5f4-82eab10fe6ed");

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "c2195e73-ce36-489f-a628-419c252bbcb6");

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "IsActive", "Name", "SortOrder" },
                values: new object[,]
                {
                    { "ACT001", true, "Allowed", 1 },
                    { "ACT002", true, "Disallowed", 2 }
                });
        }
    }
}
