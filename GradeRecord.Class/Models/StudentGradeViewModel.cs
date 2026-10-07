using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class StudentGradeViewModel
    {
        public int StudentId { get; set; }
        public string Enrollment { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public double? Unit1 { get; set; }
        public double? Unit2 { get; set; }
        public double? Unit3 { get; set; }
    }
}
