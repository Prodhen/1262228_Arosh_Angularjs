using Microsoft.EntityFrameworkCore.Migrations;

namespace _1262228_Arosh_NGJs.Migrations
{
    public partial class stringfdecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Result",
                table: "AcademicResults",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Result",
                table: "AcademicResults",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
