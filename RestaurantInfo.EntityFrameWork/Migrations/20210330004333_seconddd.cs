using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantInfo.EntityFrameWork.Migrations
{
    public partial class seconddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentMeals_Components_ComponentId",
                table: "ComponentMeals");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropIndex(
                name: "IX_ComponentMeals_ComponentId",
                table: "ComponentMeals");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "ComponentMeals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "ComponentMeals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComponentMeals_ComponentId",
                table: "ComponentMeals",
                column: "ComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentMeals_Components_ComponentId",
                table: "ComponentMeals",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
