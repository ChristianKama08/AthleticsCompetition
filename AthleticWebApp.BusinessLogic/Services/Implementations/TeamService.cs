using AthleticWebApp.BusinessLogic.Exceptions;
using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using AutoMapper;

namespace AthleticWebApp.BusinessLogic.Services.Implementations
{
	public class TeamService : ITeamService
	{
		private readonly ITeamRepository _repository;
		private readonly IMapper _mapper;
		public TeamService(IMapper mapper, ITeamRepository repository)
		{
			_mapper = mapper;
			_repository = repository;
		}

		public async Task<TeamDto> AddTeamAsync(TeamRequest teamRequest)
		{
			var team = await _repository.AddTeamAsync(_mapper.Map<Team>(teamRequest));
			return _mapper.Map<TeamDto>(team);
		}

		public async Task<TeamDto> DeleteTeamAsync(int id)
		{
			var team = await _repository.GetTeamByIdAsync(id);

			if (team is null)
			{
				throw new NotFoundException("There is not team with this id ");

			}
			var teamDeleted = await _repository.DeleteTeamAsync(team);

			return _mapper.Map<TeamDto>(teamDeleted);

		}

		public async Task<List<TeamDto>> GetAllTeamAsync()
		{
			var team = await _repository.GetAllTeamsAsync();
			return _mapper.Map<List<TeamDto>>(team);
		}

		public async Task<TeamDto> GetTeamByIdAsync(int id)
		{
			var team = await _repository.GetTeamByIdAsync(id);

			if (team is null)
			{
				throw new NotFoundException("There is not team with this id");
			}
			return _mapper.Map<TeamDto>(team);
		}

		public async Task<TeamDto> UpdateTeamAsync(int id, TeamRequest teamRequest)
		{
			var team = await _repository.GetTeamByIdAsync(id);

			if (team is null)
			{
				throw new NotFoundException("There is not team with this id");
			}
			_mapper.Map(teamRequest, team);

			var teamupdated = await _repository.UpdateTeamAsync(team);

			return _mapper.Map<TeamDto>(teamupdated);
		}
	}
}
