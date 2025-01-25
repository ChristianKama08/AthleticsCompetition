using AthleticWebApp.DataAccess.Entities;

namespace AthleticWebApp.DataAccess.Repositories.Interfaces
{
	public interface ICompetitionRepository
	{
		Task<Competition?> GetCompetitonByIdAsync(int Id);
		Task<List<Competition>> GetAllCompetitionAsync();
		Task<Competition> AddcompetitionAsync(Competition competition);
		Task<Competition> DeleteCompetitionAsync(Competition competition);
		Task<Competition> UpdateCompetitionAsync(Competition competition);
	}
}
