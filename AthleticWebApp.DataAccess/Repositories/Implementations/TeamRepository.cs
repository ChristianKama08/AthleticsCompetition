using AthleticWebApp.DataAccess.Data;
using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AthleticWebApp.DataAccess.Repositories.Implementations
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AthleteContext _context;

        public TeamRepository(AthleteContext context)
        {
            _context = context;
        }

        public async Task<Team> AddTeamAsync(Team team)
        {
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<Team> DeleteTeamAsync(Team team)
        {
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team?> GetTeamByIdAsync(int Id)
        {
            return await _context.Teams.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<Team> UpdateTeamAsync(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();

            return team;
        }
    }
}
