namespace task_management_application.Models
{
    public class TaskItem : ITaskItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}
