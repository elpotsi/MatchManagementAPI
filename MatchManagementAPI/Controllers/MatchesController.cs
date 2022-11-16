using MatchManagementAPI.Data;
using MatchManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MatchManagementAPI.Controllers
{
	[Route("api/matches")]
	[ApiController]
	public class MatchesController : ControllerBase
	{
		private readonly IMatchRepo _repository;
		public MatchesController(IMatchRepo repository)
		{
			_repository = repository;
		}

		
		//GET api/matches
		[HttpGet]
		public ActionResult <IEnumerable<Match>> GetAllMatches()
		{
			var matchItems = _repository.GetAllMatches();
			return Ok(matchItems);
		}

		//GET api/matches/{id}
		[HttpGet("{id}")]
		public ActionResult <Match> GetMatchBy( int id ) {
			var matchItem = _repository.GetMatchBy( id );
			return Ok(matchItem);
		}
	}
}
