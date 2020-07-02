using Microsoft.EntityFrameworkCore.Migrations;

namespace JocoFoodMenuService.Migrations
{
    public partial class DeletingMenuCreatorPropOnEachClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beverage_MenuCreator_MenuCreatorId",
                table: "Beverage");

            migrationBuilder.DropForeignKey(
                name: "FK_Complement_MenuCreator_MenuCreatorId",
                table: "Complement");

            migrationBuilder.DropForeignKey(
                name: "FK_Grain_MenuCreator_MenuCreatorId",
                table: "Grain");

            migrationBuilder.DropForeignKey(
                name: "FK_Meat_MenuCreator_MenuCreatorId",
                table: "Meat");

            migrationBuilder.DropForeignKey(
                name: "FK_Rice_MenuCreator_MenuCreatorId",
                table: "Rice");

            migrationBuilder.DropIndex(
                name: "IX_Rice_MenuCreatorId",
                table: "Rice");

            migrationBuilder.DropIndex(
                name: "IX_Meat_MenuCreatorId",
                table: "Meat");

            migrationBuilder.DropIndex(
                name: "IX_Grain_MenuCreatorId",
                table: "Grain");

            migrationBuilder.DropIndex(
                name: "IX_Complement_MenuCreatorId",
                table: "Complement");

            migrationBuilder.DropIndex(
                name: "IX_Beverage_MenuCreatorId",
                table: "Beverage");

            migrationBuilder.DropColumn(
                name: "MenuCreatorId",
                table: "Rice");

            migrationBuilder.DropColumn(
                name: "MenuCreatorId",
                table: "Meat");

            migrationBuilder.DropColumn(
                name: "MenuCreatorId",
                table: "Grain");

            migrationBuilder.DropColumn(
                name: "MenuCreatorId",
                table: "Complement");

            migrationBuilder.DropColumn(
                name: "MenuCreatorId",
                table: "Beverage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuCreatorId",
                table: "Rice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuCreatorId",
                table: "Meat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuCreatorId",
                table: "Grain",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuCreatorId",
                table: "Complement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MenuCreatorId",
                table: "Beverage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rice_MenuCreatorId",
                table: "Rice",
                column: "MenuCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Meat_MenuCreatorId",
                table: "Meat",
                column: "MenuCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Grain_MenuCreatorId",
                table: "Grain",
                column: "MenuCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Complement_MenuCreatorId",
                table: "Complement",
                column: "MenuCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Beverage_MenuCreatorId",
                table: "Beverage",
                column: "MenuCreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beverage_MenuCreator_MenuCreatorId",
                table: "Beverage",
                column: "MenuCreatorId",
                principalTable: "MenuCreator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Complement_MenuCreator_MenuCreatorId",
                table: "Complement",
                column: "MenuCreatorId",
                principalTable: "MenuCreator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grain_MenuCreator_MenuCreatorId",
                table: "Grain",
                column: "MenuCreatorId",
                principalTable: "MenuCreator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Meat_MenuCreator_MenuCreatorId",
                table: "Meat",
                column: "MenuCreatorId",
                principalTable: "MenuCreator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rice_MenuCreator_MenuCreatorId",
                table: "Rice",
                column: "MenuCreatorId",
                principalTable: "MenuCreator",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
