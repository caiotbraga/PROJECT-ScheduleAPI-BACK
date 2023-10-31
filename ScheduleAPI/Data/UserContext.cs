using System;
using Microsoft.EntityFrameworkCore;

namespace ScheduleAPI.Data;

	public class UserContext : DbContext
	{
		public UserContext(DbContextOptions<UserContext> opts) : base(opts)
    {
			
		}
	}

