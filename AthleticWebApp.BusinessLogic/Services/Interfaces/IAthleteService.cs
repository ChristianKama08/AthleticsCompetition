using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;

namespace AthleticWebApp.BusinessLogic.Services.Interfaces
{
    public interface IAthleteService
    {
        Task<AthleteDto> GetAthleteByIdAsync(int id);
        Task<List<AthleteDto>> GetAllAthleteAsync();
        Task<AthleteDto> AddAthleteAsync(AthleteRequest athleteRequest);
        Task<AthleteDto> DeleteAthleteAsync(int id);
        Task<AthleteDto> UpdateAthleteAsync(int id, AthleteRequest athleteRequest);
    }
}
