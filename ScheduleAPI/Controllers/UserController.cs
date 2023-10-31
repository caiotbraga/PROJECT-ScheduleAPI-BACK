using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Models;

namespace ScheduleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController
{
    private static List<User> users = new List<User>();
    [HttpPost]
    public void AddUser(User user)
    {
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

}
