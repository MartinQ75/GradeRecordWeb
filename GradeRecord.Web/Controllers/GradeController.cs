using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeRecord.Web.Controllers
{
    public class GradeController : Controller
    {
        private readonly IRepositoryGeneric<GradeModel> gradeRG;
        public GradeController(IRepositoryGeneric<GradeModel> gradeRG)
        {
            this.gradeRG = gradeRG;
        }
        // GET: GradeController
        public async Task<ActionResult> Index()
        {
            var grades = await this.gradeRG.GetAll();
            return View(grades);
        }

        // GET: GradeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GradeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GradeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GradeModel grade)
        {
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }

            if (!ModelState.IsValid)
            {
                return View(grade);
            }
            await gradeRG.Create(grade);
            return RedirectToAction("Index");
        }

        // GET: GradeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var grade = await gradeRG.GetById(id);
            return View(grade);
        }

        // POST: GradeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GradeModel grade)
        {
            await gradeRG.Update(grade);
            return RedirectToAction("Index");
        }

        // GET: GradeController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var grade = await this.gradeRG.GetById(id);
            return View(grade);
        }

        // POST: GradeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(GradeModel grade)
        {
            await gradeRG.Delete(grade.Id);
            return RedirectToAction("Index");
        }
    }
}
