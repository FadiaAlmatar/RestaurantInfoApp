using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantInfo.EntityFrameWork.Migrations
{
    public partial class inittttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentMeals_Components_ComponentId",
                table: "ComponentMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentMeals_Meals_MealId",
                table: "ComponentMeals");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "ComponentMeals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComponentId",
                table: "ComponentMeals",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentMeals_Components_ComponentId",
                table: "ComponentMeals",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentMeals_Meals_MealId",
                table: "ComponentMeals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentMeals_Components_ComponentId",
                table: "ComponentMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_ComponentMeals_Meals_MealId",
                table: "ComponentMeals");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "ComponentMeals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ComponentId",
                table: "ComponentMeals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentMeals_Components_ComponentId",
                table: "ComponentMeals",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentMeals_Meals_MealId",
                table: "ComponentMeals",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
