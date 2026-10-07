using GradeRecord.Class.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class
{
    public class TeacherRepository : RepositoryGeneric<TeacherModel>, ITeacherRepository
    {
        private readonly GradeRecordDB db;

        public TeacherRepository(GradeRecordDB db) : base(db) 
        {
            this.db = db;
        }

        public async Task<TeacherModel?> GetTeacherByUserId(string userId)
        {
            return await db.Teachers
                .FirstOrDefaultAsync(t => t.UserId == userId);
        }

        public async Task<List<TeacherAssignmentViewModel>> GetAssignments(int teacherId)
        {
            return await db.Teachers_Subjects
                .Where(ts => ts.Id_Teacher == teacherId)
                .Include(ts => ts.Subject)
                .Include(ts => ts.Group)
                .Select(ts => new TeacherAssignmentViewModel
                {
                    Id = ts.Id,

                    Code_Subject = ts.Subject.Code_Subject,

                    Name_Subject = ts.Subject.Name_Subject,

                    Name_Group = ts.Group.Name_Group,

                    Semester = ts.Group.Semester,

                    Term = ts.Group.Term,

                    Turn = ts.Group.Turn
                })
                .ToListAsync();
        }

        public async Task<TeacherClassModel?> GetClass(
            int assignmentId,
            int teacherId)
        {
            var assignment = await db.Teachers_Subjects
                .Where(ts =>
                    ts.Id == assignmentId &&
                    ts.Id_Teacher == teacherId)
                .Include(ts => ts.Subject)
                .Include(ts => ts.Group)
                .FirstOrDefaultAsync();

            if (assignment == null)
            {
                return null;
            }

            var students = await db.Students_Groups
                .Where(sg => sg.Id_Group == assignment.Id_Group)
                .Include(sg => sg.Student)
                .Select(sg => sg.Student)
                .ToListAsync();

            return new TeacherClassModel
            {
                AssignmentId = assignment.Id,

                Code_Subject = assignment.Subject.Code_Subject,

                Name_Subject = assignment.Subject.Name_Subject,

                Name_Group = assignment.Group.Name_Group,

                Semester = assignment.Group.Semester,

                Term = assignment.Group.Term,

                Turn = assignment.Group.Turn,

                Students = students
            };
        }

        public async Task<GradeCaptureModel?> GetCapture(
    int assignmentId,
    int teacherId)
        {
            var assignment = await db.Teachers_Subjects
                .Where(ts =>
                    ts.Id == assignmentId &&
                    ts.Id_Teacher == teacherId)
                .Include(ts => ts.Subject)
                .Include(ts => ts.Group)
                .FirstOrDefaultAsync();

            if (assignment == null)
            {
                return null;
            }

            var students = await db.Students_Groups
                .Where(sg => sg.Id_Group == assignment.Id_Group)
                .Include(sg => sg.Student)
                .Select(sg => sg.Student)
                .ToListAsync();

            var studentIds = students
                .Select(s => s.Id)
                .ToList();

            var grades = await db.Grades
                .Where(g =>
                    g.Id_Teacher_Subject == assignmentId &&
                    studentIds.Contains(g.Id_Student))
                .ToListAsync();

            var studentGrades = students
                .Select(student => new StudentGradeViewModel
                {
                    StudentId = student.Id,

                    Enrollment = student.Enrollment,

                    StudentName =
                        student.StudentName + " " +
                        student.Paternal_Surname + " " +
                        student.Maternal_Surname,

                    Unit1 = grades
                        .Where(g =>
                            g.Id_Student == student.Id &&
                            g.Unit == 1)
                        .Select(g => (double?)g.Grade)
                        .FirstOrDefault(),

                    Unit2 = grades
                        .Where(g =>
                            g.Id_Student == student.Id &&
                            g.Unit == 2)
                        .Select(g => (double?)g.Grade)
                        .FirstOrDefault(),

                    Unit3 = grades
                        .Where(g =>
                            g.Id_Student == student.Id &&
                            g.Unit == 3)
                        .Select(g => (double?)g.Grade)
                        .FirstOrDefault()
                })
                .ToList();

            return new GradeCaptureModel
            {
                AssignmentId = assignment.Id,

                Code_Subject = assignment.Subject.Code_Subject,

                Name_Subject = assignment.Subject.Name_Subject,

                Name_Group = assignment.Group.Name_Group,

                Students = studentGrades
            };
        }

        public async Task SaveGrades(
    int assignmentId,
    List<StudentGradeViewModel> students)
        {
            var existingGrades = await db.Grades
                .Where(g => g.Id_Teacher_Subject == assignmentId)
                .ToListAsync();

            foreach (var student in students)
            {
                if (student.Unit1.HasValue)
                {
                    var grade = existingGrades.FirstOrDefault(g =>
                        g.Id_Student == student.StudentId &&
                        g.Unit == 1);

                    if (grade == null)
                    {
                        grade = new GradeModel
                        {
                            Id_Student = student.StudentId,
                            Id_Teacher_Subject = assignmentId,
                            Unit = 1,
                            Grade = student.Unit1.Value,
                            Opportunity = 1,
                            Date_Register = DateTime.Now
                        };

                        db.Grades.Add(grade);
                    }
                    else
                    {
                        grade.Grade = student.Unit1.Value;
                        grade.Date_Register = DateTime.Now;
                    }
                }

                if (student.Unit2.HasValue)
                {
                    var grade = existingGrades.FirstOrDefault(g =>
                        g.Id_Student == student.StudentId &&
                        g.Unit == 2);

                    if (grade == null)
                    {
                        grade = new GradeModel
                        {
                            Id_Student = student.StudentId,
                            Id_Teacher_Subject = assignmentId,
                            Unit = 2,
                            Grade = student.Unit2.Value,
                            Opportunity = 1,
                            Date_Register = DateTime.Now
                        };

                        db.Grades.Add(grade);
                    }
                    else
                    {
                        grade.Grade = student.Unit2.Value;
                        grade.Date_Register = DateTime.Now;
                    }
                }

                if (student.Unit3.HasValue)
                {
                    var grade = existingGrades.FirstOrDefault(g =>
                        g.Id_Student == student.StudentId &&
                        g.Unit == 3);

                    if (grade == null)
                    {
                        grade = new GradeModel
                        {
                            Id_Student = student.StudentId,
                            Id_Teacher_Subject = assignmentId,
                            Unit = 3,
                            Grade = student.Unit3.Value,
                            Opportunity = 1,
                            Date_Register = DateTime.Now
                        };

                        db.Grades.Add(grade);
                    }
                    else
                    {
                        grade.Grade = student.Unit3.Value;
                        grade.Date_Register = DateTime.Now;
                    }
                }
            }

            await db.SaveChangesAsync();
        }
    }
}
