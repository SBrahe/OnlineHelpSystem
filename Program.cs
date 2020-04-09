using System.Collections.Generic;
using System;
using System.Linq;
using EfIntroSolution.Data;
using EfIntroSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineHelpSystem
{
    class Program
    {
        static void Main(string[] args)
        {
          Console.WriteLine("OnlineHelpSystem launched"); 
          
          using (var context = new AppDbContext()) 
          
          { 
            //SEED DATABASE PROMPT
            System.Console.WriteLine("Y/n: Seed database?"); 
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(); 
            if (consoleKeyInfo.KeyChar == 'Y') 
            { 
              SeedDatabase(context);
            } 
            
            //ACTION PROMPT
            System.Console.WriteLine("What would you like to do?");
            System.Console.WriteLine("1: Print open help requests for (teacher, course)");
            System.Console.WriteLine("2: Print all open help requests");
            System.Console.WriteLine("3: Print statistics for help requests for (course)");
            System.Console.WriteLine("4: Create data");
            consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo)
            {
              case '1':
                PrintOpenHelpRequestsForTeacherCourse(context);
                break;
              case '2':
                PrintAllOpenHelpRequests(context);
                break;
              case '3':
                PrintStatisticsForCourse(context);
                break;
              case '4':
                CreateData(context);
                break;
            }
          }
    }

    private static void PrintOpenHelpRequestsForTeacherCourse(AppDbContext context);
    {
      string teacher;
      string course;
      System.Console.WriteLine("Choose teacher");
      teacher = Console.ReadLine();
      System.Console.WriteLine("Choose course");
      course = Console.ReadLine();
    }

    private static void PrintAllOpenHelpRequests(AppDbContext context)
    {
      
    }

    private static void PrintStatisticsForCourse(AppDbContext context, string course)
    {
      string course;
      System.Console.WriteLine("Choose course");
      course = Console.ReadLine();
    }

    private static void CreateData();
    {
    System.Console.WriteLine("What would you like to do?");
    System.Console.WriteLine("1: Create new course");
    System.Console.WriteLine("2: Create new student");
    System.Console.WriteLine("3: Create new teacher");
    System.Console.WriteLine("4: Create new assignment");
    System.Console.WriteLine("5: Create new exercise");
    System.Console.WriteLine("6: Create new review");
    System.Console.WriteLine("7: Create new help request");
    consoleKeyInfo = Console.ReadKey();
    switch (consoleKeyInfo)
    {
      case: '1'
        string Id; 
        string Name;
        System.Console.WriteLine("Input course ID:");
        Id = Console.ReadLine();
        System.Console.WriteLine("Input course Name:");
        Name = Console.ReadLine();

        Course newcourse = new Course()
        {
          CourseId = Id,
          Name = Name
        };
        context.Add(newcourse);
        break;
      case: '2'
      break;
      case: '3'
      break;
      case: '4'
      break;
      case: '5'
      break;
      case: '6'
      break;
      case: '7'
      break;

    
/*
    private static void ListAllPrinters(AppDbContext context)
    {
      foreach (var pc in context.printers.Include(p => p.Product).ToList())
      {
        System.Console.WriteLine(pc);
      }
    }

    private static void ListAllLaptops(AppDbContext context)
    {
      foreach (var pc in context.laptops.Include(p => p.Product).ToList())
      {
        System.Console.WriteLine(pc);
      }
    }

    private static void ListAllPcs(AppDbContext context)
    {
      foreach (var pc in context.pcs.Include(p => p.Product).ToList())
      {
        System.Console.WriteLine(pc);
      }
    }

    private static void SeedDatabase(AppDbContext context)
    {
      Product DellLatitude = new Product()
      {
        Maker = "Dell",
        Model = "Latitude"
      };

      Product ThinkpadT560 = new Product()
      {
        Maker = "Thinkpad",
        Model = "T560"
      };

      Product Epson = new Product()
      {
        Maker = "Epson",
      };

      context.Add(DellLatitude);
      context.Add(ThinkpadT560);
      context.Add(Epson);

      Laptop laptop1 = new Laptop()
      {
        Product = ThinkpadT560,
        Hd = 23,
        Screen = 21,
        Price = 23,
        Speed = 34,
      };

      Laptop laptop2 = new Laptop()
      {
        Product = ThinkpadT560,
        Hd = 24,
        Screen = 21,
        Price = 23,
        Speed = 34,
      };

      Laptop laptop3 = new Laptop()
      {
        Product = DellLatitude,
        Hd = 242,
        Screen = 12,
        Price = 2323,
        Speed = 341,
      };

      context.Add(laptop1);
      context.Add(laptop2);
      context.Add(laptop3);

      Printer p = new Printer()
      {
        Product = Epson,
        Color = "64",
        Price = 234
      };

      context.Add(p);

      context.SaveChanges();
      System.Console.WriteLine("Data saved");
        }
    }
    */
}
