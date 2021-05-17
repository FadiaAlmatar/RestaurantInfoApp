using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantInfo.EntityFrameWork.Migrations
{
    public partial class inittt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealOrders_Meals_MealId",
                table: "MealOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOrders_Orders_OrderId",
                table: "MealOrders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "MealOrders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "MealOrders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrders_Meals_MealId",
                table: "MealOrders",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrders_Orders_OrderId",
                table: "MealOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealOrders_Meals_MealId",
                table: "MealOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_MealOrders_Orders_OrderId",
                table: "MealOrders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "MealOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "MealOrders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrders_Meals_MealId",
                table: "MealOrders",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MealOrders_Orders_OrderId",
                table: "MealOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
