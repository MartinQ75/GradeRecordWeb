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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // ==========================================
            // STUDENT -> IDENTITY USER
            // ==========================================
            builder.Entity<StudentModel>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // TEACHER -> IDENTITY USER
            // ==========================================
            builder.Entity<TeacherModel>()
                .HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // STUDENT_GROUP -> STUDENT
            // ==========================================
            builder.Entity<Student_Group_Model>()
                .HasOne(sg => sg.Student)
                .WithMany()
                .HasForeignKey(sg => sg.Id_Student)
                .OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // STUDENT_GROUP -> GROUP
            // ==========================================
            builder.Entity<Student_Group_Model>()
                .HasOne(sg => sg.Group)
                .WithMany()
                .HasForeignKey(sg => sg.Id_Group)
                .OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // TEACHER_SUBJECT_GROUP -> TEACHER
            // ==========================================
            builder.Entity<Teacher_Subject_Group_Model>()
                .HasOne(tsg => tsg.Teacher)
                .WithMany()
                .HasForeignKey(tsg => tsg.Id_Teacher)
                .OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // TEACHER_SUBJECT_GROUP -> SUBJECT
            // ==========================================
            builder.Entity<Teacher_Subject_Group_Model>()
                .HasOne(tsg => tsg.Subject)
                .WithMany()
                .HasForeignKey(tsg => tsg.Id_Subject)
                .OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // TEACHER_SUBJECT_GROUP -> GROUP
            // ==========================================
            builder.Entity<Teacher_Subject_Group_Model>()
                .HasOne(tsg => tsg.Group)
                .WithMany()
                .HasForeignKey(tsg => tsg.Id_Group)
                .OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // GRADE -> STUDENT
            // ==========================================
            builder.Entity<GradeModel>()
                .HasOne(g => g.Student)
                .WithMany()
                .HasForeignKey(g => g.Id_Student)
                .OnDelete(DeleteBehavior.Restrict);

            // ==========================================
            // GRADE -> TEACHER_SUBJECT_GROUP
            // ==========================================
            builder.Entity<GradeModel>()
                .HasOne(g => g.Teacher_Subject)
                .WithMany()
                .HasForeignKey(g => g.Id_Teacher_Subject)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
