using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Dtos;
using ScheduleAPI.Interface;
using AutoMapper;
using ScheduleAPI.Data;
using ScheduleAPI.Models;
using ScheduleAPI.Service;

namespace ScheduleAPI.Service;
public class UserService : IUserService
{
    private UserContext _context;
    private IMapper _mapper;

    public UserService(UserContext userContext, IMapper mapper)
    {
        _context = userContext;
        _mapper = mapper;
    }

    public void AddUser([FromBody] CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto);
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public IEnumerable<ReadUserDto> GetUsers([FromQuery] int skip, [FromQuery] int take)
    {
        return _mapper.Map<List<ReadUserDto>>(_context.Users.Skip(skip).Take(take));
    }

    public User? GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id);
        return user;
    }
    public User UpdateUser(int id, [FromBody] UpdateUserDto userDto)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id);
        if (user == null)
        {
            return null;
        }
        else
        {
            _mapper.Map(userDto, user);
            _context.SaveChanges();
            return user;
        }
    }

    public void UpdateUserPath(bool validation)
    {
        _context.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id);
        _context.Remove(user);
        _context.SaveChanges();
    }




}
