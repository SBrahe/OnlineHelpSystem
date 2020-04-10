using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    class HelpRequest
    {
        public string AuId { get; set; }
        public Student Student { get; set; }

        public int AssignmentNumber { get; set; }
        public Assignment assignment { get; set; }

    }
}
