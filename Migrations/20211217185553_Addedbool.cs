using Microsoft.EntityFrameworkCore.Migrations;

namespace _1262228_Arosh_NGJs.Migrations
{
    public partial class Addedbool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Students");
        }
    }
}
