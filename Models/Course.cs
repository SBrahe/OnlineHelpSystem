using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; }

        public List<Assignment> Assignments { get; set; }
        public List<Exercise> Exercises { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
