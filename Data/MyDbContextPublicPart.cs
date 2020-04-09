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
                entity.Property(s => s.Name);
            });
            //Courses
            modelbuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.CourseId);
                entity.Property(c => c.Name);
            });
        }
    }

}