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
                System.Console.WriteLine("");
                SeedDatabase(context);
            }
            else
            {
                System.Console.WriteLine("");
            }

            #region Action prompts

            while (true)
            {
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
                        Console.WriteLine("");
                        PrintOpenHelpRequestsForTeacherCourse(context);
                        break;
                    case '2':
                        System.Console.WriteLine("");
                        PrintAllOpenHelpRequests(context);
                        break;
                    case '3':
                        System.Console.WriteLine("");
                        PrintStatisticsForCourse(context);
                        break;
                    case '4':
                        System.Console.WriteLine("");
                        ListAllData(context);
                        break;
                    case '5':
                        System.Console.WriteLine("");
                        CreateData(context);
                        break;
                    case '6':
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Print specifics

        private static void PrintOpenHelpRequestsForTeacherCourse(MyDbContext context)
        {
            //au542413 - Kan bruges som eksempel på søgning
            //I4DAB

            string teacher;
            string course;
            Console.WriteLine("Choose teacher AuId: ");
            teacher = Console.ReadLine();

            Console.WriteLine("Choose Course id: " + Environment.NewLine);
            course = Console.ReadLine();
            Console.WriteLine("___Open exercise help Request(s)___");
            foreach (var exercise in context.Exercises)
            {
                if (exercise.TAuId == teacher && exercise.CourseId == course && exercise.Open == true)
                {
                    Console.WriteLine("Exercise ID: " + exercise.ExerciseNumber + ", Course: " + exercise.Course.Name + ", HelpeWere: " + exercise.HelpWhere);
                    Console.WriteLine("   * Student who needs help: ");
                    Console.WriteLine("      - " + "Au id: " + exercise.AuId + ", Name" + exercise.Student.Name);
                    exercise.Open = false;                    
                }               
            }


            Console.WriteLine("");

            Console.WriteLine("___Open assignment help Request(s)___");
            foreach (var assignment in context.Assignments)
            {
                if (assignment.TAuId == teacher && assignment.CourseId == course && assignment.Open == true)
                {
                    Console.WriteLine("Assignment ID: " + assignment.AssignmentNumber + ", Course: " + assignment.Course.Name + ", HelpWere: " + assignment.HelpWhere);                    
                    Console.WriteLine("   * Student(s) who needs help: ");                                        
                    foreach (var sa in assignment.StudentAssignments)
                    {
                        Console.WriteLine("      - Au id: " + sa.AuId + ", Navn: " + sa.Student.Name);                        
                    }

                    assignment.Open = false;                    
                }
            }
            context.SaveChanges(); //To open help-request

     
        }

        private static void PrintAllOpenHelpRequests(MyDbContext context)
        {
            //I kan teste med auid : au135848
            string auid;
            Student student = new Student();

            Console.WriteLine("Input Student Auid: ");
            auid = Console.ReadLine();
            try
            {
                student = context.Students.Where(s => s.AuId == auid).Single();
            }
            catch
            {
                Console.WriteLine("Student does not exist");

            }

     
            Console.WriteLine("Name of student who needs help: " + student.Name);

            Console.WriteLine("___Exercises___ ");
            foreach (var exercise in context.Exercises)
            {
                if (exercise.AuId == auid && exercise.Open==true)
                {
                    Console.WriteLine("----------Exercise Help Request----------");
                    Console.WriteLine(
                        $"Exercise Number: {exercise.ExerciseNumber}, Lecture: {exercise.Lecture}, Help where?: " +
                        $"{exercise.HelpWhere}, Student Auid: {exercise.AuId}, CourseId: {exercise.CourseId}, Teacher AuId: {exercise.TAuId}");
                    Console.WriteLine("-----------------------------------------");
                }
            }

            Console.WriteLine("");

            Console.WriteLine("___Assigments___ ");
            foreach (var assignments in context.StudentAssigments)
            {
                    if (assignments.AuId==auid && assignments.Assignment.Open==true)
                    {
                        Console.WriteLine("----------Assignment Help Request----------");
                        Console.WriteLine($"Assignment number: {assignments.AssignmentNumber}, Help Where?: {assignments.Assignment.HelpWhere} " +
                            $"Student AuID: {assignments.AuId} Course Id: {assignments.Assignment.CourseId}, Teacher AuID: {assignments.Assignment.TAuId}");
                    
                        Console.WriteLine("-----------------------------------------");
                    }
            }

            Console.WriteLine("");

        }

        private static void PrintStatisticsForCourse(MyDbContext context)
        {
            string courseId;
            Course course;
            int allhelprequests = 0;
            int openhelprequests = 0;
            int closedhelprequests = 0;

            Console.WriteLine("Choose Course id:");
            courseId = Console.ReadLine();
            try
            {
                course = context.Courses.Where(s => s.CourseId == courseId).Single();
            }
            catch
            {
                Console.WriteLine("Course does not exist");
            }
            
            //find open exercise help requests for course
            foreach (var exercise in context.Exercises)
            {
                if (exercise.CourseId == courseId && exercise.Open == false)
                {
                    ++openhelprequests;
                    ++allhelprequests;
                }
            }
            //find open assignment help requests for course
            foreach (var assignment in context.Exercises)
            {
                if (assignment.CourseId == courseId && assignment.Open == true)
                {
                    ++openhelprequests;
                    ++allhelprequests;
                }
            }
            //find closed exercise help requests for course
            foreach (var exercise in context.Exercises)
            {
                if (exercise.CourseId == courseId && exercise.Open == true)
                {
                    ++closedhelprequests;
                    ++allhelprequests;
                }
            }
            
            //find closed assignment help requests for course
            foreach (var exercise in context.Exercises)
            {
                if (exercise.CourseId == courseId && exercise.Open == false)
                {
                    ++closedhelprequests;
                    ++allhelprequests;
                }
            }
            System.Console.WriteLine("PRINTING HELP REQUESTS STATISTICS "+courseId);
            Console.WriteLine("Help Requests: "+allhelprequests);
            Console.WriteLine("Open: "+openhelprequests);
            Console.WriteLine("Closed : "+closedhelprequests);
        }
        #endregion

    #region List all data
    private static void ListAllData(MyDbContext context)
    {
    System.Console.WriteLine("LISTING ALL DATA");

    //list all students
    System.Console.WriteLine("___ALL STUDENTS___");

    var studentList = context.Students.ToList();

        foreach (var student in studentList)
    {
        System.Console.WriteLine(student.Name);
    }
    System.Console.WriteLine("");

    //list all teachers
    System.Console.WriteLine("___ALL TEACHERS___");

    var teacherList = context.Teachers.ToList();

        foreach (var teacher in teacherList)
    {
        System.Console.WriteLine(teacher.Name);
    }
    System.Console.WriteLine("");

    //list all courses
    System.Console.WriteLine("___ALL COURSES___");

    var courseList = context.Courses.ToList();

        foreach (var course in courseList)
    {
        System.Console.WriteLine(course.Name);
    }
    System.Console.WriteLine("");

    //list all exercises
    System.Console.WriteLine("___ALL EXERCISES___");

    var exerciseList = context.Exercises.ToList();

        foreach (var exercise in exerciseList)
    {
        System.Console.WriteLine(exercise.ExerciseNumber);
    }
    System.Console.WriteLine("");

    //list all assignments
    System.Console.WriteLine("___ALL ASSIGNMENTS___");

    var assignmentList = context.Assignments.ToList();

        foreach (var assignment in assignmentList)
    {
        System.Console.WriteLine(assignment.AssignmentNumber);
    }
    System.Console.WriteLine("");
    }

    #endregion

#region Create Data
        private static void CreateData(MyDbContext context)
    {
            string id;
            string name;
            string courseid;
            string tauid;
            int exnumber;
            string asnumber;
            string helpwhere;
            string lecture; 
            
            System.Console.WriteLine("What would you like to do?"); 
            System.Console.WriteLine("1: Create new course"); 
            System.Console.WriteLine("2: Create new student"); 
            System.Console.WriteLine("3: Create new teacher"); 
            System.Console.WriteLine("4: Create new assignment help request"); 
            System.Console.WriteLine("5: Create new exercise help request"); 
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
          Console.WriteLine("Input teacher auID:");
          tauid = Console.ReadLine();
          Console.WriteLine("Input teacher name:");
          name = Console.ReadLine();
          Teacher newTeacher = new Teacher()
          {
            TAuId = tauid,
            Name = name
          };
          context.Add(newTeacher);
          break;
        case '4': //create new assignment help request
                    Student student1;
                    Teacher teacher1;
                    Course course1;

                    Console.WriteLine("Input Course id: ");
                    courseid = Console.ReadLine();
                    try
                    {
                        course1 = context.Courses.Where(s => s.CourseId == courseid).Single();
                    }
                    catch
                    {
                        Console.WriteLine("Course does not exist");
                        break;
                    }

                    Console.WriteLine("Input Student AuId: ");
                    id = Console.ReadLine();
                    try
                    {
                        student1 = context.Students.Where(s => s.AuId == id).Single();
                    }
                    catch
                    {
                        Console.WriteLine("Student does not exist");
                        break;
                    }

                    Console.WriteLine("Input Teacher AuId: ");
                    tauid = Console.ReadLine();
                    try
                    {
                        teacher1 = context.Teachers.Where(s => s.TAuId == tauid).Single();
                    }
                    catch
                    {
                        Console.WriteLine("Teacher does not exist");
                        break;
                    }

                    Console.WriteLine("Input Assignment number: ");
                    asnumber = (Console.ReadLine());


                    Assignment assignment = new Assignment()
                    {
                        TAuId = tauid,
                        CourseId = courseid,
                        AssignmentNumber = asnumber

                    };
                    assignment.StudentAssignments = new List<StudentAssignment>()
                    {
                        new StudentAssignment
                        {
                            Assignment=assignment,
                            Student=student1
                        }
                    };
                    context.Add(assignment);
                    context.SaveChanges();
                    Console.WriteLine("Added Assignment Request!");
                    break;
        case '5': //create new Exercise Help Request
                    Student student2;
                    Teacher teacher2;
                    Course course2;

                    Console.WriteLine("Input Course id: ");
                    courseid = Console.ReadLine();
                    try
                    {
                        course2 = context.Courses.Where(s => s.CourseId == courseid).Single();
                    }
                    catch
                    {
                        Console.WriteLine("Course does not exist");
                        break;
                    }

                    Console.WriteLine("Input Student AuId: ");
                    id = Console.ReadLine();
                    try
                    {
                        student2 = context.Students.Where(s => s.AuId == id).Single();
                    }
                    catch
                    {
                        Console.WriteLine("Student does not exist");
                        break;
                    }

                    Console.WriteLine("Input Teacher AuId: ");
                    tauid = Console.ReadLine();
                    try
                    {
                        teacher2 = context.Teachers.Where(s => s.TAuId == tauid).Single();
                    }
                    catch
                    {
                        Console.WriteLine("Teacher does not exist");
                        break;
                    }

                    Console.WriteLine("Input Exercise number: ");
                    exnumber = int.Parse(Console.ReadLine());

                    Console.WriteLine("Input Exercise Lecture: ");
                    lecture = Console.ReadLine();

                    Console.WriteLine("Input Exercise Help where: ");
                    helpwhere = Console.ReadLine();

                    Exercise exercise = new Exercise
                    {
                        ExerciseNumber = exnumber,
                        Lecture = lecture,
                        HelpWhere = helpwhere,
                        AuId = id,
                        TAuId = tauid,
                        CourseId = courseid

                    };
                    context.Add(exercise);
                    context.SaveChanges();
                    Console.WriteLine("Added Exercise Request!");

                    break;
            }
    }
        #endregion

        #region Remove Data

        private static void RemoveData(MyDbContext context)
        {
            foreach (var teacher in context.Teachers)
            {
                context.Teachers.Remove(teacher);
            }
            foreach (var assignment in context.Assignments)
            {
                context.Assignments.Remove(assignment);
            }
            foreach (var exercise in context.Exercises)
            {
                context.Exercises.Remove(exercise);
            }
            foreach (var student in context.Students)
            {
                context.Students.Remove(student);
            }
            foreach (var course in context.Courses)
            {
                context.Courses.Remove(course);
            }  

            context.SaveChanges();
            Console.WriteLine("Data removed");
        }
        
        #endregion

        #region SeedDatabase

        private static void SeedDatabase(MyDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            
            context.Students.Add(new Student { AuId = "au135848", Name = "Soeren Brostroem", });
            context.Students.Add(new Student { AuId = "au135333", Name = "Hanne Lind", });
            context.Students.Add(new Student { AuId = "au145532", Name = "Soeren Brahe", });
            context.Students.Add(new Student { AuId = "au136427", Name = "Flemming Dalager", });
            context.Students.Add(new Student { AuId = "au963454", Name = "Mogens Bech", });
            context.Students.Add(new Student { AuId = "au135847", Name = "Hugh Mungus", });

            Course course1 = new Course { CourseId = "I4DAB", Name = "Databaser"};
            context.Courses.Add(course1);
            context.Courses.Add(new Course { CourseId = "I3ISU", Name = "Indlejret Softwareudvikling", });
            context.Courses.Add(new Course { CourseId = "I4SWD", Name = "Software Design2345", });

            context.Teachers.Add(new Teacher { TAuId = "au758313", Name = "Lars Larsen", CourseId = "I4DAB", Course = course1});
            context.Teachers.Add(new Teacher { TAuId = "au542341", Name = "Barack Obama" });
            context.Teachers.Add(new Teacher { TAuId = "au542413", Name = "Joe Exotic" });
            context.Teachers.Add(new Teacher { TAuId = "au531234", Name = "Saul Goodman" });
            context.Teachers.Add(new Teacher { TAuId = "au1241245", Name = "Phoebe Buffay" });

            context.Assignments.Add(new Assignment { AssignmentNumber = "1", CourseId = "I4DAB", TAuId = "au542413", Open = false, HelpWhere="Opgave 3"});            
            context.Assignments.Add(new Assignment { AssignmentNumber = "2", CourseId = "I4SWD", TAuId = "au531234", Open = true, HelpWhere = "Opgave 5" });
            context.Assignments.Add(new Assignment { AssignmentNumber = "3", CourseId = "I3ISU", TAuId = "au542341", Open = false, HelpWhere = "Opgave 4" });
            context.Assignments.Add(new Assignment { AssignmentNumber = "4", CourseId = "I4DAB", TAuId = "au542413", Open = false, HelpWhere = "Opgave 7" });

            context.StudentAssigments.Add(new StudentAssignment { AssignmentNumber = "1", AuId = "au135848" });
            context.StudentAssigments.Add(new StudentAssignment { AssignmentNumber = "1", AuId = "au135333" });
            context.StudentAssigments.Add(new StudentAssignment { AssignmentNumber = "4", AuId = "au963454" });



            context.Exercises.Add(new Exercise { ExerciseNumber = 1, Lecture = "EF Core", HelpWhere = "opg 2.4", AuId = "au135848", CourseId = "I4DAB", TAuId = "au542413", Open = false});            
            context.Exercises.Add(new Exercise { ExerciseNumber = 2, Lecture = "Migrations", HelpWhere = "opg 1", AuId = "au136427", CourseId = "I4DAB", TAuId = "au542413", Open = true});
            context.Exercises.Add(new Exercise { ExerciseNumber = 3, Lecture = "Oberserver Pattern", HelpWhere = "opg 3.7", AuId = "au145532", CourseId = "I4SWD", TAuId = "au531234", Open = false});
            context.Exercises.Add(new Exercise { ExerciseNumber = 4, Lecture = "Umulig c++", HelpWhere = "opg 42.4", AuId = "au963454", CourseId = "I3ISU", TAuId = "au542341", Open = true});
            context.Exercises.Add(new Exercise { ExerciseNumber = 5, Lecture = "EF Core - Migrations", HelpWhere = "opg 2.7", AuId = "au136427", CourseId = "I3ISU", TAuId = "au542413", Open = false});
            context.SaveChanges();
            Console.WriteLine("Data seeded");
        }

        #endregion
    }
}