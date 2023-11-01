using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Dtos;
using ScheduleAPI.Models;

namespace ScheduleAPI.Interface
{
    public interface IUserService
    {
        public void AddUser([FromBody] CreateUserDto user);
        public IEnumerable<ReadUserDto> GetUsers([FromQuery] int skip, [FromQuery] int take);
        public User GetUserById(int id);
        public User UpdateUser(int id, [FromBody] UpdateUserDto user);
        public void UpdateUserPath(bool validation);
        public void DeleteUser(int id);
    }
}
