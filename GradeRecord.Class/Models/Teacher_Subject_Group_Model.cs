using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class Teacher_Subject_Group_Model
    {
        [Key]
        public int Id_Teacher_Subject { get; set; }
        public TeacherModel Teacher { get; set; }
        public int Id_Teacher { get; set; }
        public SubjectModel Subject { get; set; }
        public int Id_Subject { get; set; }
        public GroupModel Group {  get; set; }
        public int Id_Group { get; set; }
    }
}
