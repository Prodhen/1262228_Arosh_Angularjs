using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1262228_Arosh_NGJs.Migrations
{
    public partial class AddedDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Students");
        }
    }
}
