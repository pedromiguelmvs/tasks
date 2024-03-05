using Api.Modules.AppTasks;
using Api.Modules.Auth;
using Api.Modules.Users;
using AutoMapper;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<CreateAppTaskDto, AppTaskDto>().ReverseMap();
    CreateMap<CreateAppTaskDto, AppTask>().ReverseMap();
    CreateMap<AppTask, AppTaskDto>().ReverseMap();
    CreateMap<User, UserDto>().ReverseMap();

    CreateMap<UserDto, RegisterDto>().ReverseMap();
    CreateMap<UserDto, AuthDto>().ReverseMap();

    CreateMap<RegisterDto, CreateUserDto>().ReverseMap();

    CreateMap<CreateUserDto, User>();
    CreateMap<UpdateUserDto, User>();
  }
}