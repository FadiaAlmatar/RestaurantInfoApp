using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantInfo.EntityFrameWork.Migrations
{
    public partial class seconddddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealOrders_Orders_OrderId",
                table: "MealOrders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "MealOrders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrders_Orders_OrderId",
                table: "MealOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealOrders_Orders_OrderId",
                table: "MealOrders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "MealOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrders_Orders_OrderId",
                table: "MealOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
