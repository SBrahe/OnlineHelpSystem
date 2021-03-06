﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    class Assignment
    {
        public string AssignmentNumber { get; set; }
        public bool Open { get; set; }
        public string HelpWhere { get; set; }

        public List<StudentAssignment> StudentAssignments { get; set; }
        public string CourseId { get; set; }
        public Course Course { get; set; }

        public string TAuId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
