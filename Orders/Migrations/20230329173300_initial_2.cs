using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Migrations
{
    /// <inheritdoc />
    public partial class initial_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrdersProducts_OrderProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_OrdersProducts_OrderProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_OrderId",
                table: "OrdersProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductId",
                table: "OrdersProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Orders_OrderId",
                table: "OrdersProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Products_ProductId",
                table: "OrdersProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Orders_OrderId",
                table: "OrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Products_ProductId",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrdersProducts_OrderId",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrdersProducts_ProductId",
                table: "OrdersProducts");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderProductId",
                table: "Products",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderProductId",
                table: "Orders",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrdersProducts_OrderProductId",
                table: "Orders",
                column: "OrderProductId",
                principalTable: "OrdersProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OrdersProducts_OrderProductId",
                table: "Products",
                column: "OrderProductId",
                principalTable: "OrdersProducts",
                principalColumn: "Id");
        }
    }
}
