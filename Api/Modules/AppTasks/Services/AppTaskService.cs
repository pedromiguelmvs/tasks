using Api.Common.IService;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AppTaskService(ApplicationDbContext context, IMapper mapper) : IService
{

  private readonly ApplicationDbContext _context = context;

  private readonly IMapper _mapper = mapper;

  public async Task<ActionResult<IEnumerable<AppTaskDto>>> GetAll() {
    var tasks = await _context.AppTasks.ToListAsync();
    return _mapper.Map<ActionResult<IEnumerable<AppTaskDto>>>(tasks);
  }

  public async Task<ActionResult<AppTaskDto>> GetOne(int id) {
    var task = await _context.AppTasks.FindAsync(id);
    return _mapper.Map<ActionResult<AppTaskDto>>(task);
  }

  public async Task<ActionResult<AppTaskDto>> Create(AppTaskDto task) {
    _context.AppTasks.Add(task);
    await _context.SaveChangesAsync();
    return _mapper.Map<ActionResult<AppTaskDto>>(task);
  }

  public async Task<IActionResult> Update(int id, AppTaskDto task) {
    _context.Entry(task).State = EntityState.Modified;
    await _context.SaveChangesAsync();
    return _mapper.Map<IActionResult>(task);
  }
  
  public async Task<bool> Delete(int id) {
    var task = await _context.AppTasks.FindAsync(id);
    _context.AppTasks.Remove(task);
    await _context.SaveChangesAsync();
    return true;
  }
}