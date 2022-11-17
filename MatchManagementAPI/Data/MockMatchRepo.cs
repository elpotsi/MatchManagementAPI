using MatchManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace MatchManagementAPI.Data
{
	public class MockMatchRepo : IMatchRepo
	{
		public MockMatchRepo() { }

		public void CreateMatch(Match cmd)
		{
			throw new NotImplementedException();
		}

		public void DeleteMatch(Match cmd)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Match> GetAllMatches()
		{
			var matches = new List<Match>
			{
				new Match { ID = 0, Description = "match of football", MatchDate = new DateTime(), MatchTime = new TimeSpan(), TeamA = "barcellona", TeamB = "AEK", Sport = Match.SportType.Football },
				new Match { ID = 1, Description = "match of basketball", MatchDate = new DateTime(), MatchTime = new TimeSpan(), TeamA = "valencia", TeamB = "Pao", Sport = Match.SportType.Football },
				new Match { ID = 2, Description = "match of football", MatchDate = new DateTime(), MatchTime = new TimeSpan(), TeamA = "boil", TeamB = "paok", Sport = Match.SportType.Football }

			};

			return matches;
		}

		public Match GetMatchBy(int id)
		{
			return new Match { ID = 0, Description = "match of football", MatchDate = new DateTime(), MatchTime = new TimeSpan(), TeamA = "barcellona", TeamB = "AEK", Sport = Match.SportType.Football };
		}

		public bool SaveChanges()
		{
			throw new NotImplementedException();
		}

		public void UpdateMatch(Match cmd)
		{
			throw new NotImplementedException();
		}
	}
}
