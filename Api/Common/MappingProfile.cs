using Api.Modules.Auth;
using AutoMapper;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<AppTask, AppTaskDto>().ReverseMap();
    CreateMap<User, UserDto>().ReverseMap();
    CreateMap<UserDto, RegisterDto>().ReverseMap();
    CreateMap<UserDto, AuthDto>().ReverseMap();
  }
}