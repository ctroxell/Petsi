using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsiApp.Migrations
{
    public partial class MigratingParentUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChildUserId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChildUserId",
                table: "AspNetUsers");
        }
    }
}
