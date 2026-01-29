using TaskManagementSystem.Models;
using TaskStatus = TaskManagementSystem.Models.TaskStatus;


namespace TaskManagementSystem.Services.Task
{
    public class TaskService : ITaskService
    {
       
        private readonly Dictionary<int, TaskModel> _tasks = new();
        private int idCounter = 0;

        public TaskService()
        {
            
            CreateTask(new TaskCreateVM
            {
                Title = "Task Example",
                Description = "Description example",
                Priority = TaskPriority.Medium,
                DueDate = DateTime.UtcNow.AddDays(3)
            });
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _tasks.Values;
        }

        public TaskEditVM? GetTaskById(int id)
        {
            if (!_tasks.TryGetValue(id, out var task))
                return null;

            return new TaskEditVM
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                DueDate = task.DueDate
            };
        }

        public void CreateTask(TaskCreateVM taskVM)
        {
            idCounter++;
            var task = new TaskModel
            {
                Id = idCounter,
                Title = taskVM.Title,
                Description = taskVM.Description,
                Priority = taskVM.Priority,
                Status = TaskStatus.ToDo,
                CreatedAt = DateTime.UtcNow,
                DueDate = taskVM.DueDate
            };

            _tasks.Add(task.Id, task);
        }

        public bool UpdateTask(TaskEditVM taskVM)
        {
            if (!_tasks.TryGetValue(taskVM.Id, out var task))
                return false;

            task.Title = taskVM.Title;
            task.Description = taskVM.Description;
            task.Status = taskVM.Status;
            task.Priority = taskVM.Priority;
            task.DueDate = taskVM.DueDate;

            return true;
        }

        public bool DeleteTask(int id)
        {
            return _tasks.Remove(id);
        }
    }
}
