using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class StudentModel
    {
        public int IdStudent { get; set; }
        public string Enrollment { get; set; }
        public string StudentName { get; set; }
        public string Paternal_Surname { get; set; }
        public string Maternal_Surname { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}
