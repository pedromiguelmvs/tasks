namespace Api.Modules.Interfaces
{
  public interface IAppTaskService
  {
    Task<List<AppTaskDto>> GetAll();
    Task<AppTaskDto> GetOne(int id);
    Task<AppTaskDto> Create(AppTaskDto task);
    Task<AppTaskDto> Update(int id, AppTaskDto task);
    Task<bool> Delete(int id);
  }
}