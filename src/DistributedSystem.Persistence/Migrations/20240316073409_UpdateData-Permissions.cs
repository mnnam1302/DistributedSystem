using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DistributedSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumns: new[] { "ActionId", "FunctionId", "RoleId" },
                keyValues: new object[] { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "1156b66d-ef2f-471e-9e37-44dfb2aea415", new Guid("424c4755-379e-440c-b67e-d53a4d615113") });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumns: new[] { "ActionId", "FunctionId", "RoleId" },
                keyValues: new object[] { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "8344a326-5e0f-4389-a251-832aae182286", new Guid("424c4755-379e-440c-b67e-d53a4d615113") });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumns: new[] { "ActionId", "FunctionId", "RoleId" },
                keyValues: new object[] { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "e4bb65d0-3ff6-4182-af22-33a91e844af9", new Guid("424c4755-379e-440c-b67e-d53a4d615113") });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "ActionId", "FunctionId", "RoleId" },
                values: new object[,]
                {
                    { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c", new Guid("0d395fbd-3271-44a2-b147-4b77be0464e6") },
                    { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc", new Guid("0d395fbd-3271-44a2-b147-4b77be0464e6") },
                    { "3e700c49-37ee-4baa-8384-b1fe9f95f822", "1156b66d-ef2f-471e-9e37-44dfb2aea415", new Guid("424c4755-379e-440c-b67e-d53a4d615113") },
                    { "51e900fa-9445-486f-bd27-47bb1684673d", "8344a326-5e0f-4389-a251-832aae182286", new Guid("424c4755-379e-440c-b67e-d53a4d615113") },
                    { "8892ffdc-c7af-49cd-af76-d221c6642799", "e4bb65d0-3ff6-4182-af22-33a91e844af9", new Guid("424c4755-379e-440c-b67e-d53a4d615113") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumns: new[] { "ActionId", "FunctionId", "RoleId" },
                keyValues: new object[] { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c", new Guid("0d395fbd-3271-44a2-b147-4b77be0464e6") });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumns: new[] { "ActionId", "FunctionId", "RoleId" },
                keyValues: new object[] { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc", new Guid("0d395fbd-3271-44a2-b147-4b77be0464e6") });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumns: new[] { "ActionId", "FunctionId", "RoleId" },
                keyValues: new object[] { "3e700c49-37ee-4baa-8384-b1fe9f95f822", "1156b66d-ef2f-471e-9e37-44dfb2aea415", new Guid("424c4755-379e-440c-b67e-d53a4d615113") });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumns: new[] { "ActionId", "FunctionId", "RoleId" },
                keyValues: new object[] { "51e900fa-9445-486f-bd27-47bb1684673d", "8344a326-5e0f-4389-a251-832aae182286", new Guid("424c4755-379e-440c-b67e-d53a4d615113") });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumns: new[] { "ActionId", "FunctionId", "RoleId" },
                keyValues: new object[] { "8892ffdc-c7af-49cd-af76-d221c6642799", "e4bb65d0-3ff6-4182-af22-33a91e844af9", new Guid("424c4755-379e-440c-b67e-d53a4d615113") });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "ActionId", "FunctionId", "RoleId" },
                values: new object[,]
                {
                    { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "1156b66d-ef2f-471e-9e37-44dfb2aea415", new Guid("424c4755-379e-440c-b67e-d53a4d615113") },
                    { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "8344a326-5e0f-4389-a251-832aae182286", new Guid("424c4755-379e-440c-b67e-d53a4d615113") },
                    { "9c955674-7377-4b52-b5f4-82eab10fe6ed", "e4bb65d0-3ff6-4182-af22-33a91e844af9", new Guid("424c4755-379e-440c-b67e-d53a4d615113") }
                });
        }
    }
}
