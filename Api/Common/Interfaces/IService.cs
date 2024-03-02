using Microsoft.AspNetCore.Mvc;

namespace Api.Common.IService
{
  public interface IService
  {
    Task<ActionResult<IEnumerable<AppTaskDto>>> GetAll();
    Task<ActionResult<AppTaskDto>> GetOne(int id);
    Task<ActionResult<AppTaskDto>> Create(AppTaskDto task);
    Task<IActionResult> Update(int id, AppTaskDto task);
    Task<bool> Delete(int id);
  }
}