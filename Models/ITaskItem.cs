namespace task_management_application.Models
{
    public interface ITaskItem
    {
        Guid Id { get; set; }
        string Name { get; set; }
        bool IsCompleted { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
