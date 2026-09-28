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
        public GradeRecordDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<GradeModel> Grades { get; set; }
        public DbSet<GroupModel> Groups { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<Student_Group_Model> Students_Groups { get; set; }
        public DbSet<Teacher_Subject_Group_Model> Teachers_Subjects { get; set; }
    }
}
