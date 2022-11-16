using MatchManagementAPI.Models;
using System.Collections;
using System.Collections.Generic;

namespace MatchManagementAPI.Data
{
	public interface IMatchRepo
	{
		IEnumerable<Match> GetAllMatches();
		Match GetMatchBy(int id);
	}
}
