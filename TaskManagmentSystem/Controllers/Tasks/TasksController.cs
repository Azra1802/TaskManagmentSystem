using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services.Task;

namespace TaskManagementSystem.Controllers.Tasks
{

    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var tasks = _taskService.GetAllTasks();
            return View(tasks);
        }

        public IActionResult EditModal(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
                return NotFound();

            return PartialView("_EditTaskModal", task);
        }

        public IActionResult TaskTable()
        {
            var tasks = _taskService.GetAllTasks();
            return PartialView("_TaskTableRows", tasks);
        }

    }
}
