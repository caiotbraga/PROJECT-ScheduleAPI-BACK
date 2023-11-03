using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Dtos;

namespace ScheduleAPI.Interface
{
    public interface IUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
