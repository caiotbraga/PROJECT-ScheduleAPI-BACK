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

    public UserService()
    {

    }

    // Constructor with dependencies injection
    public UserService(UserContext userContext, IMapper mapper)
    {
        _context = userContext;
        _mapper = mapper;
    }

    // Method to add a new user
    public virtual void AddUser([FromBody] CreateUserDto userDto)
    {
        User user = _mapper.Map<User>(userDto); // Mapping CreateUserDto to User
        _context.Users.Add(user); // Adding the user to the database context
        _context.SaveChanges(); // Saving changes to the database
    }

    // Method to get a list of users with pagination
    public virtual IEnumerable<ReadUserDto> GetUsers([FromQuery] int skip, [FromQuery] int take)
    {
        return _mapper.Map<List<ReadUserDto>>(_context.Users.Skip(skip).Take(take));
    }

    // Method to get a user by ID
    public virtual User? GetUserById(int id)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id); // Retrieving user by ID
        return user; // Returning the user if found
    }

    // Method to update a user
    public virtual User UpdateUser(int id, [FromBody] UpdateUserDto userDto)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id);
        if (user == null)
        {
            return null; // Returning null if user not found
        }
        else
        {
            _mapper.Map(userDto, user); // Mapping UpdateUserDto to the existing user
            _context.SaveChanges(); // Saving changes to the database
            return user; // Returning the updated user
        }
    }

    // Method to update a user partially
    public virtual void UpdateUserPath(bool validation)
    {
        _context.SaveChanges();
    }

    // Method to delete a user
    public virtual void DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(user => user.Id == id); // Retrieving user by ID
        _context.Remove(user); // Removing the user from the database context
        _context.SaveChanges(); // Saving changes to the database
    }




}
