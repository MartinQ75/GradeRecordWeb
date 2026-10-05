using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeRecord.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IRepositoryGeneric<StudentModel> studentRG;
        public StudentController(IRepositoryGeneric<StudentModel> studentRG)
        {
            this.studentRG = studentRG;
        }
        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            var students = await this.studentRG.GetAll();
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentModel student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            if (!ModelState.IsValid)
            {
                return View(student);
            }
            await studentRG.Create(student);
            return RedirectToAction("Index");
        }

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var student = await studentRG.GetById(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StudentModel student)
        {
            await studentRG.Update(student);
            return RedirectToAction("Index");
        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var student = await this.studentRG.GetById(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(StudentModel student)
        {
            await studentRG.Delete(student.Id);
            return RedirectToAction("Index");
        }
    }
}
