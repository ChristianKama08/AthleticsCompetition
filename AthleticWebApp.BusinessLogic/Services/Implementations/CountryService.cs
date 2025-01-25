using AthleticWebApp.BusinessLogic.Exceptions;
using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using AutoMapper;

namespace AthleticWebApp.BusinessLogic.Services.Implementations
{
	public class CountryService : ICountryService
	{
		private readonly ICountryRepository _countryRepository;
		private readonly IMapper _mapper;
		public CountryService(IMapper mapper, ICountryRepository countryRepository)
		{
			_mapper = mapper;
			_countryRepository = countryRepository;
		}

		public async Task<CountryDto> AddCountryAsync(CountryRequest countryRequest)
		{
			var country = await _countryRepository.AddCountryAsync(_mapper.Map<Country>(countryRequest));

			return _mapper.Map<CountryDto>(country);
		}

		public async Task<CountryDto> DeleteCountryAsync(int id)
		{
			var country = await _countryRepository.GetCountryByIdAsync(id);

			if (country is null)
			{
				throw new NotFoundException("There is not an country with that id");
			}

			var countryDeleted = await _countryRepository.DeleteCountryAsync(country);

			return _mapper.Map<CountryDto>(countryDeleted);
		}

		public async Task<List<CountryDto>> GetAllCountryAsync()
		{
			var country = await _countryRepository.GetAllCountryAsync();

			return _mapper.Map<List<CountryDto>>(country);
		}

		public async Task<CountryDto> GetCountryByIdAsync(int id)
		{
			var country = await _countryRepository.GetCountryByIdAsync(id);

			if (country is null)
			{
				throw new NotFoundException("There is not an country with that id ");

			}
			return _mapper.Map<CountryDto>(country);
		}

		public async Task<CountryDto> UpdateCountryAsync(int id, CountryRequest countryRequest)
		{
			var country = await _countryRepository.GetCountryByIdAsync(id);

			if (country is null)
			{

				throw new NotFoundException("There is not country wiht that id");
			}

			_mapper.Map(countryRequest, country);

			var countryUpdated = await _countryRepository.UpdateCountryAsync(country);

			return _mapper.Map<CountryDto>(countryUpdated);
		}
	}
}
