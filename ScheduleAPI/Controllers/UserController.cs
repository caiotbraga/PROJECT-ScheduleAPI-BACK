﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Data;
using ScheduleAPI.Dtos;
using ScheduleAPI.Models;

namespace ScheduleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private UserContext _context;
    private IMapper _mapper;

    public UserController(UserContext userContext, IMapper mapper)
    {
        _context = userContext;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id}, user);
    }

    [HttpGet]
    public IEnumerable<ReadUserDto> GetUsers([FromQuery] int skip = 0, [FromQuery] int take = 100)
    {
        return _mapper.Map<List<ReadUserDto>>(_context.Users.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult? GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id);

        if (user == null) return NotFound("User doesn't exist!");
        var userDto = _mapper.Map<ReadUserDto>(user);
        return Ok(userDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto userDto) {
        var user = _context.Users.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound("User doesn't exist!");
        _mapper.Map(userDto, user);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateUserPath(int id, JsonPatchDocument<UpdateUserDto> patch)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound("User doesn't exist!");
        var userToUpdate = _mapper.Map<UpdateUserDto>(user);
        patch.ApplyTo(userToUpdate, ModelState);
        if (!TryValidateModel(userToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(userToUpdate, user);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound("User doesn't exist!");
        _context.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }
}
