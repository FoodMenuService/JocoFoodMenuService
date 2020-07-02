using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JocoFoodMenuService.Migrations
{
    public partial class EditingManuCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuName",
                table: "MenuCreator");

            migrationBuilder.AddColumn<string>(
                name: "MenuDaily",
                table: "MenuCreator",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MenuDate",
                table: "MenuCreator",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuDaily",
                table: "MenuCreator");

            migrationBuilder.DropColumn(
                name: "MenuDate",
                table: "MenuCreator");

            migrationBuilder.AddColumn<string>(
                name: "MenuName",
                table: "MenuCreator",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
