using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DistributedSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataActionInFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: "c2195e73-ce36-489f-a628-419c252bbcb6");

            migrationBuilder.InsertData(
                table: "ActionInFunctions",
                columns: new[] { "ActionId", "FunctionId" },
                values: new object[,]
                {
                    { "3e700c49-37ee-4baa-8384-b1fe9f95f822", "1156b66d-ef2f-471e-9e37-44dfb2aea415" },
                    { "51e900fa-9445-486f-bd27-47bb1684673d", "8344a326-5e0f-4389-a251-832aae182286" },
                    { "8892ffdc-c7af-49cd-af76-d221c6642799", "e4bb65d0-3ff6-4182-af22-33a91e844af9" },
                    { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c" },
                    { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActionInFunctions",
                keyColumns: new[] { "ActionId", "FunctionId" },
                keyValues: new object[] { "3e700c49-37ee-4baa-8384-b1fe9f95f822", "1156b66d-ef2f-471e-9e37-44dfb2aea415" });

            migrationBuilder.DeleteData(
                table: "ActionInFunctions",
                keyColumns: new[] { "ActionId", "FunctionId" },
                keyValues: new object[] { "51e900fa-9445-486f-bd27-47bb1684673d", "8344a326-5e0f-4389-a251-832aae182286" });

            migrationBuilder.DeleteData(
                table: "ActionInFunctions",
                keyColumns: new[] { "ActionId", "FunctionId" },
                keyValues: new object[] { "8892ffdc-c7af-49cd-af76-d221c6642799", "e4bb65d0-3ff6-4182-af22-33a91e844af9" });

            migrationBuilder.DeleteData(
                table: "ActionInFunctions",
                keyColumns: new[] { "ActionId", "FunctionId" },
                keyValues: new object[] { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c" });

            migrationBuilder.DeleteData(
                table: "ActionInFunctions",
                keyColumns: new[] { "ActionId", "FunctionId" },
                keyValues: new object[] { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc" });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "IsActive", "Name", "SortOrder" },
                values: new object[] { "c2195e73-ce36-489f-a628-419c252bbcb6", true, "POST", 1 });
        }
    }
}
