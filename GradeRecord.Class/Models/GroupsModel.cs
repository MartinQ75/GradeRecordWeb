using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class GroupsModel
    {
        public int Id_Group { get; set; }
        public string Name_Group { get; set; }
        public int Semester {  get; set; }
        public string Term { get; set; }
        public string Turn { get; set; }
        public bool Status { get; set; }
    }
}
