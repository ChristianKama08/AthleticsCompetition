using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Models;

namespace AthleticWebApp.DataAccess.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<Result?> GetResultByIdAsync(int id);
        Task<List<Result>> GetAllResultAsync();
        Task<Result> AddResultAsync(Result result);
        Task<Result> UpdateResultAsync(Result result);
        Task<Result> DeleteResultAsync(Result result);
        Task<List<WinnerOfEachCompetition>> WinnersOfEachTournment();

	}
}
