using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;

namespace AthleticWebApp.BusinessLogic.Services.Interfaces
{
	public interface ICountryService
	{
		Task<CountryDto> GetCountryByIdAsync(int id);
		Task<List<CountryDto>> GetAllCountryAsync();
		Task<CountryDto> AddCountryAsync(CountryRequest countryRequest);
		Task<CountryDto> DeleteCountryAsync(int id);
		Task<CountryDto> UpdateCountryAsync(int id, CountryRequest countryRequest);

	}
}
