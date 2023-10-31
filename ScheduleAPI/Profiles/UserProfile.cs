using AutoMapper;
using ScheduleAPI.Dtos;
using ScheduleAPI.Models;

namespace ScheduleAPI.Profiles;

public class UserProfile : Profile
{

    public UserProfile() {
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<User, UpdateUserDto>();
        CreateMap<User, ReadUserDto>();
    }
}
