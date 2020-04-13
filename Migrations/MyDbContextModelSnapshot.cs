﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineHelpSystem.Data;

namespace OnlineHelpSystem.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineHelpSystem.Models.Assignment", b =>
                {
                    b.Property<string>("AssignmentNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.Property<string>("TAuId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AssignmentNumber");

                    b.HasIndex("CourseId");

                    b.HasIndex("TAuId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Course", b =>
                {
                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Exercise", b =>
                {
                    b.Property<string>("Lecture")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ExerciseNumber")
                        .HasColumnType("int");

                    b.Property<string>("AuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HelpWhere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Open")
                        .HasColumnType("bit");

                    b.Property<string>("TAuId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Lecture", "ExerciseNumber");

                    b.HasIndex("AuId");

                    b.HasIndex("CourseId");

                    b.HasIndex("TAuId");

                    b.ToTable("Excercises");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Student", b =>
                {
                    b.Property<string>("AuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.StudentAssignment", b =>
                {
                    b.Property<string>("AuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AssignmentNumber")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AuId", "AssignmentNumber");

                    b.HasIndex("AssignmentNumber");

                    b.ToTable("StudentAssignment");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.StudentCourse", b =>
                {
                    b.Property<string>("AuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("AuId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Teacher", b =>
                {
                    b.Property<string>("TAuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TAuId");

                    b.HasIndex("CourseId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Assignment", b =>
                {
                    b.HasOne("OnlineHelpSystem.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId");

                    b.HasOne("OnlineHelpSystem.Models.Teacher", "Teacher")
                        .WithMany("Assignments")
                        .HasForeignKey("TAuId");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Exercise", b =>
                {
                    b.HasOne("OnlineHelpSystem.Models.Student", "Student")
                        .WithMany("Exercises")
                        .HasForeignKey("AuId");

                    b.HasOne("OnlineHelpSystem.Models.Course", "Course")
                        .WithMany("Exercises")
                        .HasForeignKey("CourseId");

                    b.HasOne("OnlineHelpSystem.Models.Teacher", "Teacher")
                        .WithMany("Exercises")
                        .HasForeignKey("TAuId");
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.StudentAssignment", b =>
                {
                    b.HasOne("OnlineHelpSystem.Models.Assignment", "Assignment")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("AssignmentNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineHelpSystem.Models.Student", "Student")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("AuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.StudentCourse", b =>
                {
                    b.HasOne("OnlineHelpSystem.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("AuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineHelpSystem.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineHelpSystem.Models.Teacher", b =>
                {
                    b.HasOne("OnlineHelpSystem.Models.Course", "Course")
                        .WithMany("Teachers")
                        .HasForeignKey("CourseId");
                });
#pragma warning restore 612, 618
        }
    }
}
