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

            //Courses
            modelbuilder.Entity<Course>()
                .HasKey(c => c.CourseId);

            //Teachers
            modelbuilder.Entity<Teacher>()
                .HasKey(t => t.TAuId);

            modelbuilder.Entity<Teacher>()
               .HasOne<Course>(t => t.Course)
               .WithMany(t => t.Teachers)
               .HasForeignKey(t => t.CourseId);

            //Assignments
            modelbuilder.Entity<Assignment>()
                .HasKey(a => a.AssignmentNumber);
            
            modelbuilder.Entity<Assignment>()
                .HasOne<Course>(a => a.Course)
                .WithMany(a => a.Assignments)
                .HasForeignKey(a => a.CourseId);

            modelbuilder.Entity<Assignment>()
                .HasOne<Teacher>(a => a.Teacher)
                .WithMany(a => a.Assignments)
                .HasForeignKey(a => a.TAuId);


            //Exercises
            modelbuilder.Entity<Exercise>()
                .HasKey(e => new { e.Lecture, e.ExerciseNumber });

    
            modelbuilder.Entity<Exercise>()
             .HasOne<Student>(e => e.Student)
             .WithMany(e => e.Exercises)
             .HasForeignKey(e => e.AuId);

            modelbuilder.Entity<Exercise>()
            .HasOne<Course>(e => e.Course)
            .WithMany(e => e.Exercises)
            .HasForeignKey(e => e.CourseId);

            modelbuilder.Entity<Exercise>()
            .HasOne<Teacher>(e => e.Teacher)
            .WithMany(e => e.Exercises)
            .HasForeignKey(e => e.TAuId);


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

            //adding data

            modelbuilder.Entity<Student>().HasData(
            new Student { AuId = "au135848", Name = "Soeren Brostroem" },
            new Student {AuId = "au135333", Name = "Hanne Lind"},
            new Student { AuId = "au145532", Name = "Soeren Brahe" },
            new Student { AuId = "au136427", Name = "Flemming Dalager" },
            new Student { AuId = "au963454", Name = "Mogens Bech" }
            );

            modelbuilder.Entity<Course>().HasData(
            new Course { CourseId = "I4DAB", Name = "Databaser" },
            new Course { CourseId = "I3ISU", Name = "Indlejret Softwareudvikling" },
            new Course { CourseId = "I4SWD", Name = "Software Design2345" }
                );

            modelbuilder.Entity<Teacher>().HasData(
            new Teacher { TAuId = "au758313", Name = "Lars Larsen" },
            new Teacher { TAuId = "au542341", Name = "Barack Obama" },
            new Teacher { TAuId = "au542413", Name = "Joe Exotic" },
            new Teacher { TAuId = "au531234", Name = "Saul Goodman" },
            new Teacher { TAuId = "au1241245", Name = "Phoebe Buffay" }
                );

            modelbuilder.Entity<Assignment>().HasData(
                new Assignment { AssignmentNumber = "1", CourseId = "I4DAB", TAuId = "au542413" },
                new Assignment { AssignmentNumber = "2", CourseId = "I4SWD", TAuId = "au531234" },
                new Assignment { AssignmentNumber = "3", CourseId = "I3ISU", TAuId = "au542341" }
                );

            modelbuilder.Entity<Exercise>().HasData(
                new Exercise { ExerciseNumber = 1, Lecture = "EF Core", HelpWhere = "opg 2.4", AuId = "au135848", CourseId = "I4DAB", TAuId = "au542413" },
                new Exercise { ExerciseNumber = 2, Lecture = "Migrations", HelpWhere = "opg 1", AuId = "au136427", CourseId = "I4DAB", TAuId = "au542413" },
                new Exercise { ExerciseNumber = 3, Lecture = "Oberserver Pattern", HelpWhere = "opg 3.7", AuId = "au145532", CourseId = "I4SWD", TAuId = "au531234" },
                new Exercise { ExerciseNumber = 4, Lecture = "Umulig c++", HelpWhere = "opg 42.4", AuId = "au963454", CourseId = "I3ISU", TAuId = "au542341" }
                );
        }
    }
}