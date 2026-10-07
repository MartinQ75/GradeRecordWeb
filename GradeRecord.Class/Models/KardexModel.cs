using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class KardexModel
    {
        public string Code_Subject { get; set; } = null!;
        public string Name_Subject { get; set; } = null!;
        public int Group { get; set; }
        public List<GradeModel> Grades { get; set; } = new();
    }
}
