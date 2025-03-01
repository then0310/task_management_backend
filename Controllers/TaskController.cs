using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using task_management_application.Models;

[ApiController]
[Route("api/v1/tasks")]
public class TaskController : ControllerBase
{
    private static readonly List<ITaskItem> tasks = new();

    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(tasks);
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] TaskItem newTask)
    {
        newTask.Id = Guid.NewGuid();
        tasks.Add(newTask);
        return CreatedAtAction(nameof(GetTasks), new { id = newTask.Id }, newTask);
    }

    [HttpPut("{id}")]
    public IActionResult MarkTaskCompleted(Guid id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return NotFound();

        task.IsCompleted = true;
        return Ok(task);
    }
}
