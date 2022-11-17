using MatchManagementAPI.Models;
using System;
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

		public void CreateMatch(Match cmd)
		{
			if (cmd == null)
			{
				throw new ArgumentNullException(nameof(cmd));
			}
			_context.Matches.Add(cmd);
		}

		public void DeleteMatch(Match cmd)
		{
			if (cmd == null)
			{
				throw new ArgumentNullException(nameof(cmd));
			}
			_context.Matches.Remove(cmd);
		}

		public IEnumerable<Match> GetAllMatches()
		{
			return _context.Matches.ToList();
		}

		public Match GetMatchBy(int id)
		{
			return _context.Matches.FirstOrDefault(p => p.ID == id);
		}

		public bool SaveChanges()
		{
			return (_context.SaveChanges() >= 0);
		}

		public void UpdateMatch(Match cmd)
		{
			//nothing
		}
	}
}
