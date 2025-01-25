using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;

namespace AthleticWebApp.BusinessLogic.Services.Interfaces
{
	public interface ICompetitionService
	{
		Task<CompetitionDto> GetCompetitionByIdAsync(int id);
		Task<List<CompetitionDto>> GetAllCompetitionAsync();
		Task<CompetitionDto> AddCompetitionAsync(CompetitionRequest competitionRequest);
		Task<CompetitionDto> DeleteCompetitionAsync(int id);
		Task<CompetitionDto> UpdateCompetitionAsync(int id, CompetitionRequest competitionRequest);
	}
}
