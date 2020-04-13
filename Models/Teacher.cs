using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    class Teacher
    {
        public string TAuId { get; set; }
        public string Name { get; set; }

        public List<Assignment> Assignments { get; set; }
        public List<Exercise> Exercises { get; set; }

        public string CourseId { get; set; }
        public Course Course
        { get; set; }
    }
}
