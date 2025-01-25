using AthleticWebApp.BusinessLogic.Exceptions;
using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.BusinessLogic.Services.Interfaces;
using AthleticWebApp.DataAccess.Entities;
using AthleticWebApp.DataAccess.Repositories.Interfaces;
using AutoMapper;

namespace AthleticWebApp.BusinessLogic.Services.Implementations
{
	public class CompetitionService : ICompetitionService
	{
		private readonly ICompetitionRepository _repository;
		private readonly IMapper _mapper;
		public CompetitionService(ICompetitionRepository repository, IMapper mapper)
		{
			_mapper = mapper;
			_repository = repository;
		}

		//Method a tester
		public async Task<CompetitionDto> AddCompetitionAsync(CompetitionRequest competitionRequest)
		{
			var competitions = await _repository.GetAllCompetitionAsync();

			var alreadyExistCompetition = competitions.Any(c => c.Athlete.Id == competitionRequest.AthleteId);

			if (alreadyExistCompetition)
			{
				throw new AlreadyExistException("A competition with the name provided already exist");
			}

			var competition = await _repository.AddcompetitionAsync(_mapper.Map<Competition>(competitionRequest));

			return _mapper.Map<CompetitionDto>(competition);
		}

		public async Task<CompetitionDto> DeleteCompetitionAsync(int id)
		{
			var competittion = await _repository.GetCompetitonByIdAsync(id);

			if (competittion is null)
			{
				throw new NotFoundException("There is not competition with this id");

			}

			var competitionDeleted = await _repository.DeleteCompetitionAsync(competittion);

			return _mapper.Map<CompetitionDto>(competitionDeleted);
		}

		public async Task<List<CompetitionDto>> GetAllCompetitionAsync()
		{
			var competition = await _repository.GetAllCompetitionAsync();

			return _mapper.Map<List<CompetitionDto>>(competition);
		}


		public async Task<CompetitionDto> GetCompetitionByIdAsync(int id)
		{
			var competition = await _repository.GetCompetitonByIdAsync(id);

			if (competition is null)
			{
				throw new NotFoundException("There is not competition with this id");
			}

			return _mapper.Map<CompetitionDto>(competition);
		}

		public async Task<CompetitionDto> UpdateCompetitionAsync(int id, CompetitionRequest competitionRequest)
		{
			var competition = await _repository.GetCompetitonByIdAsync(id);

			if (competition is null)
			{

				throw new NotFoundException("There is not competition with this id ");
			}

			_mapper.Map(competitionRequest, competition);

			var competitionUpdated = await _repository.UpdateCompetitionAsync(competition);

			return _mapper.Map<CompetitionDto>(competitionUpdated);
		}
	}
}
