using AthleticWebApp.DataAccess.Data;
using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AthleticWebApp.DataAccess.Repositories.Implementations
{

    public class AthleteRepository : IAthleteRepository
    {
        private readonly AthleteContext _context;

        public AthleteRepository(AthleteContext context)
        {
            _context = context;
        }

        public async Task<Athlete> AddAthleteAsync(Athlete athlete)
        {
            _context.Athletes.Add(athlete);
            await _context.SaveChangesAsync();

            return athlete;
        }

        public async Task<Athlete> DeleteAthleteAsync(Athlete athlete)
        {
            _context.Athletes.Remove(athlete);
            await _context.SaveChangesAsync();

            return athlete;
        }

        public async Task<List<Athlete>> GetAllAthleteAsync()
        {
            return await _context.Athletes
                .Include(c => c.Country)
                .Include(t => t.Team)
                .ToListAsync();
        }

        public async Task<Athlete?> GetAthleteByFullName(string fullName)
        {
            return await _context.Athletes.FirstOrDefaultAsync(c => c.FullName == fullName);
        }

        public async Task<Athlete?> GetAthleteByIdAsync(int Id)
        {
            return await _context.Athletes.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<Athlete> UpdateAthleteAsync(Athlete athlete)
        {
            _context.Athletes.Update(athlete);
            await _context.SaveChangesAsync();

            return athlete;
        }
    }
}
