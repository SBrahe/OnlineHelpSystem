using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    class Student
    {
        public string AuId { get; set; }
        public string Name { get; set; }

        public List<Exercise> Exercises { get; set; }
        public List<StudentAssignment>StudentAssignments {get;set;}
        public List<StudentCourse> StudentCourses { get; set; }

    }
}
