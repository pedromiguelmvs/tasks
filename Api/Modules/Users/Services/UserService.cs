using System.Linq.Expressions;
using Api.Common.Interfaces;
using AutoMapper;

namespace Api.Modules.Users
{
  public class UserService(IRepository<User> repository, IMapper mapper) : IUsersService
  {

    private readonly IRepository<User> _repository = repository;

    private readonly IMapper _mapper = mapper;

    public async Task<List<UserDto>> GetAll()
    {
      var users = await _repository.GetAllAsync();
      return _mapper.Map<List<UserDto>>(users);
    }

    public async Task<UserDto> GetOne(string username)
    {
      Expression<Func<User, bool>> predicate = e => e.Username == username;
      var user = await _repository.GetWhereAsync(predicate) ?? throw new Exception("Usuário inexistente.");
      return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> Exist(string username)
    {
      Expression<Func<User, bool>> predicate = e => e.Username == username;
      var user = await _repository.GetWhereAsync(predicate);
      return user != null;
    }

    public async Task<UserDto> Create(CreateUserDto createUserDto)
    {
      var user = _mapper.Map<User>(createUserDto);
      await _repository.AddAsync(user);
      return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> Update(int id, UserDto userDto)
    {
      var user = await _repository.GetByIdAsync(id);
      _mapper.Map(userDto, user);
      await _repository.UpdateAsync(user);
      return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> Delete(int id)
    {
      var user = await _repository.GetByIdAsync(id);
      await _repository.DeleteAsync(user);
      return true;
    }
  }
}