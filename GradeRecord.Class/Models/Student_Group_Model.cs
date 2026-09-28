using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class Student_Group_Model
    {
        public GroupModel Group { get; set; } = null!;
        public int Id_Group { get; set; }
        public StudentModel Student { get; set; } = null!;
        public int Id_Student { get; set; }
        [Key]
        public int Id_Student_Group { get; set;}

    }
}
