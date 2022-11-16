using MatchManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchManagementAPI.Data
{
	public class MatchContext : DbContext
	{
		public MatchContext(DbContextOptions<MatchContext> opt) : base(opt) 
		{ 
		
		}

		public DbSet<Match> Matches { get; set; }
	}

	
}
