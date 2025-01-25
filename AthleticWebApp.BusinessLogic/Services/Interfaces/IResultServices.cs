using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.DataAccess.Models;

namespace AthleticWebApp.BusinessLogic.Services.Interfaces
{
	public interface IResultServices
	{
		Task<ResultDto> GetResultByIdAsync(int id);
		Task<List<ResultDto>> GetAllResultAsync();
		Task<ResultDto> AddResultAsync(ResultRequest resultRequest);
		Task<ResultDto> UpdateResultAsync(int id, ResultRequest resultRequest);
		Task<ResultDto> DeleteResultAsync(int id);
		Task<List<WinnerOfEachCompetition>> WinnersOfEachTournment();
	}
}
