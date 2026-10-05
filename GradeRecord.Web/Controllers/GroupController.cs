using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradeRecord.Web.Controllers
{
    public class GroupController : Controller
    {
        private readonly IRepositoryGeneric<GroupModel> groupRG;
        public GroupController(IRepositoryGeneric<GroupModel> groupRG)
        {
            this.groupRG = groupRG;
        }
        // GET: GroupController
        public async Task<ActionResult> Index()
        {
            var groups = await this.groupRG.GetAll();
            return View(groups);
        }

        // GET: GroupController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GroupController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(GroupModel group)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (!ModelState.IsValid)
            {
                return View(group);
            }
            await groupRG.Create(group);
            return RedirectToAction("Index");
        }

        // GET: GroupController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var group = await groupRG.GetById(id);
            return View(group);
        }

        // POST: GroupController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(GroupModel group)
        {
            await groupRG.Update(group);
            return RedirectToAction("Index");
        }

        // GET: GroupController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var group = await this.groupRG.GetById(id);
            return View(group);
        }

        // POST: GroupController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(GroupModel group)
        {
            await groupRG.Delete(group.Id);
            return RedirectToAction("Index");
        }
    }
}
