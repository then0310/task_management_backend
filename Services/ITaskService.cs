using System;
using System.Collections.Generic;
using task_management_application.Models;

namespace task_management_application.Services
{
    public interface ITaskService
    {
        List<ITaskItem> GetTasks();
        ITaskItem AddTask(TaskItem newTask);
        ITaskItem? MarkTaskCompleted(Guid id);
    }
}
