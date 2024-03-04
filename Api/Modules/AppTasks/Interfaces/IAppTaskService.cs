namespace Api.Modules.Interfaces
{
  public interface IAppTaskService
  {
    Task<List<AppTaskDto>> GetAll(int userId);
    Task<AppTaskDto> GetOne(int id, int userId);
    Task<AppTaskDto> Create(AppTaskDto task);
    Task<AppTaskDto> Update(int id, AppTaskDto task);
    Task<bool> Delete(int id);
  }
}