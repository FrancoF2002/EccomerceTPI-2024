using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserOrderRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientUserId",
                table: "Order",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientUserId",
                table: "Order",
                column: "ClientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_ClientUserId",
                table: "Order",
                column: "ClientUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_ClientUserId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ClientUserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ClientUserId",
                table: "Order");
        }
    }
}
