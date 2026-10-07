using GradeRecord.Class.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeRecord.Class
{
    public interface ITeacherRepository : IRepositoryGeneric<TeacherModel>
    {
        Task<TeacherModel?> GetTeacherByUserId(string userId);
        Task<List<TeacherAssignmentViewModel>> GetAssignments(int teacherId);
        Task<TeacherClassModel?> GetClass(int assignmentId, int teacherId);
        Task<GradeCaptureModel?> GetCapture(int assignmentId, int teacherId);
        Task SaveGrades(int assignmentId, List<StudentGradeViewModel> students);
    }
}
