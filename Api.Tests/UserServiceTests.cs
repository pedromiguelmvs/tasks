using System.Linq.Expressions;
using Api.Common.Interfaces;
using Api.Modules.Users;
using AutoMapper;
using Moq;

namespace Api.Tests
{
  public class UserServiceTests
  {
    private readonly Mock<IRepository<User>> _mockRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UserService _userService;

    public UserServiceTests()
    {
      _mockRepository = new Mock<IRepository<User>>();
      _mockMapper = new Mock<IMapper>();
      _userService = new UserService(_mockRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetAll_ReturnsAllUsers()
    {
      var users = new List<User> { new(), new() };
      _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);
      _mockMapper.Setup(mapper => mapper.Map<List<UserDto>>(users)).Returns(new List<UserDto> { new(), new() });

      var result = await _userService.GetAll();

      Assert.NotNull(result);
      Assert.Equal(users.Count, result.Count);
    }

    [Fact]
    public async Task GetOne_ReturnsUserByUsername()
    {
      var username = "testuser";
      var user = new User { Username = username };
      _mockRepository.Setup(repo => repo.GetWhereAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);
      _mockMapper.Setup(mapper => mapper.Map<UserDto>(user)).Returns(new UserDto { Username = username });

      var result = await _userService.GetOne(username);

      Assert.NotNull(result);
      Assert.Equal(username, result.Username);
    }

    [Fact]
    public async Task Exist_ReturnsBooleanIfExist()
    {
      var username = "testuser";
      var user = new User { Username = username };
      _mockRepository.Setup(repo => repo.GetWhereAsync(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(user);

      var result = await _userService.Exist(username);

      Assert.True(result);
    }
  }
}