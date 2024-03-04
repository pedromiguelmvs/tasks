namespace Api.Modules.Users
{
  public interface IUsersService
  {
    Task<List<UserDto>> GetAll();
    Task<UserDto> GetOne(string username);
    Task<UserDto> Create(UserDto user);
    Task<UserDto> Update(int id, UserDto user);
    Task<bool> Delete(int id);
    Task<bool> Exist(string username);
  }
}