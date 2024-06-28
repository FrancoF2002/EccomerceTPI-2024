using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Idmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductProdId",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "ProdId",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductProdId",
                table: "OrderProduct",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductProdId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                table: "OrderProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                table: "OrderProduct");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProdId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderProduct",
                newName: "ProductProdId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                newName: "IX_OrderProduct_ProductProdId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductProdId",
                table: "OrderProduct",
                column: "ProductProdId",
                principalTable: "Products",
                principalColumn: "ProdId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
