using Microsoft.AspNetCore.Mvc;

namespace Api.Common.IService
{
  public interface IService
  {
    Task<List<AppTaskDto>> GetAll();
    Task<AppTaskDto> GetOne(int id);
    Task<AppTaskDto> Create(AppTaskDto task);
    Task<AppTaskDto> Update(int id, AppTaskDto task);
    Task<bool> Delete(int id);
  }
}