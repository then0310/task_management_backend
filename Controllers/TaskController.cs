using Microsoft.AspNetCore.Mvc;
using System;
using task_management_application.Models;
using task_management_application.Services;

[ApiController]
[Route("api/v1/tasks")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult GetTasks()
    {
        return Ok(_taskService.GetTasks());
    }

    [HttpPost]
    public IActionResult AddTask([FromBody] TaskItem newTask)
    {
        var createdTask = _taskService.AddTask(newTask);
        return CreatedAtAction(nameof(GetTasks), new { id = createdTask.Id }, createdTask);
    }

    [HttpPut("{id}")]
    public IActionResult MarkTaskCompleted(Guid id)
    {
        var updatedTask = _taskService.MarkTaskCompleted(id);
        if (updatedTask == null)
            return NotFound();

        return Ok(updatedTask);
    }
}
