using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class GradeCaptureModel
    {
        public int AssignmentId { get; set; }
        public string Code_Subject { get; set; } = null!;
        public string Name_Subject { get; set; } = null!;
        public string Name_Group { get; set; } = null!;
        public List<StudentGradeViewModel> Students { get; set; } = new();
    }
}
