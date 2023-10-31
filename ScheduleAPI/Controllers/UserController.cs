using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Models;

namespace ScheduleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private static List<User> users = new List<User>();
    private static int Id = 0;

    [HttpPost]
    public IActionResult AddUser([FromBody] User user)
    {
        user.Id = Id++;
        users.Add(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id}, user);
    }

    [HttpGet]
    public IEnumerable<User> GetUsers([FromQuery] int skip = 0, [FromQuery] int take = 100)
    {
        return users.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult? GetUserById(int id)
    {
        var user =  users.FirstOrDefault(user => user.Id == id);

        if (user == null) return NotFound("User doesn't exist!");
        return Ok(user);
    }

}
