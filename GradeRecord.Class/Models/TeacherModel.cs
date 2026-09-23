using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class TeacherModel
    {
        [Key]
        public int Id_Teacher { get; set; }
        public int Number_Employee { get; set; }
        public string Name { get; set; } = null!;
        public string Paternal_Surname { get; set; } = null!;
        public string Maternal_Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; }
        public bool Status { get; set; }

    }
}
