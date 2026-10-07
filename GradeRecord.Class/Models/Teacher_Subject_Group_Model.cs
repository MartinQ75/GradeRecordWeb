using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class Teacher_Subject_Group_Model:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int Id_Teacher { get; set; }
        public TeacherModel Teacher { get; set; } = null!;
        public int Id_Subject { get; set; }
        public SubjectModel Subject { get; set; } = null!;
        public int Id_Group { get; set; }
        public GroupModel Group { get; set; } = null!;
    }
}
