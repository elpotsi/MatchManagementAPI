using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace MatchManagementAPI.Models
{
	public class Match
	{
		[Key]
		public int ID { get; set;}
		public string Description { get; set;}
		public DateTime MatchDate { get; set;}
		public TimeSpan MatchTime { get; set; }
		[Required]
		[MaxLength(250)]
		public string TeamA { get; set; }

		[Required]
		[MaxLength(250)] 
		public string TeamB { get; set; }
		public SportType Sport { get; set; }

		public enum SportType
		{
			Football=1,
			Basketball=2
		}	

	}
}
