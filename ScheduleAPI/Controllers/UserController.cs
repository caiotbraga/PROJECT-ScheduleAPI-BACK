using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Models;

namespace ScheduleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController
{
    private static List<User> users = new List<User>();
    private static int Id = 0;

    [HttpPost]
    public void AddUser(User user)
    {
        user.Id = Id++;
        users.Add(user);
        Console.WriteLine(user.UserName);
        Console.WriteLine(user.Email);
        Console.WriteLine(user.PhoneNumber);
    }

    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        return users;
    }

    [HttpGet("{id}")]
    public User? GetUserById(int id)
    {
        return users.FirstOrDefault(user => user.Id == id);
    }

}
