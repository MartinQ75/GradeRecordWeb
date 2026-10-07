using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GradeRecord.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly UserManager<IdentityUser> userManager;

        public StudentController(IStudentRepository studentRepository,
            UserManager<IdentityUser> userManager)
        {
            this.studentRepository = studentRepository;
            this.userManager = userManager;
        }

        // GET: StudentController
        public async Task<ActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            } 
            var student = await studentRepository.GetStudentByUserId(user.Id); 
            if (student == null) 
            { 
                return NotFound("No se encontró un estudiante relacionado con este usuario."); 
            } 
            var kardex = await studentRepository.GetKardex(student.Id); 
            var model = new StudentHomeModel 
            { 
                Student = student, 
                Kardex = kardex 
            }; 
            return View(model); 
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
            await studentRepository.Create(student);
            return RedirectToAction("Index");
        }

        // GET: StudentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var student = await studentRepository.GetById(id);
            return View(student);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(StudentModel student)
        {
            await studentRepository.Update(student);
            return RedirectToAction("Index");
        }

        // GET: StudentController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var student = await this.studentRepository.GetById(id);
            return View(student);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(StudentModel student)
        {
            await studentRepository.Delete(student.Id);
            return RedirectToAction("Index");
        }
    }
}
