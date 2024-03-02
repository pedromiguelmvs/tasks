using Api.Common.IService;
using Api.Common.NotFoundException;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tasks")]
public class TasksController(IService appTasksService) : ControllerBase
{

    private readonly IService _appTasksService = appTasksService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppTask>>> GetAll()
    {
        var tasks = await _appTasksService.GetAll();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppTaskDto>> GetOne(int id)
    {
        var task = await _appTasksService.GetOne(id);
        if (task == null)
        {
            return NotFound();
        }
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
        if (id != task.Id)
        {
            return BadRequest();
        }

        if (task == null)
        {
            return NotFound();
        }

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
