using Microsoft.VisualBasic;

namespace CoreAPI_Machine_Test.Models
{
    public enum TaskStatus
    {
        Pending = 0,
        InProgress = 1,
        Completed = 2
    }
    public class TaskItem
    {
        public int Id { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
        public DateTime DueDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string StatusString => Status.ToString();
    }
}
