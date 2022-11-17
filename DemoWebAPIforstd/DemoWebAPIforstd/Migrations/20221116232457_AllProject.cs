using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebAPIforstd.Migrations
{
    public partial class AllProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "enrolls",
                columns: table => new
                {
                    enid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subjectid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrolls", x => x.enid);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stuname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stulastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stuaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stuphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stuimg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GPA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrolls");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "subjects");
        }
    }
}
