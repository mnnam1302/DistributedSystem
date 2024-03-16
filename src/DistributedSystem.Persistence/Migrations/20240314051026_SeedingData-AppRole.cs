using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DistributedSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataAppRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName", "RoleCode" },
                values: new object[,]
                {
                    { new Guid("1230900d-7549-40a7-928d-7639b6d4f038"), null, "Administrator role with full access", "Admin", "ADMIN", "ADM" },
                    { new Guid("1ac6baf6-1890-48cc-8c44-16898f3f2457"), null, "Standard user role with limited access", "User", "USER", "USR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1230900d-7549-40a7-928d-7639b6d4f038"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ac6baf6-1890-48cc-8c44-16898f3f2457"));
        }
    }
}
