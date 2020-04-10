using Microsoft.EntityFrameworkCore;
using OnlineHelpSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Data
{
    partial class MyDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Exercise> Excercises { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //Student
            modelbuilder.Entity<Student>()
                .HasKey(s => s.AuId);

            modelbuilder.Entity<Student>()
                .HasMany<Exercise>(s => s.Exercises)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.AuId);

            modelbuilder.Entity<Student>()
              .Property(s => s.Name);

            //Courses
            modelbuilder.Entity<Course>()   
                .HasKey(c => c.CourseId);

            modelbuilder.Entity<Course>()
                .HasMany<Assignment>(c => c.Assignments)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            modelbuilder.Entity<Course>()
               .HasMany<Exercise>(c => c.Exercises)
               .WithOne(c => c.Course)
               .HasForeignKey(c => c.CourseId);

            modelbuilder.Entity<Course>()
               .HasMany<Teacher>(c => c.Teachers)
               .WithOne(c => c.Course)
               .HasForeignKey(c => c.CourseId);

            modelbuilder.Entity<Course>()
                .Property(c => c.Name);
         
            //Assignments
            modelbuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(l => l.AssignmentNumber);
                entity.Property(l => l.HelpWhere);
            });
            //Exercises
            modelbuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(e => new { e.Lecture, e.Number });
                entity.Property(e => e.HelpWhere);
            });

            //Teachers
            modelbuilder.Entity<Teacher>()
                .HasKey(t => t.TAuId);

            modelbuilder.Entity<Teacher>()
                .HasMany<Assignment>(c => c.Assignements)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TAuId);

            modelbuilder.Entity<Teacher>()
             .HasMany<Exercise>(c => c.Exercises)
             .WithOne(c => c.Teacher)
             .HasForeignKey(c => c.TAuId);

            modelbuilder.Entity<Teacher>()
                .Property(t => t.Name);
            

            //StudentAssignment
            modelbuilder.Entity<StudentAssignment>()
                .HasKey(sa => new { sa.AuId, sa.AssignmentNumber });

            modelbuilder.Entity<StudentAssignment>()
                .HasOne(sa => sa.Student)
                .WithMany(sa => sa.StudentAssignments)
                .HasForeignKey(sa => sa.AuId);


            modelbuilder.Entity<StudentAssignment>()
              .HasOne(sa => sa.Assignment)
              .WithMany(sa => sa.StudentAssignments)
              .HasForeignKey(sa => sa.AssignmentNumber);



            //StudentCourses
            modelbuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.AuId, sc.CourseId });


            modelbuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(sc => sc.StudentCourses)
                .HasForeignKey(sc => sc.AuId);

            modelbuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(sc => sc.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);


            modelbuilder.Entity<StudentCourse>(entity =>
            {
                entity.Property(sc => sc.IsActive);
                entity.Property(sc => sc.Semester);
            });

        }
    }

}