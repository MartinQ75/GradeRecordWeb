using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class TeacherHomeModel
    {
        public TeacherModel Teacher { get; set; } = null!;
        public List<TeacherAssignmentViewModel> Assignments { get; set; } = new();
    }
}
