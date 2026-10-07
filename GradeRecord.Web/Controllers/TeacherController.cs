using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GradeRecord.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository teacherRG;
        private readonly UserManager<IdentityUser> userManager;
        public TeacherController(ITeacherRepository teacherRG,
            UserManager<IdentityUser> userManager)
        {
            this.teacherRG = teacherRG;
            this.userManager = userManager;
        }

        // GET: TeacherController
        public async Task<ActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var teacher =
                await teacherRG.GetTeacherByUserId(user.Id);

            if (teacher == null)
            {
                return NotFound(
                    "No se encontró un maestro relacionado con este usuario.");
            }

            var assignments =
                await teacherRG.GetAssignments(teacher.Id);

            var model = new TeacherHomeModel
            {
                Teacher = teacher,
                Assignments = assignments
            };

            return View(model);
        }

        public async Task<ActionResult> Class(int id)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var teacher =
                await teacherRG.GetTeacherByUserId(user.Id);

            if (teacher == null)
            {
                return NotFound(
                    "No se encontró un maestro relacionado con este usuario.");
            }

            var model =
                await teacherRG.GetClass(id, teacher.Id);

            if (model == null)
            {
                return NotFound(
                    "La materia o grupo no existe o no pertenece a este maestro.");
            }

            return View(model);
        }

        public async Task<ActionResult> Grades(int id)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var teacher =
                await teacherRG.GetTeacherByUserId(user.Id);

            if (teacher == null)
            {
                return NotFound(
                    "No se encontró un maestro relacionado con este usuario.");
            }

            var model =
                await teacherRG.GetCapture(id, teacher.Id);

            if (model == null)
            {
                return NotFound(
                    "La materia o grupo no existe o no pertenece a este maestro.");
            }

            return View(model);
        }

        // POST TeacherController
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveGrades(GradeCaptureModel model)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var teacher =
                await teacherRG.GetTeacherByUserId(user.Id);

            if (teacher == null)
            {
                return NotFound(
                    "No se encontró un maestro relacionado con este usuario.");
            }

            var assignment =
                await teacherRG.GetClass(
                    model.AssignmentId,
                    teacher.Id);

            if (assignment == null)
            {
                return NotFound(
                    "La materia o grupo no existe o no pertenece a este maestro.");
            }

            if (model.Students == null || model.Students.Count == 0)
            {
                ModelState.AddModelError(
                    "",
                    "No hay alumnos para guardar.");
            }

            foreach (var student in model.Students)
            {
                if (student.Unit1.HasValue &&
                    (student.Unit1.Value < 0 || student.Unit1.Value > 100))
                {
                    ModelState.AddModelError(
                        "",
                        $"La calificación de Unidad 1 del alumno {student.Enrollment} debe estar entre 0 y 100.");
                }

                if (student.Unit2.HasValue &&
                    (student.Unit2.Value < 0 || student.Unit2.Value > 100))
                {
                    ModelState.AddModelError(
                        "",
                        $"La calificación de Unidad 2 del alumno {student.Enrollment} debe estar entre 0 y 100.");
                }

                if (student.Unit3.HasValue &&
                    (student.Unit3.Value < 0 || student.Unit3.Value > 100))
                {
                    ModelState.AddModelError(
                        "",
                        $"La calificación de Unidad 3 del alumno {student.Enrollment} debe estar entre 0 y 100.");
                }
            }

            if (!ModelState.IsValid)
            {
                return View("Grades", model);
            }

            await teacherRG.SaveGrades(
                model.AssignmentId,
                model.Students);

            TempData["SuccessMessage"] =
                "Las calificaciones se guardaron correctamente.";

            return RedirectToAction(
                "Grades",
                new { id = model.AssignmentId });
        }

        // GET: TeacherController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TeacherController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TeacherController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeacherModel teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
            await teacherRG.Create(teacher);
            return RedirectToAction("Index");
        }

        // GET: TeacherController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var teacher = await teacherRG.GetById(id);
            return View(teacher);
        }

        // POST: TeacherController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TeacherModel teacher)
        {
            await teacherRG.Update(teacher);
            return RedirectToAction("Index");
        }

        // GET: TeacherController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var teacher = await this.teacherRG.GetById(id);
            return View(teacher);
        }

        // POST: TeacherController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(TeacherModel teacher)
        {
            await teacherRG.Delete(teacher.Id);
            return RedirectToAction("Index");
        }
    }
}
