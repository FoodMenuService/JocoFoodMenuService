using Microsoft.EntityFrameworkCore.Migrations;

namespace JocoFoodMenuService.Migrations
{
    public partial class addingphotoprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Rice",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Meat",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Grain",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Complement",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Beverage",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Rice");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Meat");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Grain");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Complement");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Beverage");
        }
    }
}
