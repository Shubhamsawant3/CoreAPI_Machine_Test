using CoreAPI_Machine_Test.Data;
using CoreAPI_Machine_Test.Models;

namespace CoreAPI_Machine_Test.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskDbContext _context;

        public TaskService(TaskDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskItem> GetAllTasks(string? status, DateTime? dueDate, int page, int pageSize)
        {
            var query = _context.Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(status) && Enum.TryParse(status, true, out Models.TaskStatus taskStatus))
            {
                query = query.Where(t => t.Status == taskStatus);
            }

            if (dueDate.HasValue)
            {
                query = query.Where(t => t.DueDate <= dueDate.Value);
            }

            return query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public TaskItem? GetTaskById(int id) => _context.Tasks.Find(id);

        public TaskItem CreateTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public TaskItem? UpdateTask(int id, TaskItem task)
        {
            var existingTask = _context.Tasks.Find(id);
            if (existingTask == null) return null;

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.Status = task.Status;
            existingTask.DueDate = task.DueDate;

            _context.SaveChanges();
            return existingTask;
        }

        public bool DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return true;
        }
    }
}