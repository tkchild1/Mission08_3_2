using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission08_3_2.Models;

namespace Mission08_3_2.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repo;

        public TaskController(ITaskRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tasks = _repo.Tasks
                .Where(t => !t.Completed)
                .OrderBy(t => t.Quadrant)
                .ThenBy(t => t.DueDate)
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            PopulateCategories();
            return View("AddEditTask", new TaskItem());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTask(TaskItem task)
        {
            if (!ModelState.IsValid)
            {
                PopulateCategories();
                return View("AddEditTask", task);
            }

            _repo.AddTask(task);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskItemId == id);
            if (task == null)
            {
                return NotFound();
            }

            PopulateCategories();
            return View("AddEditTask", task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTask(TaskItem task)
        {
            if (!ModelState.IsValid)
            {
                PopulateCategories();
                return View("AddEditTask", task);
            }

            _repo.UpdateTask(task);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTask(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskItemId == id);
            if (task != null)
            {
                _repo.DeleteTask(task);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MarkComplete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskItemId == id);
            if (task != null)
            {
                task.Completed = true;
                _repo.UpdateTask(task);
            }

            return RedirectToAction(nameof(Index));
        }

        private void PopulateCategories()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                })
                .ToList();
        }
    }
}
