namespace Api.Modules.Auth
{
  public interface IAuthService
  {
    Task<string> Login(AuthDto user);
    Task<UserDto> Register(RegisterDto user);
  }
}