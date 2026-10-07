using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRecord.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IRepositoryGeneric<SubjectModel> subjectRG;
        private readonly IRepositoryGeneric<GroupModel> groupRG;
        private readonly IRepositoryGeneric<TeacherModel> teacherRG;
        private readonly IRepositoryGeneric<StudentModel> studentRG;

        public AdminController(
            IRepositoryGeneric<SubjectModel> subjectRG,
            IRepositoryGeneric<GroupModel> groupRG,
            IRepositoryGeneric<TeacherModel> teacherRG,
            IRepositoryGeneric<StudentModel> studentRG)
        {
            this.subjectRG = subjectRG;
            this.groupRG = groupRG;
            this.teacherRG = teacherRG;
            this.studentRG = studentRG;
        }

        public async Task<IActionResult> Index()
        {
            var subjects = await subjectRG.GetAll();
            var groups = await groupRG.GetAll();
            var teachers = await teacherRG.GetAll();
            var students = await studentRG.GetAll();

            ViewBag.TotalSubjects = subjects.Count();
            ViewBag.TotalGroups = groups.Count();
            ViewBag.TotalTeachers = teachers.Count();
            ViewBag.TotalStudents = students.Count();

            return View();
        }
    }
}