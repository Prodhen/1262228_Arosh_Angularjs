using Microsoft.EntityFrameworkCore.Migrations;

namespace _1262228_Arosh_NGJs.Migrations
{
    public partial class InitialCreatebyArosh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicResults",
                columns: table => new
                {
                    AcademicResultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollNo = table.Column<string>(nullable: true),
                    Examination = table.Column<string>(nullable: true),
                    Result = table.Column<decimal>(nullable: false),
                    Group = table.Column<string>(nullable: true),
                    PassingYear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicResults", x => x.AcademicResultID);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(nullable: false),
                    Transaction = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentID);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bangla = table.Column<int>(nullable: true),
                    English = table.Column<int>(nullable: true),
                    GeneralKnowlede = table.Column<int>(nullable: true),
                    Ict = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultID);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(nullable: true),
                    Seat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    UnitID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Units_UnitID",
                        column: x => x.UnitID,
                        principalTable: "Units",
                        principalColumn: "UnitID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UnitID",
                table: "Students",
                column: "UnitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicResults");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
