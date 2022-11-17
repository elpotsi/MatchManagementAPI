using MatchManagementAPI.Models;
using System.Collections;
using System.Collections.Generic;

namespace MatchManagementAPI.Data
{
	public interface IMatchRepo
	{
		bool SaveChanges();
		IEnumerable<Match> GetAllMatches();
		Match GetMatchBy(int id);
		void CreateMatch(Match cmd);
		void UpdateMatch(Match cmd);
		void DeleteMatch(Match cmd);
	}
}
