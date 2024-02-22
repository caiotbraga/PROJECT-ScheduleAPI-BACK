using System.ComponentModel.DataAnnotations;

namespace ScheduleAPI.Dtos
{
    public class ReadUserDto
    {
        public int Id { get; set; } 
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime QueryTime { get; set; } = DateTime.Now;
    }
}
