using MatchManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MatchManagementAPI.Data
{
	public class SqlMatchRepo : IMatchRepo
	{
		private readonly MatchContext _context;

		public SqlMatchRepo(MatchContext context)
		{

			_context = context;
		}
		public IEnumerable<Match> GetAllMatches()
		{
			return _context.Matches.ToList();
		}

		public Match GetMatchBy(int id)
		{
			return _context.Matches.FirstOrDefault(p => p.ID == id);
		}
	}
}
