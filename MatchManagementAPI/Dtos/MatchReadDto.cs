using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace MatchManagementAPI.Dtos
{
	public class MatchReadDto
	{		
		public int ID { get; set; }
		public string Description { get; set; }
		public DateTime MatchDate { get; set; }
		public TimeSpan MatchTime { get; set; }		
		public string TeamA { get; set; }		
		public string TeamB { get; set; }
		public SportType Sport { get; set; }

		public enum SportType
		{
			Football = 1,
			Basketball = 2
		}

	}
}
