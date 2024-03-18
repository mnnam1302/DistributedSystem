using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DistributedSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "9c955674-7377-4b52-b5f4-82eab10fe6ed",
                column: "Name",
                value: "GET");

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "c2195e73-ce36-489f-a628-419c252bbcb6",
                columns: new[] { "Name", "SortOrder" },
                values: new object[] { "POST", 1 });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "IsActive", "Name", "SortOrder" },
                values: new object[,]
                {
                    { "3e700c49-37ee-4baa-8384-b1fe9f95f822", true, "POST", 1 },
                    { "51e900fa-9445-486f-bd27-47bb1684673d", true, "PUT", 1 },
                    { "8892ffdc-c7af-49cd-af76-d221c6642799", true, "DELETE", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "3e700c49-37ee-4baa-8384-b1fe9f95f822");

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "51e900fa-9445-486f-bd27-47bb1684673d");

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "8892ffdc-c7af-49cd-af76-d221c6642799");

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "9c955674-7377-4b52-b5f4-82eab10fe6ed",
                column: "Name",
                value: "Allowed");

            migrationBuilder.UpdateData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "c2195e73-ce36-489f-a628-419c252bbcb6",
                columns: new[] { "Name", "SortOrder" },
                values: new object[] { "Disallowed", 2 });
        }
    }
}
