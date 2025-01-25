using AthleticWebApp.DataAccess.Entities;

namespace AthleticWebApp.DataAccess.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        Task<Country?> GetCountryByIdAsync(int Id);
        Task<List<Country>> GetAllCountryAsync();
        Task<Country> AddCountryAsync(Country country);
        Task<Country> DeleteCountryAsync(Country country);
        Task<Country> UpdateCountryAsync(Country country);

    }
}
