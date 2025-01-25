using AthleticWebApp.DataAccess.Data;
using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Models;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AthleticWebApp.DataAccess.Repositories.Implementations
{
    public class ResultRepository : IResultRepository
    {
        private readonly AthleteContext _context;

        public ResultRepository(AthleteContext context)
        {
            _context = context;
        }

        public async Task<Result> AddResultAsync(Result result)
        {
            _context.Results.Add(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<Result> DeleteResultAsync(Result result)
        {
            _context.Results.Remove(result);
            await _context.SaveChangesAsync();

            return result;

        }

        public async Task<List<Result>> GetAllResultAsync()
        {
            return await _context.Results.
                Include(x => x.Competition)
                .ToListAsync();
        }

        public async Task<Result?> GetResultByIdAsync(int id)
        {
            return await  _context.Results.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Result> UpdateResultAsync(Result result)
        {
            _context.Results.Update(result);
            await _context.SaveChangesAsync();

            return result;
        }

		public async Task<List<WinnerOfEachCompetition>> WinnersOfEachTournment()
		{
            var winnersResult = await _context.Results
                .Include(x => x.Competition)
                    .ThenInclude(y => y.Athlete)
                .GroupBy(xy => new
                {
                    NameCompetition = xy.Competition.CompetitionName,
                    AthleteName = xy.Competition.Athlete.FullName
                })
                .Select(grp => new
                {
                    CompetitionName = grp.Key.NameCompetition,
                    NameOfAthlete = grp.Key.AthleteName,
                    Score = grp.Max(x => Convert.ToString(x.MeasurementType)) // Convert to numeric value
                }).ToListAsync();

            // Create WinnerOfEachCompetition instances
            var winners = winnersResult.Select(w => new WinnerOfEachCompetition
            {
                CompetitionName = w.CompetitionName,
                AthleteName = w.NameOfAthlete,
                Score = w.Score,
            }).ToList();

            return winners;
            //    .Select(grp => new WinnerOfEachCompetition
            //    {
            //        CompetitionName = grp.Key.NameCompetition,
            //        AthleteName = grp.Key.AthleteName,
            //        Score = grp.Max(x => x.MeasurementType)

            //    }).ToListAsync();

            //return winnersResult;
        }
	}
}
