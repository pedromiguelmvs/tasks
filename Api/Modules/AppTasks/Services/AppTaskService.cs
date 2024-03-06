using System.Linq.Expressions;
using Api.Common.Interfaces;
using Api.Common.Paginator;
using Api.Modules.Interfaces;
using AutoMapper;

namespace Api.Modules.AppTasks
{
  public class AppTaskService(IRepository<AppTask> repository, IMapper mapper) : IAppTaskService
  {

    private readonly IMapper _mapper = mapper;

    private readonly IRepository<AppTask> _repository = repository;

    public async Task<PaginationResult<AppTask>> GetAll(int userId, int pageNumber, int pageSize)
    {
      Expression<Func<AppTask, bool>> predicate = e => e.UserId == userId && e.DeletedAt == null;
      return await _repository.GetWhereAsyncWithPaginator(pageNumber, pageSize, predicate);
    }

    public async Task<AppTaskDto> GetOne(int id, int userId)
    {
      Expression<Func<AppTask, bool>> predicate = e => e.Id == id && e.UserId == userId;
      var task = await _repository.GetWhereAsync(predicate);
      return _mapper.Map<AppTaskDto>(task);
    }

    public async Task<AppTaskDto> Create(CreateAppTaskDto task)
    {
      var created = _mapper.Map<AppTask>(task);
      await _repository.AddAsync(created);
      return _mapper.Map<AppTaskDto>(created);
    }

    public async Task<AppTaskDto> Update(int id, int userId, UpdateAppTaskDto taskDto)
    {
      if (id != taskDto.Id)
      {
        throw new Exception("Ids incompatíveis!");
      }

      var task = await _repository.GetByIdAsync(id) ?? throw new Exception("Tarefa não encontrada!");

      if (task.UserId != userId)
      {
        throw new Exception("Você não tem permissão para alterar essa task!");
      }

      _mapper.Map(taskDto, task);
      await _repository.UpdateAsync(task);
      return _mapper.Map<AppTaskDto>(task);
    }

    public async Task<AppTaskDto> ChangeTaskStatus(int id, int userId)
    {
      Expression<Func<AppTask, bool>> predicate = e => e.Id == id && e.UserId == userId;
      var task = await _repository.GetWhereAsync(predicate);
      task.Done = !task.Done;
      await _repository.UpdateAsync(task);
      return _mapper.Map<AppTaskDto>(task);
    }

    public async Task<bool> Delete(int id, int userId)
    {
      var task = await _repository.GetByIdAsync(id);

      if (task.UserId != userId)
      {
        throw new Exception("Você não tem permissão para alterar essa task!");
      }

      task.DeletedAt = DateTime.UtcNow;
      await _repository.UpdateAsync(task);

      return true;
    }
  }
}