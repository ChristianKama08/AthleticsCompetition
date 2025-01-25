using AthleticWebApp.BusinessLogic.Exceptions;
using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Models;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using AutoMapper;

namespace AthleticWebApp.BusinessLogic.Services.Implementations
{
	public class ResultService : IResultServices
	{
		private readonly IResultRepository _repository;
		private readonly IMapper _mapper;
		

		public ResultService(IResultRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<ResultDto> AddResultAsync(ResultRequest resultRequest)
		{
			var result = await _repository.AddResultAsync(_mapper.Map<Result>(resultRequest));

			return _mapper.Map<ResultDto>(result);
		}

		public async Task<ResultDto> DeleteResultAsync(int id)
		{
			var result = await _repository.GetResultByIdAsync(id);
			if (result is null)
			{

				throw new NotFoundException("There is not any result with this id ");
			}
			var resultDeleted = await _repository.DeleteResultAsync(result);

			return _mapper.Map<ResultDto>(resultDeleted);
		}

		public async Task<List<ResultDto>> GetAllResultAsync()
		{
			var result = await _repository.GetAllResultAsync();
			return _mapper.Map<List<ResultDto>>(result);
		}

		public async Task<ResultDto> GetResultByIdAsync(int id)
		{
			var result = await _repository.GetResultByIdAsync(id);

			if (result is null)
			{
				throw new NotFoundException("There is not any result with this id");
			}

			return _mapper.Map<ResultDto>(result);
		}

		public async Task<ResultDto> UpdateResultAsync(int id, ResultRequest resultRequest)
		{
			var result = await _repository.GetResultByIdAsync(id);

			if (result is null)
			{
				throw new NotFoundException("There is not any result with this id");
			}

			_mapper.Map(resultRequest, result);

			var resultDeleted = await _repository.UpdateResultAsync(result);

			return _mapper.Map<ResultDto>(resultDeleted);
		}

		public async Task<List<WinnerOfEachCompetition>> WinnersOfEachTournment()
		{
			return await _repository.WinnersOfEachTournment();
		}
	}

}
