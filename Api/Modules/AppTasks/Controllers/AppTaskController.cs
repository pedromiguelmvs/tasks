using Api.Common.NotFoundException;
using Api.Common.Paginator;
using Api.Modules.AppTasks;
using Api.Modules.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/tasks")]
public class TasksController(IAppTaskService appTasksService) : ControllerBase
{
    private readonly IAppTaskService _appTasksService = appTasksService;

    [HttpGet]
    public async Task<ActionResult<PaginationResult<AppTaskDto>>> GetAll()
    {
        var userId = HttpContext.Items["Id"] as string;
        _ = int.TryParse(userId, out int userIdAsInt);

        Request.Query.TryGetValue("pageNumber", out var pageNumber);
        Request.Query.TryGetValue("pageSize", out var pageSize);

        var tasks = await _appTasksService.GetAll(userIdAsInt, int.Parse(pageNumber), int.Parse(pageSize));
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppTaskDto>> GetOne(int id)
    {
        var userId = HttpContext.Items["Id"] as string;
        _ = int.TryParse(userId, out int userIdAsInt);
        var task = await _appTasksService.GetOne(id, userIdAsInt);
        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<AppTaskDto>> Create(CreateAppTaskDto task)
    {
        var userId = HttpContext.Items["Id"] as string;
        _ = int.TryParse(userId, out int userIdAsInt);

        task.UserId = userIdAsInt;
        var created = await _appTasksService.Create(task);
        return CreatedAtAction(nameof(GetOne), new { created.Id }, created);
    }

    [HttpPost("{id}/status")]
    public async Task<ActionResult<AppTaskDto>> ChangeTaskStatus(int id)
    {
        var userId = HttpContext.Items["Id"] as string;
        _ = int.TryParse(userId, out int userIdAsInt);
        var created = await _appTasksService.ChangeTaskStatus(id, userIdAsInt);
        return Ok(created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, UpdateAppTaskDto task)
    {
        var userId = HttpContext.Items["Id"] as string;
        _ = int.TryParse(userId, out int userIdAsInt);
        var updated = await _appTasksService.Update(id, userIdAsInt, task);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var userId = HttpContext.Items["Id"] as string;
            _ = int.TryParse(userId, out int userIdAsInt);
            await _appTasksService.Delete(id, userIdAsInt);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}
