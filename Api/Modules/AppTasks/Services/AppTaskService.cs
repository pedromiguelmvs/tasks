using Api.Modules.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Modules.AppTasks
{
  public class AppTaskService(ApplicationDbContext context, IMapper mapper) : IAppTaskService
  {

    private readonly ApplicationDbContext _context = context;

    private readonly IMapper _mapper = mapper;

    public async Task<List<AppTaskDto>> GetAll(int userId)
    {
      var tasks = await _context.AppTasks.Where(e => e.UserId == userId).ToListAsync();
      return _mapper.Map<List<AppTaskDto>>(tasks);
    }

    public async Task<AppTaskDto> GetOne(int id, int userId)
    {
      var task = await _context.AppTasks.Where(e => e.Id == id && e.UserId == userId).FirstOrDefaultAsync();
      return _mapper.Map<AppTaskDto>(task);
    }

    public async Task<AppTaskDto> Create(AppTaskDto task)
    {
      var created = _mapper.Map<AppTask>(task);
      _context.AppTasks.Add(created);
      await _context.SaveChangesAsync();
      return _mapper.Map<AppTaskDto>(created);
    }

    public async Task<AppTaskDto> Update(int id, AppTaskDto taskDto)
    {
      if (id != taskDto.Id)
      {
        throw new Exception("Ids incompatíveis!");
      }

      var task = await _context.AppTasks.FindAsync(id) ?? throw new Exception("Tarefa não encontrada!");
      _mapper.Map(taskDto, task);
      await _context.SaveChangesAsync();
      return _mapper.Map<AppTaskDto>(task);
    }

    public async Task<bool> Delete(int id)
    {
      var task = await _context.AppTasks.FindAsync(id);
      _context.AppTasks.Remove(task);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}