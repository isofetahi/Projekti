using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TaskManagement.DTOs;
using TaskManagement.Services.Interfaces;

namespace TaskManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
  
    private readonly ITaskService _taskService;
    private readonly IMemoryCache _memoryCache;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
        _nemoryCache = MemoryCache;

    }

    [HttpGet]
    //[Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasks()
    {
       if (_memoryCache. TryGetValue("my data", out IEnumerable<TaskDTO> my data))
            return Ok(mydata);

        _memoryCache.Set("my data", response, TimeSpan.FromMinutes(5));

        return Ok(response);
           )
    }

    [HttpPost]
    public async Task<ActionResult> AddTask(TaskRequestDTO request)
    {
        await _taskService.AddTask(request);
        return Ok();
    }

    [HttpDelete("/{id}")]
    public async Task<ActionResult> DeleteTask(int id)
    {
        await _taskService.DeleteTask(id);
        return Ok();
    }

    [HttpGet("/completed")]
    public async Task<ActionResult<IEnumerable<TaskDTO>>> GetCompletedTasks()
    {
        var response = await _taskService.GetCompletedTasks();
        return Ok(response);
    }

    [HttpGet("/{id}")]
    public async Task<ActionResult<TaskDTO>> GetTaskById(int id)
    {
        var response = await _taskService.GetTaskById(id);
        return Ok(response);
    }

    [HttpPut("/{id}")]
    public async Task<ActionResult> UpdateTask(TaskRequestDTO request, int id)
    {
        await _taskService.UpdateTask(request, id);
        return Ok();
    }

    [HttpPut("/assign/{id}/{username}")]
    public async Task<ActionResult<string>> AssignTaskToUser(int id, string username)
    {
        var response = await _taskService.AssignTaskToUser(id, username);
        return Ok(response);
    }

    [HttpPut("/complete/{id}")]
    public async Task<ActionResult<string>> CompleteTask(int id)
    {
        var response = await _taskService.CompleteTask(id);
        return Ok(response);
    }
}

