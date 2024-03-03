namespace Api.Modules.Interfaces
{
  public interface IUsersService
  {
    Task<List<UserDto>> GetAll();
    Task<UserDto> GetOne(int id);
    Task<UserDto> Create(UserDto user);
    Task<UserDto> Update(int id, UserDto user);
    Task<bool> Delete(int id);
  }
}