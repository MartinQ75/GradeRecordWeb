using GradeRecord.Class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class
{
    public interface IStudentRepository : IRepositoryGeneric<StudentModel>
    {
        Task<StudentModel?> GetStudentByUserId(string userId);
        Task<List<KardexModel>> GetKardex(int StudentId);
    }
}
