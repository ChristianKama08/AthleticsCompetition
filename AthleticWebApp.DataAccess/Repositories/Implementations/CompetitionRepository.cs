using AthleticWebApp.DataAccess.Data;
using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Models;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AthleticWebApp.DataAccess.Repositories.Implementations
{
	public class CompetitionRepository : ICompetitionRepository
	{
		private readonly AthleteContext _context;

		public CompetitionRepository(AthleteContext context)
		{
			_context = context;
		}

		public async Task<Competition> AddcompetitionAsync(Competition competition)
		{
			_context.Competitions.Add(competition);
			await _context.SaveChangesAsync();

			return competition;
		}

		public async Task<Competition> DeleteCompetitionAsync(Competition competition)
		{
			_context.Competitions.Remove(competition);
			await _context.SaveChangesAsync();

			return competition;
		}

		public async Task<List<Competition>> GetAllCompetitionAsync()
		{
			return await _context.Competitions
				.Include(x => x.Athlete)
				//.Where(a => a.Athlete.FullName != null)
				.ToListAsync();
		}

		public async Task<Competition?> GetCompetitonByIdAsync(int Id)
		{
			return await _context.Competitions.FirstOrDefaultAsync(c => c.Id == Id);
		}

		public async Task<Competition> UpdateCompetitionAsync(Competition competition)
		{
			_context.Competitions.Update(competition);
			await _context.SaveChangesAsync();

			return competition;
		}
	}
}
