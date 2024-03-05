using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Api.Modules.Auth
{
  [ApiController]
  [Route("api/auth")]
  public class AuthController(IAuthService authService) : ControllerBase
  {
    private readonly IAuthService _authService = authService;

    [Route("login")]
    [HttpPost]
    public async Task<OkObjectResult> Login(AuthDto authDto)
    {
      var token = await _authService.Login(authDto);
      var dictionary = new Dictionary<string, string>
        {
            { "token", token },
        };
      
      return Ok(dictionary);
    }

    [Route("register")]
    [HttpPost]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
      if (registerDto.Password != registerDto.ConfirmPassword)
      {
        return BadRequest();
      }

      return await _authService.Register(registerDto);
    }
  }
}