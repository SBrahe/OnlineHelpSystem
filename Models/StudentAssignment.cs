using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    class StudentAssignment
    {
        public string AuId { get; set; }
        public Student Student { get; set; }

        public string AssignmentNumber { get; set; }
        public Assignment Assignment { get; set; }

    }
}
