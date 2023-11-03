using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Dtos;
using ScheduleAPI.Models;
using ScheduleAPI.Service;

namespace ScheduleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserService _userService;
    private IMapper _mapper;
    public UserController(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        _userService.AddUser(userDto);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpGet]
    public IEnumerable<ReadUserDto> GetUsers([FromQuery] int skip = 0, [FromQuery] int take = 100)
    {
        return _userService.GetUsers(skip, take);
    }

    [HttpGet("/users/edit/{id}")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);

        if (user == null) return NotFound("User doesn't exist!");
        var userDto = _mapper.Map<ReadUserDto>(user);
        return Ok(userDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto userDto)
    {
        var user = _userService.UpdateUser(id, userDto);
        if (user == null) return NotFound("User doesn't exist!");
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateUserPath(int id, JsonPatchDocument<UpdateUserDto> patch)
    {
        bool validation = false;
        var user = _userService.GetUserById(id);
        if (user == null) return NotFound("User doesn't exist!");
        var userToUpdate = _mapper.Map<UpdateUserDto>(user);
        patch.ApplyTo(userToUpdate, ModelState);
        if (!TryValidateModel(userToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        validation = true;
        _mapper.Map(userToUpdate, user);
        _userService.UpdateUserPath(validation);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null) return NotFound("User doesn't exist!");
        _userService.DeleteUser(id);
        return NoContent();
    }
}