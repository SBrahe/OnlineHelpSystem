using System.Collections.Generic;
using System;
using System.Linq;
using System.Net.Mime;
using OnlineHelpSystem.Data;
using OnlineHelpSystem.Models;
using Microsoft.EntityFrameworkCore;


namespace OnlineHelpSystem
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("OnlineHelpSystem launched");
      using var context = new MyDbContext();
      
      //SEED DATABASE PROMPT
      System.Console.WriteLine("y/n: Seed database?");
      ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
      if (consoleKeyInfo.KeyChar == 'y')
      {
        System.Console.WriteLine("\n");
        SeedDatabase(context);
      }
      else
      {
        System.Console.WriteLine("\n");
      }
      
      //CHOOSE ACTION PROMPT
      CHOOSE_ACTION_PROMPT:
      System.Console.WriteLine("What would you like to do?");
      System.Console.WriteLine("1: Print open help requests for (teacher, course)");
      System.Console.WriteLine("2: Print all open help requests");
      System.Console.WriteLine("3: Print statistics for help requests for (course)");
      System.Console.WriteLine("4: List all data");
      System.Console.WriteLine("5: Create data");
      System.Console.WriteLine("6: Exit");
      consoleKeyInfo = Console.ReadKey();
      switch (consoleKeyInfo.KeyChar)
      {
        case '1':
          System.Console.WriteLine("");
          PrintOpenHelpRequestsForTeacherCourse(context);
          goto CHOOSE_ACTION_PROMPT;
        case '2':
          System.Console.WriteLine("");
          PrintAllOpenHelpRequests(context);
          goto CHOOSE_ACTION_PROMPT;
        case '3':
          System.Console.WriteLine("");
          PrintStatisticsForCourse(context);
          goto CHOOSE_ACTION_PROMPT;
        case '4':
          System.Console.WriteLine("");
          ListAllData(context);
          goto CHOOSE_ACTION_PROMPT;
        case '5':
          System.Console.WriteLine("");
          CreateData(context);
          goto CHOOSE_ACTION_PROMPT;
        case '6':
          break; 
        default:
          break;
      }
    }

    private static void PrintOpenHelpRequestsForTeacherCourse(MyDbContext context)
    {
      string teacher;
      string course;
      System.Console.WriteLine("Choose teacher");
      teacher = Console.ReadLine();
      System.Console.WriteLine("Choose course");
      course = Console.ReadLine();
    }

    private static void PrintAllOpenHelpRequests(MyDbContext context)
    {

    }

    private static void PrintStatisticsForCourse(MyDbContext context)
    {
      // string course;
      // System.Console.WriteLine("Choose course");
      // course = Console.ReadLine();
      //
      // course = context.Courses.Include(p => p.Name);
      //   
      // foreach (var course in context.Courses.Include(p => p.Name).ToList())
      // {
      //   System.Console.WriteLine(course);
      // }
    }

    private static void ListAllData(MyDbContext context)
    {
      System.Console.WriteLine("LISTING ALL DATA"); 
      //list all students
      System.Console.WriteLine("___ALL STUDENTS___"); 
      var studentList =context.Students.ToList();
      
      foreach (var student in studentList)
      {
        System.Console.WriteLine(student.Name);
      }
      System.Console.WriteLine("");

      //list all teachers
      System.Console.WriteLine("___ALL TEACHERS___");
      var teacherList =context.Teachers.ToList();
      
      foreach (var teacher in teacherList)
      {
        System.Console.WriteLine(teacher.Name);
      }
      System.Console.WriteLine("");

      //list all courses
      System.Console.WriteLine("___ALL COURSES___");
      var courseList =context.Courses.ToList();
      
      foreach (var course in courseList)
      {
        System.Console.WriteLine(course.Name);
      }
      System.Console.WriteLine("");

      //list all exercises
      System.Console.WriteLine("___ALL EXERCISES___");
      var exerciseList =context.Excercises.ToList();
      
      foreach (var exercise in exerciseList)
      {
        System.Console.WriteLine(exercise.ExerciseNumber);
      }
      System.Console.WriteLine("");

      //list all assignments
      System.Console.WriteLine("___ALL ASSIGNMENTS___");
      var assignmentList =context.Assignments.ToList();
      
      foreach (var assignment in assignmentList)
      {
        System.Console.WriteLine(assignment.AssignmentNumber);
      }
      System.Console.WriteLine("");
    }

    private static void CreateData(MyDbContext context)
    {
      string id;
      string name;
      System.Console.WriteLine("What would you like to do?");
      System.Console.WriteLine("1: Create new course");
      System.Console.WriteLine("2: Create new student");
      System.Console.WriteLine("3: Create new teacher");
      System.Console.WriteLine("4: Create new assignment");
      System.Console.WriteLine("5: Create new exercise");
      System.Console.WriteLine("6: Create new review");
      System.Console.WriteLine("7: Create new help request");
      ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
      switch (consoleKeyInfo.KeyChar)
      {
        case '1': //create new course
          System.Console.WriteLine("Input course ID:");
          id = Console.ReadLine();
          System.Console.WriteLine("Input course name:");
          name = Console.ReadLine();

          Course newCourse = new Course()
          {
            CourseId = id,
            Name = name
          };
          context.Add(newCourse);
          break;
        case '2': //create new student
          System.Console.WriteLine("Input student auID:");
          id = Console.ReadLine();
          System.Console.WriteLine("Input student name:");
          name = Console.ReadLine();
          Student newStudent = new Student()
          {
            AuId = id,
            Name = name
          };
          context.Add(newStudent);
          break;
        case '3': // create new teacher
          System.Console.WriteLine("Input teacher auID:");
          id = Console.ReadLine();
          System.Console.WriteLine("Input teacher name:");
          name = Console.ReadLine();
          Teacher newTeacher = new Teacher()
          {
            TAuId = id,
            Name = name
          };
          context.Add(newTeacher);
          break;
        case '4': //create new assignment
          break;
        case '5': //create new exercise
          break;
        case '6': //create new review
          break;
        case '7': // create new help request
          break;
      }
    }

    private static void SeedDatabase(MyDbContext context)
    {
      //delete and recreate database
      context.Database.EnsureDeleted();
      context.Database.EnsureCreated();
      
      //create students
      context.Students.Add(new Student { AuId = "au135848", Name = "Soeren Brostroem",});
      context.Students.Add(new Student { AuId = "au135333", Name = "Hanne Lind",});
      context.Students.Add(new Student { AuId = "au145532", Name = "Soeren Brahe",});
      context.Students.Add(new Student { AuId = "au136427", Name = "Flemming Dalager",});
      context.Students.Add(new Student { AuId = "au963454", Name = "Mogens Bech",});
      context.SaveChanges();
      
      //create teachers
      context.Teachers.Add(new Teacher { TAuId = "au758313", Name = "Lars Larsen",});
      context.Teachers.Add(new Teacher { TAuId = "au542341", Name = "Barack Obama",});
      context.Teachers.Add(new Teacher { TAuId = "au542413", Name = "Joe Exotic",});
      context.Teachers.Add(new Teacher { TAuId = "au531234", Name = "Saul Goodman",});
      context.Teachers.Add(new Teacher {TAuId = "au1241245", Name = "Phoebe Buffay",});
      context.SaveChanges();
      
      //create courses
      context.Courses.Add(new Course { CourseId = "I4DAB", Name = "Databaser",});
      context.Courses.Add(new Course { CourseId = "I3ISU", Name = "Indlejret Softwareudvikling"});
      context.Courses.Add(new Course { CourseId = "I4SWD", Name = "Software Design",});
      context.SaveChanges();
      
      //create assignments
      

      //create exercises
      
      System.Console.WriteLine("Database seeded");
    }
  }
}