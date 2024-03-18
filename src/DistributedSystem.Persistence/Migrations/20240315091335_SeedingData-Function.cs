using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistributedSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "e4bb65d0-3ff6-4182-af22-33a91e844af9",
                column: "Name",
                value: "DeleteProductsV1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "e4bb65d0-3ff6-4182-af22-33a91e844af9",
                column: "Name",
                value: "ProductsV1");
        }
    }
}
