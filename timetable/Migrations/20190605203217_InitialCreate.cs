using Microsoft.EntityFrameworkCore.Migrations;

namespace timetable.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabinets",
                columns: table => new
                {
                    CabinetId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Housing = table.Column<int>(nullable: false),
                    Auditorium = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabinets", x => x.CabinetId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    SemesterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    HalfGroup = table.Column<bool>(nullable: false),
                    Joinable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GroupId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    CabinetId = table.Column<int>(nullable: false),
                    Week = table.Column<string>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    LessonIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                });

            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    SemesterId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpecialtyId = table.Column<int>(nullable: false),
                    SemesterIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.SemesterId);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.SpecialtyId);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "SemesterLessons",
                columns: table => new
                {
                    SemesterLessonId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LessonId = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    SemesterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterLessons", x => x.SemesterLessonId);
                    table.ForeignKey(
                        name: "FK_SemesterLessons_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "SemesterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherLessons",
                columns: table => new
                {
                    TeacherLessonId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherId = table.Column<int>(nullable: false),
                    LessonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherLessons", x => x.TeacherLessonId);
                    table.ForeignKey(
                        name: "FK_TeacherLessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SemesterLessons_SemesterId",
                table: "SemesterLessons",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherLessons_TeacherId",
                table: "TeacherLessons",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cabinets");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "SemesterLessons");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "TeacherLessons");

            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
