using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class TeacherAssignmentViewModel
    {
        public int Id { get; set; }
        public string Code_Subject { get; set; } = null!;
        public string Name_Subject { get; set; } = null!;
        public string Name_Group { get; set; } = null!;
        public int Semester { get; set; }
        public string Term { get; set; } = null!;
        public string Turn { get; set; } = null!;
    }
}
