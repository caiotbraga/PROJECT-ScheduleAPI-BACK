using System;
using Microsoft.EntityFrameworkCore;
using ScheduleAPI.Models;

namespace ScheduleAPI.Data;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> opts)
        : base(opts)
    {

    }

    public DbSet<User> Users { get; set; }
}

