using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsiApp.Migrations
{
    public partial class Achievement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Achievements",
                table: "Pets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PetXp",
                table: "Pets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Achievements",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "PetXp",
                table: "Pets");
        }
    }
}
