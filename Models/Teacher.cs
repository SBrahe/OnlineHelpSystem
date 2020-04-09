using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineHelpSystem.Models
{
    class Teacher
    {
        public string AuId { get; set; }
        public string Name { get; set; }

        public List<Assignment> Assignements { get; set; }
        public List<Exercise>Exercises { get; set; }
    }
}
