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
            modelbuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.AuId );
                entity.HasOne(s => s.Name);
            });
            //Courses
            modelbuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);
                entity.Property(c => c.Name);
            });
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
            modelbuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(t => t.AuId);
                entity.Property(t => t.Name);
            });
        }
    }

}