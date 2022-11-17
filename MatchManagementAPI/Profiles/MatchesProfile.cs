using AutoMapper;
using MatchManagementAPI.Dtos;
using MatchManagementAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MatchManagementAPI.Profiles
{
	public class MatchesProfile : Profile
	{
		public MatchesProfile() 
		{
			//Source -> Target
			CreateMap<Match, MatchReadDto>();
			CreateMap<MatchCreateDto, Match>();
			CreateMap<MatchUpdateDto, Match>();
			CreateMap<Match, MatchUpdateDto>();

		}

	}
}
