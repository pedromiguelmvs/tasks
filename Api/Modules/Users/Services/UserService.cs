using Api.Modules.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Modules.Users
{
  public class UserService(ApplicationDbContext context, IMapper mapper) : IUsersService
  {

    private readonly ApplicationDbContext _context = context;

    private readonly IMapper _mapper = mapper;

    public async Task<List<UserDto>> GetAll()
    {
      var users = await _context.Users.ToListAsync();
      return _mapper.Map<List<UserDto>>(users);
    }

    public async Task<UserDto> GetOne(string username)
    {
      var user = await _context.Users.FirstOrDefaultAsync(user => user.Username == username);
      return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> Exist(string username)
    {
      var user = await _context.Users.FirstOrDefaultAsync(user => user.Username == username);
      return user != null;
    }

    public async Task<UserDto> Create(UserDto userDto)
    {
      var user = _mapper.Map<User>(userDto);
      _context.Users.Add(user);
      await _context.SaveChangesAsync();
      return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> Update(int id, UserDto userDto)
    {
      var user = await _context.Users.FindAsync(id);
      _mapper.Map(userDto, user);
      await _context.SaveChangesAsync();
      return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> Delete(int id)
    {
      var user = await _context.Users.FindAsync(id);
      _context.Users.Remove(user);
      await _context.SaveChangesAsync();
      return true;
    }
  }
}