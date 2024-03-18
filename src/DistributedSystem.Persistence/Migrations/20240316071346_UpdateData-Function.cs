using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DistributedSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "1156b66d-ef2f-471e-9e37-44dfb2aea415",
                column: "Name",
                value: "Create a new product");

            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c",
                column: "Name",
                value: "Retrieve all products");

            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc",
                columns: new[] { "Name", "Url" },
                values: new object[] { "Retrieve the details for product 1", "http://localhost:5000/api/v1/products/1" });

            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "8344a326-5e0f-4389-a251-832aae182286",
                columns: new[] { "Name", "Url" },
                values: new object[] { "Update the details of product 1 if it exists", "http://localhost:5000/api/v1/products/1" });

            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "e4bb65d0-3ff6-4182-af22-33a91e844af9",
                columns: new[] { "Name", "Url" },
                values: new object[] { "Remove product 1", "http://localhost:5000/api/v1/products/1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "1156b66d-ef2f-471e-9e37-44dfb2aea415",
                column: "Name",
                value: "CreateProductsV1");

            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "1b8c6511-d1db-4c01-b65a-1c60ec0bf90c",
                column: "Name",
                value: "GetProductsV1");

            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "401b7a1d-6489-4b0e-9dc7-a27277d6e3dc",
                columns: new[] { "Name", "Url" },
                values: new object[] { "GetProductsByIdV1", "http://localhost:5000/api/v1/products/{productId}" });

            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "8344a326-5e0f-4389-a251-832aae182286",
                columns: new[] { "Name", "Url" },
                values: new object[] { "UpdateProductsV1", "http://localhost:5000/api/v1/products/{productId}" });

            migrationBuilder.UpdateData(
                table: "Functions",
                keyColumn: "Id",
                keyValue: "e4bb65d0-3ff6-4182-af22-33a91e844af9",
                columns: new[] { "Name", "Url" },
                values: new object[] { "DeleteProductsV1", "http://localhost:5000/api/v1/products/{productId}" });
        }
    }
}
