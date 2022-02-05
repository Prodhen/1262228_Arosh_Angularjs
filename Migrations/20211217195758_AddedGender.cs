using Microsoft.EntityFrameworkCore.Migrations;

namespace _1262228_Arosh_NGJs.Migrations
{
    public partial class AddedGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Students");
        }
    }
}
