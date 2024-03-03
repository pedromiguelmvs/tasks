using Api.Common.NotFoundException;
using Api.Modules.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/users")]
public class UserController(IUsersService userService) : ControllerBase
{
  private readonly IUsersService _userService = userService;

  [HttpGet]
  public async Task<ActionResult<IEnumerable<User>>> GetAll()
  {
    var users = await _userService.GetAll();
    return Ok(users);
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<UserDto>> GetOne(int id)
  {
    var user = await _userService.GetOne(id);
    if (user == null)
    {
      return NotFound();
    }
    return Ok(user);
  }

  [HttpPost]
  public async Task<ActionResult<UserDto>> Create(UserDto userDto)
  {
    var user = await _userService.Create(userDto);
    return CreatedAtAction(nameof(GetOne), new { user.Id }, user);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, UserDto userDto)
  {
    if (id != userDto.Id)
    {
      return BadRequest();
    } 

    if (userDto == null)
    {
      return NotFound();
    }

    var user = await _userService.Update(id, userDto);
    return Ok(user);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      await _userService.Delete(id);
      return NoContent();
    }
    catch (NotFoundException)
    {
      return NotFound();
    }
  }
}