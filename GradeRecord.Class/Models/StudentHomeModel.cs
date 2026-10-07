using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class StudentHomeModel
    {
        public StudentModel Student { get; set; } = null!;
        public List<KardexModel> Kardex { get; set; } = new();
    }
}
