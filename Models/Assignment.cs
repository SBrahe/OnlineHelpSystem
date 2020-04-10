using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    class Assignment
    {
        public int AssignmentNumber { get; set; }
        public string HelpWhere { get; set; }

        public List<StudentAssignment> StudentAssignments { get; set; }
    }
}
