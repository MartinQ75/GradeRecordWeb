using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeRecord.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IRepositoryGeneric<SubjectModel> subjectRG;
        public SubjectController(IRepositoryGeneric<SubjectModel> subjectRG)
        {
            this.subjectRG = subjectRG;
        }
        // GET: SubjectController
        public async Task<ActionResult> Index()
        {
            var subjects = await this.subjectRG.GetAll();
            return View(subjects);
        }

        // GET: SubjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SubjectModel subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            if (!ModelState.IsValid)
            {
                return View(subject);
            }
            await subjectRG.Create(subject);
            return RedirectToAction("Index");
        }

        // GET: SubjectController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var subject = await subjectRG.GetById(id);
            return View(subject);
        }

        // POST: SubjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(SubjectModel subject)
        {
            await subjectRG.Update(subject);
            return RedirectToAction("Index");
        }

        // GET: SubjectController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var subject = await this.subjectRG.GetById(id);
            return View(subject);
        }

        // POST: SubjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(SubjectModel subject)
        {
            await subjectRG.Delete(subject.Id);
            return RedirectToAction("Index");
        }
    }
}
