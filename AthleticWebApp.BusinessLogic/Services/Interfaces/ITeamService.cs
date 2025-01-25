using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;

namespace AthleticWebApp.BusinessLogic.Services.Interfaces
{
	public interface ITeamService
	{
		Task<TeamDto> GetTeamByIdAsync(int id);
		Task<List<TeamDto>> GetAllTeamAsync();
		Task<TeamDto> AddTeamAsync(TeamRequest teamRequest);
		Task<TeamDto> UpdateTeamAsync(int id, TeamRequest teamRequest);
		Task<TeamDto> DeleteTeamAsync(int id);
	}
}
