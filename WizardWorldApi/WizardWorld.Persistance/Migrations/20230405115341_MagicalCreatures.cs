using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WizardWorld.Persistance.Migrations
{
    public partial class MagicalCreatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MagicalCreatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Classification = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DangerousnessLevel = table.Column<int>(type: "integer", nullable: false),
                    NativeTo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MagicalCreatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreatureRelation",
                columns: table => new
                {
                    CreatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    RelatedCreatureId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatureRelation", x => new { x.CreatureId, x.RelatedCreatureId });
                    table.ForeignKey(
                        name: "FK_CreatureRelation_MagicalCreatures_CreatureId",
                        column: x => x.CreatureId,
                        principalTable: "MagicalCreatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreatureRelation");

            migrationBuilder.DropTable(
                name: "MagicalCreatures");
        }
    }
}
