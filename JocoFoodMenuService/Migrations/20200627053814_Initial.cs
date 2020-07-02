using Microsoft.EntityFrameworkCore.Migrations;

namespace JocoFoodMenuService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuCreator",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCreator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Beverage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MenuCreatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beverage_MenuCreator_MenuCreatorId",
                        column: x => x.MenuCreatorId,
                        principalTable: "MenuCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Complement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MenuCreatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Complement_MenuCreator_MenuCreatorId",
                        column: x => x.MenuCreatorId,
                        principalTable: "MenuCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grain",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MenuCreatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grain_MenuCreator_MenuCreatorId",
                        column: x => x.MenuCreatorId,
                        principalTable: "MenuCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MenuCreatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meat_MenuCreator_MenuCreatorId",
                        column: x => x.MenuCreatorId,
                        principalTable: "MenuCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MenuCreatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rice_MenuCreator_MenuCreatorId",
                        column: x => x.MenuCreatorId,
                        principalTable: "MenuCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beverage_MenuCreatorId",
                table: "Beverage",
                column: "MenuCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Complement_MenuCreatorId",
                table: "Complement",
                column: "MenuCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Grain_MenuCreatorId",
                table: "Grain",
                column: "MenuCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Meat_MenuCreatorId",
                table: "Meat",
                column: "MenuCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rice_MenuCreatorId",
                table: "Rice",
                column: "MenuCreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beverage");

            migrationBuilder.DropTable(
                name: "Complement");

            migrationBuilder.DropTable(
                name: "Grain");

            migrationBuilder.DropTable(
                name: "Meat");

            migrationBuilder.DropTable(
                name: "Rice");

            migrationBuilder.DropTable(
                name: "MenuCreator");
        }
    }
}
