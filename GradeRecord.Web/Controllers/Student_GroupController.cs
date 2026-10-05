using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRecord.Web.Controllers
{
    public class StudentGroupController : Controller
    {
        private readonly IRepositoryGeneric<Student_Group_Model> studentGroupRG;

        public StudentGroupController(IRepositoryGeneric<Student_Group_Model> studentGroupRG)
        {
            this.studentGroupRG = studentGroupRG;
        }

        [Authorize(Roles = "Admin, Teacher, Trainee")]
        // GET: StudentGroup
        public async Task<IActionResult> Index()
        {
            var lstSG = await studentGroupRG.GetAll();
            return View(lstSG.AsEnumerable());
        }

        [Authorize(Roles = "Admin")]
        // GET: StudentGroup/Create
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: StudentGroup/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student_Group_Model studentGroup)
        {
            ModelState.Remove(nameof(Student_Group_Model.Student));
            ModelState.Remove(nameof(Student_Group_Model.Group));

            var all = await studentGroupRG.GetAll();
            if (all.Any(x => x.Id_Student == studentGroup.Id_Student
                          && x.Id_Group == studentGroup.Id_Group))
            {
                ModelState.AddModelError("", "This student is already in that group.");
            }

            if (!ModelState.IsValid)
            {
                return View(studentGroup);
            }

            await studentGroupRG.Create(studentGroup);
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentGroup/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var studentGroup = await studentGroupRG.GetById(id);
            if (studentGroup == null) return NotFound();

            return View(studentGroup);
        }

        // POST: StudentGroup/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student_Group_Model studentGroup)
        {
            ModelState.Remove(nameof(Student_Group_Model.Student));
            ModelState.Remove(nameof(Student_Group_Model.Group));

            var all = await studentGroupRG.GetAll();
            if (all.Any(x => x.Id_Student == studentGroup.Id_Student
                          && x.Id_Group == studentGroup.Id_Group
                          && x.Id != studentGroup.Id))
            {
                ModelState.AddModelError("", "This student is already in that group.");
            }

            if (!ModelState.IsValid)
            {
                return View(studentGroup);
            }

            await studentGroupRG.Update(studentGroup);
            return RedirectToAction(nameof(Index));
        }

        // GET: StudentGroup/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var studentGroup = await studentGroupRG.GetById(id);
            if (studentGroup == null) return NotFound();

            return View(studentGroup);
        }

        // POST: StudentGroup/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await studentGroupRG.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}