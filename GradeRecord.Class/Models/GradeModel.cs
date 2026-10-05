using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class GradeModel:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int Unit { get; set; }
        public double Grade { get; set; }
        public int Opportunity { get; set; }
        public DateTime Date_Register { get; set; }
        public StudentModel Student { get; set; }
        public int Id_Student { get; set; }
        public Teacher_Subject_Group_Model Teacher_Subject { get; set; }
        public int Id_Teacher_Subject { get; set; }
    }
}
