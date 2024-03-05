using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Common.Services;
using Api.Modules.Users;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Api.Modules.Auth
{
  public class AuthService(IMapper mapper, IUsersService userService, IConfiguration configuration) : IAuthService
  {
    private readonly IUsersService _userService = userService;
    
    private readonly IMapper _mapper = mapper;

    public IConfiguration Configuration = configuration;    

    public async Task<string> Login(AuthDto authDto)
    {
      var user = await _userService.GetOne(authDto.Username) ?? throw new Exception("Nome de usuário ou senha inválidos.");
      var hashing = new PasswordHashingService();
      var verifyPassword = hashing.Verify(user.Password, authDto.Password);

      if (verifyPassword == PasswordVerificationResult.Failed)
      {
        throw new Exception("Nome de usuário ou senha inválidos.");
      }

      var userMap = _mapper.Map<UserDto>(user);
      var token = GenerateToken(userMap);
      return token;
    }

    private string GenerateToken(UserDto userDto)
    {
      var claims = new []
      {
        new Claim("username", userDto.Username),
        new Claim("id", userDto.Id.ToString()),
      };
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        Configuration["Jwt:Issuer"],
        Configuration["Jwt:Issuer"],
        claims,
        expires: DateTime.Now.AddHours(1),
        signingCredentials: creds
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<UserDto> Register(RegisterDto registerDto)
    {
      var userExist = await _userService.Exist(registerDto.Username);

      if (userExist)
      {
        throw new Exception("Nome de usuário já cadastrado!");
      }

      var hashing = new PasswordHashingService();
      var hashed = hashing.Hash(registerDto.Password);
      registerDto.Password = hashed;

      var user = _mapper.Map<CreateUserDto>(registerDto);
      var userDto = await _userService.Create(user);
      return userDto;
    }
  }
}