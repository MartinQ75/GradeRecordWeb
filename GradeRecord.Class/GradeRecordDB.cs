using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class
{
    public class GradeRecordDB:IdentityDbContext<IdentityUser>
    {
        public DbSet<GroupsModel> Groups { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<Student_Group_Model> Student_Group_Models { get; set; }


    }
}
