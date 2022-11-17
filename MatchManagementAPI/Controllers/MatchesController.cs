using AutoMapper;
using MatchManagementAPI.Data;
using MatchManagementAPI.Dtos;
using MatchManagementAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MatchManagementAPI.Controllers
{
	[Route("api/matches")]
	[ApiController]
	public class MatchesController : ControllerBase
	{
		private readonly IMatchRepo _repository;
		private readonly IMapper _mapper;

		public MatchesController(IMatchRepo repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		
		//GET api/matches
		[HttpGet]
		public ActionResult <IEnumerable<MatchReadDto>> GetAllMatches()
		{
			var matchItems = _repository.GetAllMatches();
			return Ok(_mapper.Map<IEnumerable<MatchReadDto>>(matchItems));
		}

		//GET api/matches/{id}
		[HttpGet("{id}", Name = "GetMatchBy")]
		public ActionResult <MatchReadDto> GetMatchBy( int id ) {
			var matchItem = _repository.GetMatchBy( id );
			if (matchItem != null)
			{
				return Ok(_mapper.Map<MatchReadDto>( matchItem ));

			}else 
			{ 
				return NotFound(); 
			}
		}

		// POST api/matches
		[HttpPost]
		public ActionResult <MatchReadDto> CreateMatch(MatchCreateDto matchCreateDto) 
		{
			var matchModel = _mapper.Map<Match>(matchCreateDto);
			_repository.CreateMatch(matchModel);
			_repository.SaveChanges();

			var matchReadDto = _mapper.Map<MatchReadDto>(matchModel);

			return CreatedAtRoute(nameof(GetMatchBy), new { ID = matchReadDto.ID }, matchReadDto);
			//return Ok(matchReadDto);
		}

		//PUT api/matches/{id}
		[HttpPut("{id}")]
		public ActionResult<MatchReadDto> UpdateMatch(int id, MatchUpdateDto matchUpDateDto)
		{
			var matchModelFromRepo = _repository.GetMatchBy(id);
			if (matchModelFromRepo != null)
			{
				return NotFound();
			}

			_mapper.Map(matchUpDateDto, matchModelFromRepo);
			_repository.UpdateMatch(matchModelFromRepo);
			_repository.SaveChanges();	

			return NoContent();
		}

		//PATCH api/commands/{id}
		[HttpPatch("{id}")]
		public ActionResult PartialMatchUpdate(int id, JsonPatchDocument<MatchUpdateDto> patchDoc)
		{
			var matchModelFromRepo = _repository.GetMatchBy(id);
			if (matchModelFromRepo == null)
			{
				return NotFound();
			}

			var matchToPatch = _mapper.Map<MatchUpdateDto>(matchModelFromRepo);
			patchDoc.ApplyTo(matchToPatch, ModelState);

			if (!TryValidateModel(matchToPatch))
			{
				return ValidationProblem(ModelState);
			}

			_mapper.Map(matchToPatch, matchModelFromRepo);

			_repository.UpdateMatch(matchModelFromRepo);

			_repository.SaveChanges();

			return NoContent();
		}

		//DELETE api/commands/{id}
		[HttpDelete("{id}")]
		public ActionResult DeleteMatch(int id)
		{
			var matchModelFromRepo = _repository.GetMatchBy(id);
			if (matchModelFromRepo == null)
			{
				return NotFound();
			}
			_repository.DeleteMatch(matchModelFromRepo);
			_repository.SaveChanges();

			return NoContent();
		}

	}
}
