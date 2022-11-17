using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace MatchManagementAPI.Dtos
{
	public class MatchCreateDto
	{
		public string Description { get; set; }
		[Required]
		public DateTime MatchDate { get; set; }
		public TimeSpan MatchTime { get; set; }

		[Required]
		public string TeamA { get; set; }
		[Required]
		public string TeamB { get; set; }
		[Required]
		public SportType Sport { get; set; }

		public enum SportType
		{
			Football = 1,
			Basketball = 2
		}

	}
}
