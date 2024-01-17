using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.Migrations
{
    /// <inheritdoc />
    public partial class addStudentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Shared");

            migrationBuilder.EnsureSchema(
                name: "S");

            //migrationBuilder.CreateTable(
            //    name: "CourseStudents",
            //    schema: "Shared",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        StudentId = table.Column<int>(type: "int", nullable: false),
            //        CourseId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CourseStudents", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CourseTeachers",
            //    schema: "Shared",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        TeacherId = table.Column<int>(type: "int", nullable: false),
            //        CourseId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CourseTeachers", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "S",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "CourseStudents",
            //    schema: "Shared");

            //migrationBuilder.DropTable(
            //    name: "CourseTeachers",
            //    schema: "Shared");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "S");
        }
    }
}
