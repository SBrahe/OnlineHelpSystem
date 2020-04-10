﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class InitialMigration : Migration
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
                    AssignmentNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HelpWhere = table.Column<string>(nullable: true),
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
                name: "Excercises",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false),
                    Lecture = table.Column<string>(nullable: false),
                    HelpWhere = table.Column<string>(nullable: true),
                    AuId = table.Column<string>(nullable: true),
                    CourseId = table.Column<string>(nullable: true),
                    TAuId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excercises", x => new { x.Lecture, x.Number });
                    table.ForeignKey(
                        name: "FK_Excercises_Students_AuId",
                        column: x => x.AuId,
                        principalTable: "Students",
                        principalColumn: "AuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Excercises_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Excercises_Teachers_TAuId",
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
                    AssignmentNumber = table.Column<int>(nullable: false)
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
                name: "IX_Excercises_AuId",
                table: "Excercises",
                column: "AuId");

            migrationBuilder.CreateIndex(
                name: "IX_Excercises_CourseId",
                table: "Excercises",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Excercises_TAuId",
                table: "Excercises",
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
                name: "Excercises");

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
