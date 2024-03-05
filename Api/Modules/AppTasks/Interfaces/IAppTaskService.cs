using Api.Modules.AppTasks;

namespace Api.Modules.Interfaces
{
  public interface IAppTaskService
  {
    Task<List<AppTaskDto>> GetAll(int userId);
    Task<AppTaskDto> GetOne(int id, int userId);
    Task<AppTaskDto> Create(CreateAppTaskDto task);
    Task<AppTaskDto> Update(int id, int userId, AppTaskDto task);
    Task<bool> Delete(int id, int userId);
  }
}