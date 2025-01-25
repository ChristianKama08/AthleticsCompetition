using AthleticWebApp.BusinessLogic.Exceptions;
using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using AutoMapper;
using System.Xml.Serialization;

namespace AthleticWebApp.BusinessLogic.Services.Implementations
{
    public class AthleteService : IAthleteService
    {
        private readonly IAthleteRepository _repository;
        private readonly IMapper _mapper;
        public AthleteService(IMapper mapper, IAthleteRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //avant d'ajouter un athlete tu cherches dans la BD si cette athlte existe deja, si il existe
        //tu renvois le alreadyExistException, s'il n'existe pas tu l'ajoute 
        public async Task<AthleteDto> AddAthleteAsync(AthleteRequest athleteRequest)
        {
            var athlete = await _repository.GetAthleteByFullName(athleteRequest.FullName);

            if(athlete is not null)
            {
                throw new AlreadyExistException("This Athlete alreadyExist");
            }

            var athleteAdded = await _repository.AddAthleteAsync(_mapper.Map<Athlete>(athleteRequest));

            return _mapper.Map<AthleteDto>(athleteAdded);
        }

        public async Task<AthleteDto> DeleteAthleteAsync(int id)
        {
            var athlete = await _repository.GetAthleteByIdAsync(id);

            if (athlete is null)
            {
                throw new NotFoundException("There is not an athlete with that id");
            }

            var athleteDeleted = await _repository.DeleteAthleteAsync(athlete);

            return _mapper.Map<AthleteDto>(athleteDeleted);
        }

        public async Task<List<AthleteDto>> GetAllAthleteAsync()
        {
            var athletes = await _repository.GetAllAthleteAsync();

            return _mapper.Map<List<AthleteDto>>(athletes);
        }

        public async Task<AthleteDto> GetAthleteByIdAsync(int id)
        {
            var athlete = await _repository.GetAthleteByIdAsync(id);

            if (athlete is null)
            {
                throw new NotFoundException("There is not an athlete with that id");
            }

            return _mapper.Map<AthleteDto>(athlete);
        }

        public async Task<AthleteDto> UpdateAthleteAsync(int id, AthleteRequest athleteRequest)
        {
            var athlete = await _repository.GetAthleteByIdAsync(id);

            if (athlete is null)
            {
                throw new NotFoundException("There is not athlete with that id");
            }

            _mapper.Map(athleteRequest, athlete);

            var athleteUpdated = await _repository.UpdateAthleteAsync(athlete);

            return _mapper.Map<AthleteDto>(athleteUpdated);
        }
    }
}
