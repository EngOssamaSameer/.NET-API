using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIedu.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCourses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbCourseStudentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    StudentInfo_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCourseStudentInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbStudentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbStudentInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Course_Id = table.Column<int>(type: "int", nullable: false),
                    Contant = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbLessons_TbCourses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "TbCourses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseStudentInfo",
                columns: table => new
                {
                    TbCoursesId = table.Column<int>(type: "int", nullable: false),
                    TbStudentInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudentInfo", x => new { x.TbCoursesId, x.TbStudentInfoId });
                    table.ForeignKey(
                        name: "FK_CourseStudentInfo_TbCourses_TbCoursesId",
                        column: x => x.TbCoursesId,
                        principalTable: "TbCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudentInfo_TbStudentInfo_TbStudentInfoId",
                        column: x => x.TbStudentInfoId,
                        principalTable: "TbStudentInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudentInfo_TbStudentInfoId",
                table: "CourseStudentInfo",
                column: "TbStudentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_TbLessons_CourseId",
                table: "TbLessons",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudentInfo");

            migrationBuilder.DropTable(
                name: "TbCourseStudentInfo");

            migrationBuilder.DropTable(
                name: "TbLessons");

            migrationBuilder.DropTable(
                name: "TbStudentInfo");

            migrationBuilder.DropTable(
                name: "TbCourses");
        }
    }
}
