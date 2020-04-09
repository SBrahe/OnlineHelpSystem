using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Data
{
    class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = 127.0.0.1, 1433; Database = OnlineHelpSystemDb; User ID = SA; Password = SecurePassword1!");
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exercise> Exersices { get; set; }
        public DbSet<Student> Students { get; set; }
        public  DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCCreating(ModelBuilder mb)
        {

        }

    }
}
