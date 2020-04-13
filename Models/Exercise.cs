using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    class Exercise
    {
        public int ExerciseNumber { get; set; }
        public string Lecture { get; set; }
        public string HelpWhere { get; set; }

        public string AuId { get; set; }
        public Student Student { get; set; }

        public string CourseId { get; set; }
        public Course Course
        {
            get; set;
        }

        public string TAuId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
