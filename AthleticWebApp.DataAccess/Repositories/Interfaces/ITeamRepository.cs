using AthleticWebApp.DataAccess.Entities;

namespace AthleticWebApp.DataAccess.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team?> GetTeamByIdAsync(int Id);
        Task<List<Team>> GetAllTeamsAsync();
        Task<Team> AddTeamAsync(Team team);
        Task<Team> DeleteTeamAsync(Team team);
        Task<Team> UpdateTeamAsync(Team team);
    }
}
