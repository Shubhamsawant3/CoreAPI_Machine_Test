using CoreAPI_Machine_Test.Models;

namespace CoreAPI_Machine_Test.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskItem> GetAllTasks(string? status, DateTime? dueDate, int page, int pageSize);
        TaskItem? GetTaskById(int id);
        TaskItem CreateTask(TaskItem task);
        TaskItem? UpdateTask(int id, TaskItem task);
        bool DeleteTask(int id);
    }
}
