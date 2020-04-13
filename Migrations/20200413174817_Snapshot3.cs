using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class Snapshot3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    AuId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.AuId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TAuId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TAuId);
                    table.ForeignKey(
                        name: "FK_Teachers_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    AuId = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: false),
                    Semester = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.AuId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_AuId",
                        column: x => x.AuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentNumber = table.Column<string>(nullable: false),
                    CourseId = table.Column<string>(nullable: true),
                    TAuId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentNumber);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assignments_Teachers_TAuId",
                        column: x => x.TAuId,
                        principalTable: "Teachers",
                        principalColumn: "TAuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    ExerciseNumber = table.Column<int>(nullable: false),
                    Lecture = table.Column<string>(nullable: false),
                    HelpWhere = table.Column<string>(nullable: true),
                    AuId = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true),
                    TAuId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => new { x.Lecture, x.ExerciseNumber });
                    table.ForeignKey(
                        name: "FK_Exercises_Students_AuId",
                        column: x => x.AuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exercises_Teachers_TAuId",
                        column: x => x.TAuId,
                        principalTable: "Teachers",
                        principalColumn: "TAuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    AuId = table.Column<string>(nullable: false),
                    AssignmentNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignment", x => new { x.AuId, x.AssignmentNumber });
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Assignments_AssignmentNumber",
                        column: x => x.AssignmentNumber,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Students_AuId",
                        column: x => x.AuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TAuId",
                table: "Assignments",
                column: "TAuId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_AuId",
                table: "Exercises",
                column: "AuId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_CourseId",
                table: "Exercises",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TAuId",
                table: "Exercises",
                column: "TAuId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_AssignmentNumber",
                table: "StudentAssignment",
                column: "AssignmentNumber");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseId",
                table: "StudentCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseId",
                table: "Teachers",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
