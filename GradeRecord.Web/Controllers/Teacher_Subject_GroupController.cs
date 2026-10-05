using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRecord.Web.Controllers
{
    public class TeacherSubjectGroupController : Controller
    {
        private readonly IRepositoryGeneric<Teacher_Subject_Group_Model> teacherSubjectGroupRG;

        public TeacherSubjectGroupController(IRepositoryGeneric<Teacher_Subject_Group_Model> teacherSubjectGroupRG)
        {
            this.teacherSubjectGroupRG = teacherSubjectGroupRG;
        }

        [Authorize(Roles = "Admin, Teacher, Trainee")]
        // GET: TeacherSubjectGroup
        public async Task<IActionResult> Index()
        {
            var lstTSG = await teacherSubjectGroupRG.GetAll();
            return View(lstTSG.AsEnumerable());
        }

        [Authorize(Roles = "Admin")]
        // GET: TeacherSubjectGroup/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: TeacherSubjectGroup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Teacher_Subject_Group_Model teacherSubjectGroup)
        {
            ModelState.Remove(nameof(Teacher_Subject_Group_Model.Teacher));
            ModelState.Remove(nameof(Teacher_Subject_Group_Model.Subject));
            ModelState.Remove(nameof(Teacher_Subject_Group_Model.Group));

            var all = await teacherSubjectGroupRG.GetAll();
            if (all.Any(x => x.Id_Teacher == teacherSubjectGroup.Id_Teacher
                          && x.Id_Subject == teacherSubjectGroup.Id_Subject
                          && x.Id_Group == teacherSubjectGroup.Id_Group))
            {
                ModelState.AddModelError("", "This teacher already has that subject in that group.");
            }

            if (!ModelState.IsValid)
            {
                return View(teacherSubjectGroup);
            }

            await teacherSubjectGroupRG.Create(teacherSubjectGroup);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        // GET: TeacherSubjectGroup/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var teacherSubjectGroup = await teacherSubjectGroupRG.GetById(id);
            if (teacherSubjectGroup == null) return NotFound();

            return View(teacherSubjectGroup);
        }

        [Authorize(Roles = "Admin")]
        // POST: TeacherSubjectGroup/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Teacher_Subject_Group_Model teacherSubjectGroup)
        {
            ModelState.Remove(nameof(Teacher_Subject_Group_Model.Teacher));
            ModelState.Remove(nameof(Teacher_Subject_Group_Model.Subject));
            ModelState.Remove(nameof(Teacher_Subject_Group_Model.Group));

            var all = await teacherSubjectGroupRG.GetAll();
            if (all.Any(x => x.Id_Teacher == teacherSubjectGroup.Id_Teacher
                          && x.Id_Subject == teacherSubjectGroup.Id_Subject
                          && x.Id_Group == teacherSubjectGroup.Id_Group
                          && x.Id != teacherSubjectGroup.Id))
            {
                ModelState.AddModelError("", "This teacher already has that subject in that group.");
            }

            if (!ModelState.IsValid)
            {
                return View(teacherSubjectGroup);
            }

            await teacherSubjectGroupRG.Update(teacherSubjectGroup);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        // GET: TeacherSubjectGroup/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var teacherSubjectGroup = await teacherSubjectGroupRG.GetById(id);
            if (teacherSubjectGroup == null) return NotFound();

            return View(teacherSubjectGroup);
        }

        [Authorize(Roles = "Admin")]
        // POST: TeacherSubjectGroup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await teacherSubjectGroupRG.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}