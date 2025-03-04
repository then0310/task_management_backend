using System;
using System.Collections.Generic;
using System.Linq;
using task_management_application.Models;

namespace task_management_application.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<ITaskItem> tasks = new();

        public List<ITaskItem> GetTasks()
        {
            return tasks;
        }

        public ITaskItem AddTask(TaskItem newTask)
        {
            newTask.Id = Guid.NewGuid();
            newTask.CreatedAt = DateTime.UtcNow;
            tasks.Add(newTask);
            return newTask; 
        }

        public ITaskItem? MarkTaskCompleted(Guid id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
            return task;
        }
    }
}
