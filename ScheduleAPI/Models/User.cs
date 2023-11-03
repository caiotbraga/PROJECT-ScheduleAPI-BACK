using ScheduleAPI.Interface;
using System.ComponentModel.DataAnnotations;

namespace ScheduleAPI.Models;

public class User : IUser
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [MinLength(4, ErrorMessage = "The Name's length must be more than 4 characters"), MaxLength(50, ErrorMessage = "The Name's length can't be above 50 characters")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    [MinLength(10, ErrorMessage = "The Emails's length must be more than 10 characters"), MaxLength(50, ErrorMessage = "The Email's length can't be above 50 character")]
    public string Email { get; set; }

    [MinLength(11, ErrorMessage = "The Phone number's length must be 11 characters"), MaxLength(11, ErrorMessage = "The Email's length must be 11 characters")]
    public string PhoneNumber { get; set; }
}
