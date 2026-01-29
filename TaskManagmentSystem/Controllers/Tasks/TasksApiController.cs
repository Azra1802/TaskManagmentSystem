using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.Services.Task;

namespace TaskManagementSystem.Controllers.Tasks
{

    [ApiController]
    [Route("api/tasks")]
    public class TasksApiController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksApiController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAll()
            => Ok(_taskService.GetAllTasks());

        [HttpPost]
        public IActionResult Create(TaskCreateVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _taskService.CreateTask(model);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskEditVM model)
        {
            if (id != model.Id)
                return BadRequest();

            if (!_taskService.UpdateTask(model))
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_taskService.DeleteTask(id))
                return NotFound();

            return Ok();
        }
    }
}
