using ESEIdentity.Dtos;
using ESEIdentity.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ESEIdentity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
    {
        var usersDto = await _userService.GetUsers();

        if (usersDto is null)
            return NotFound("Users not found");

        return Ok(usersDto);
    }

    [HttpGet("{id:Guid}", Name = "GetUser")]
    [Authorize]
    public async Task<ActionResult<UserDto>> Get(Guid id)
    {
        var userDto = await _userService.GetUserById(id);
        if (userDto == null)
        {
            return NotFound("User not found");
        }
        return Ok(userDto);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserDto userDto)
    {
        if (userDto == null)
            return BadRequest("Invalid Data");

        await _userService.AddUser(userDto);

        return new CreatedAtRouteResult("GetUser", new { id = userDto.Id },
            userDto);
    }

    [HttpPut("{id:Guid}")]
    [Authorize]
    public async Task<ActionResult> Put(Guid id, [FromBody] UserDto userDto)
    {
        if (id != userDto.Id)
            return BadRequest();

        if (userDto is null)
            return BadRequest();

        await _userService.UpdateUser(userDto);

        return Ok(userDto);
    }

    [HttpDelete("{id:Guid}")]
    [Authorize]
    public async Task<ActionResult<UserDto>> Delete(Guid id)
    {
        var userDto = await _userService.GetUserById(id);
        if (userDto == null)
        {
            return NotFound("User not found");
        }

        await _userService.RemoveUser(id);

        return Ok(userDto);
    }
}