using AthleticWebApp.DataAccess.Data;
using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AthleticWebApp.DataAccess.Repositories.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly AthleteContext _context;

        public CountryRepository(AthleteContext context)
        {
            _context = context;
        }

        public async Task<Country> AddCountryAsync(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<Country> DeleteCountryAsync(Country country)
        {
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return country;
        }

        public async Task<List<Country>> GetAllCountryAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country?> GetCountryByIdAsync(int Id)
        {
            return await _context.Countries.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<Country> UpdateCountryAsync(Country country)
        {
            _context.Countries.Update(country);
            
            await _context.SaveChangesAsync();

            return country;
        }
    }
}
