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
      var tasks = await _context.AppTasks.Where(e => e.UserId == userId && e.DeletedAt == null).ToListAsync();
      return _mapper.Map<List<AppTaskDto>>(tasks);
    }

    public async Task<AppTaskDto> GetOne(int id, int userId)
    {
      var task = await _context.AppTasks.Where(e => e.Id == id && e.UserId == userId).FirstOrDefaultAsync();
      return _mapper.Map<AppTaskDto>(task);
    }

    public async Task<AppTaskDto> Create(CreateAppTaskDto task)
    {
      var created = _mapper.Map<AppTask>(task);
      _context.AppTasks.Add(created);
      await _context.SaveChangesAsync();
      return _mapper.Map<AppTaskDto>(created);
    }

    public async Task<AppTaskDto> Update(int id, int userId, UpdateAppTaskDto taskDto)
    {
      if (id != taskDto.Id)
      {
        throw new Exception("Ids incompatíveis!");
      }

      var task = await _context.AppTasks.FindAsync(id) ?? throw new Exception("Tarefa não encontrada!");

      if (task.UserId != userId)
      {
        throw new Exception("Você não tem permissão para alterar essa task!");
      }

      _mapper.Map(taskDto, task);
      await _context.SaveChangesAsync();
      return _mapper.Map<AppTaskDto>(task);
    }

    public async Task<AppTaskDto> ChangeTaskStatus(int id, int userId)
    {
      var task = await _context.AppTasks.Where(e => e.Id == id && e.UserId == userId).FirstOrDefaultAsync();
      task.Done = !task.Done;
      await _context.SaveChangesAsync();
      return _mapper.Map<AppTaskDto>(task);
    }

    public async Task<bool> Delete(int id, int userId)
    {
      var task = await _context.AppTasks.FindAsync(id);

      if (task.UserId != userId)
      {
        throw new Exception("Você não tem permissão para alterar essa task!");
      }

      task.DeletedAt = DateTime.UtcNow;
      await _context.SaveChangesAsync();
      return true;
    }
  }
}