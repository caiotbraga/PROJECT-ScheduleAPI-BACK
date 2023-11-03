using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Dtos;
using ScheduleAPI.Models;

namespace ScheduleAPI.Interface
{
    public interface IUserService
    {
        public void AddUser(CreateUserDto user);
        public IEnumerable<ReadUserDto> GetUsers(int skip, int take);
        public User GetUserById(int id);
        public User UpdateUser(int id,  UpdateUserDto user);
        public void UpdateUserPath(bool validation);
        public void DeleteUser(int id);
    }
}
