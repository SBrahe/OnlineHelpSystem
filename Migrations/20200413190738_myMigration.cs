using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineHelpSystem.Migrations
{
    public partial class myMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Excercises_Students_AuId",
                table: "Excercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Excercises_Courses_CourseId",
                table: "Excercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Excercises_Teachers_TAuId",
                table: "Excercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Excercises",
                table: "Excercises");

            migrationBuilder.RenameTable(
                name: "Excercises",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Excercises_TAuId",
                table: "Exercises",
                newName: "IX_Exercises_TAuId");

            migrationBuilder.RenameIndex(
                name: "IX_Excercises_CourseId",
                table: "Exercises",
                newName: "IX_Exercises_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Excercises_AuId",
                table: "Exercises",
                newName: "IX_Exercises_AuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                columns: new[] { "Lecture", "ExerciseNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Students_AuId",
                table: "Exercises",
                column: "AuId",
                principalTable: "Students",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Courses_CourseId",
                table: "Exercises",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Teachers_TAuId",
                table: "Exercises",
                column: "TAuId",
                principalTable: "Teachers",
                principalColumn: "TAuId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Students_AuId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Courses_CourseId",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Teachers_TAuId",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Excercises");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_TAuId",
                table: "Excercises",
                newName: "IX_Excercises_TAuId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_CourseId",
                table: "Excercises",
                newName: "IX_Excercises_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_AuId",
                table: "Excercises",
                newName: "IX_Excercises_AuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Excercises",
                table: "Excercises",
                columns: new[] { "Lecture", "ExerciseNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Excercises_Students_AuId",
                table: "Excercises",
                column: "AuId",
                principalTable: "Students",
                principalColumn: "AuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Excercises_Courses_CourseId",
                table: "Excercises",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Excercises_Teachers_TAuId",
                table: "Excercises",
                column: "TAuId",
                principalTable: "Teachers",
                principalColumn: "TAuId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
