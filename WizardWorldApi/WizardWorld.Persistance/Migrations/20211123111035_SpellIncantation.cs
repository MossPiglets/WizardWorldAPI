using Microsoft.EntityFrameworkCore.Migrations;

namespace WizardWorld.Persistance.Migrations
{
    public partial class SpellIncantation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Incantation",
                table: "Spells",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Incantation",
                table: "Spells");
        }
    }
}
