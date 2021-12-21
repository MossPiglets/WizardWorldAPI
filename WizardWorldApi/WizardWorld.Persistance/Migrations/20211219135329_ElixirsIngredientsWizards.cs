using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WizardWorld.Persistance.Migrations
{
    public partial class ElixirsIngredientsWizards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Elixirs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Effect = table.Column<string>(type: "text", nullable: true),
                    SideEffects = table.Column<string>(type: "text", nullable: true),
                    Characteristics = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    Manufacturer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elixirs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    HouseColours = table.Column<string>(type: "text", nullable: true),
                    Founder = table.Column<string>(type: "text", nullable: true),
                    Animal = table.Column<string>(type: "text", nullable: true),
                    Element = table.Column<string>(type: "text", nullable: true),
                    Ghost = table.Column<string>(type: "text", nullable: true),
                    CommonRoom = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wizards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseHead",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    HouseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseHead", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseHead_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trait",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<int>(type: "integer", nullable: false),
                    HouseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trait", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trait_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElixirsIngredients",
                columns: table => new
                {
                    ElixirsId = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElixirsIngredients", x => new { x.ElixirsId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_ElixirsIngredients_Elixirs_ElixirsId",
                        column: x => x.ElixirsId,
                        principalTable: "Elixirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElixirsIngredients_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WizardsElixirs",
                columns: table => new
                {
                    ElixirsId = table.Column<Guid>(type: "uuid", nullable: false),
                    InventorsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WizardsElixirs", x => new { x.ElixirsId, x.InventorsId });
                    table.ForeignKey(
                        name: "FK_WizardsElixirs_Elixirs_ElixirsId",
                        column: x => x.ElixirsId,
                        principalTable: "Elixirs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WizardsElixirs_Wizards_InventorsId",
                        column: x => x.InventorsId,
                        principalTable: "Wizards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElixirsIngredients_IngredientsId",
                table: "ElixirsIngredients",
                column: "IngredientsId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseHead_HouseId",
                table: "HouseHead",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Trait_HouseId",
                table: "Trait",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WizardsElixirs_InventorsId",
                table: "WizardsElixirs",
                column: "InventorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElixirsIngredients");

            migrationBuilder.DropTable(
                name: "HouseHead");

            migrationBuilder.DropTable(
                name: "Trait");

            migrationBuilder.DropTable(
                name: "WizardsElixirs");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Elixirs");

            migrationBuilder.DropTable(
                name: "Wizards");
        }
    }
}
