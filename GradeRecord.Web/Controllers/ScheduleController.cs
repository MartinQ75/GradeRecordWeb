using GradeRecord.Class;
using GradeRecord.Class.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GradeRecord.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ScheduleController : Controller
    {
        private readonly IRepositoryGeneric<ScheduleModel> scheduleRG;

        public ScheduleController(IRepositoryGeneric<ScheduleModel> scheduleRG)
        {
            this.scheduleRG = scheduleRG;
        }

        public async Task<IActionResult> Index()
        {
            var schedules = await scheduleRG.GetAll();
            return View(schedules);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleModel schedule)
        {
            ModelState.Remove(nameof(ScheduleModel.Teacher_Subject));

            if (!ModelState.IsValid)
            {
                return View(schedule);
            }

            await scheduleRG.Create(schedule);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var schedule = await scheduleRG.GetById(id);
            if (schedule == null) return NotFound();
            return View(schedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ScheduleModel schedule)
        {
            ModelState.Remove(nameof(ScheduleModel.Teacher_Subject));

            if (!ModelState.IsValid)
            {
                return View(schedule);
            }

            await scheduleRG.Update(schedule);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var schedule = await scheduleRG.GetById(id);
            if (schedule == null) return NotFound();
            return View(schedule);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await scheduleRG.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}