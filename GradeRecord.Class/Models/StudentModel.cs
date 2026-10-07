using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class.Models
{
    public class StudentModel:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Enrollment { get; set; }
        public string StudentName { get; set; }
        public string Paternal_Surname { get; set; }
        public string Maternal_Surname { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
    }
}
