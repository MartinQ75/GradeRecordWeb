using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class SubjectModel
    {
        public int Id_Subject { get; set; }
        public string Code_Subject { get; set; }
        public string Name_Subject { get; set; }
        public int Credits { get; set; }
        public int Semester { get; set; }
        public int Units { get; set; }
        public bool Status { get; set; }
    }
}
