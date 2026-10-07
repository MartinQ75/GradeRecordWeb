using GradeRecord.Class.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class
{
    public class StudentRepository : RepositoryGeneric<StudentModel>, IStudentRepository
    {
        private readonly GradeRecordDB db;

        public StudentRepository(GradeRecordDB db) : base(db)
        {
            this.db = db;
        }

        public async Task<StudentModel?> GetStudentByUserId(string userId)
        {
            return await db.Students.FirstOrDefaultAsync(s => s.UserId == userId);
        }

        public async Task<List<KardexModel>> GetKardex(int studentId)
        {
            var grades = await db.Grades
                .Where(g => g.Id_Student == studentId)
                .Include(g => g.Teacher_Subject)
                    .ThenInclude(ts => ts.Subject)
                .ToListAsync();

            var kardex = grades
                .GroupBy(g => g.Id_Teacher_Subject)
                .Select(g => new KardexModel
                {
                    Code_Subject = g.First().Teacher_Subject.Subject.Code_Subject,
                    Name_Subject = g.First().Teacher_Subject.Subject.Name_Subject,
                    Grades = g.ToList()
                })
                .ToList();

            return kardex;
        }
    }
}
