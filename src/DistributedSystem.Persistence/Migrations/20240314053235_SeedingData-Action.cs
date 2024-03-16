using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DistributedSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1230900d-7549-40a7-928d-7639b6d4f038"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ac6baf6-1890-48cc-8c44-16898f3f2457"));

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "IsActive", "Name", "SortOrder" },
                values: new object[,]
                {
                    { "ACT001", true, "Allowed", 1 },
                    { "ACT002", true, "Disallowed", 2 }
                });

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "RoleCode" },
                values: new object[,]
                {
                    { new Guid("0d395fbd-3271-44a2-b147-4b77be0464e6"), null, "Standard user role with limited access", "User", "USER", "USR" },
                    { new Guid("424c4755-379e-440c-b67e-d53a4d615113"), null, "Administrator role with full access", "Admin", "ADMIN", "ADM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "ACT001");

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "ACT002");

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("0d395fbd-3271-44a2-b147-4b77be0464e6"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("424c4755-379e-440c-b67e-d53a4d615113"));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "RoleCode" },
                values: new object[,]
                {
                    { new Guid("1230900d-7549-40a7-928d-7639b6d4f038"), null, "Administrator role with full access", "Admin", "ADMIN", "ADM" },
                    { new Guid("1ac6baf6-1890-48cc-8c44-16898f3f2457"), null, "Standard user role with limited access", "User", "USER", "USR" }
                });
        }
    }
}
