using AthleticWebApp.DataAccess.Entities;

namespace AthleticWebApp.DataAccess.Repositories.Interfaces
{
    public interface IAthleteRepository
    {
        Task<Athlete?> GetAthleteByIdAsync(int Id);
        Task<List<Athlete>> GetAllAthleteAsync();
        Task<Athlete?> GetAthleteByFullName(string fullName);
        Task<Athlete> AddAthleteAsync(Athlete athlete);
        Task<Athlete> DeleteAthleteAsync(Athlete athlete);
        Task<Athlete> UpdateAthleteAsync(Athlete athlete);

    }
}
