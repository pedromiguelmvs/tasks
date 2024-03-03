using AutoMapper;

public class MappingProfile : Profile
{
  public MappingProfile()
  {
    CreateMap<AppTask, AppTaskDto>().ReverseMap();
    CreateMap<User, UserDto>().ReverseMap();
  }
}