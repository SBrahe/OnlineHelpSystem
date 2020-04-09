using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    class StudentCourse
    {
        public int Semester { get; set; }
        public bool IsActive { get; set; }

        public string AuId { get; set; }
        public Student Student { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }
    }
}
