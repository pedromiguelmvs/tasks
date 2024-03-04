using Api.Common.NotFoundException;
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
    public async Task<ActionResult<IEnumerable<AppTask>>> GetAll()
    {
        var userId = HttpContext.Items["Id"] as string;
        _ = int.TryParse(userId, out int userIdAsInt);
        var tasks = await _appTasksService.GetAll(userIdAsInt);
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
    public async Task<ActionResult<AppTaskDto>> Create(AppTaskDto task)
    {
        var created = await _appTasksService.Create(task);
        return CreatedAtAction(nameof(GetOne), new { created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, AppTaskDto task)
    {
        var updated = await _appTasksService.Update(id, task);
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _appTasksService.Delete(id);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }
}
