using Api.Modules.AppTasks;
using Api.Common.Paginator;

namespace Api.Modules.Interfaces
{
  public interface IAppTaskService
  {
    Task<PaginationResult<AppTaskDto>> GetAll(int userId, int pageNumber, int pageSize);
    Task<AppTaskDto> GetOne(int id, int userId);
    Task<AppTaskDto> Create(CreateAppTaskDto task);
    Task<AppTaskDto> Update(int id, int userId, UpdateAppTaskDto task);
    Task<AppTaskDto> ChangeTaskStatus(int id, int userId);
    Task<bool> Delete(int id, int userId);
  }
}