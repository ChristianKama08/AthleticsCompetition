using AthleticWebApp.BusinessLogic.Profiles.DTOs;
using AthleticWebApp.BusinessLogic.Requests;
using AthleticWebApp.DataAccess.Entities;
using AutoMapper;

namespace AthleticWebApp.BusinessLogic.Profiles.MappingConfigurations
{
    public class ApplicationConfiguration : Profile
    {
        public ApplicationConfiguration()
        {
            //mapping configuration for athlete 
            CreateMap<AthleteRequest, Athlete>()    
                .ReverseMap();

            CreateMap<Athlete, AthleteDto>()
                .ReverseMap();

            //
           CreateMap<CountryRequest, Country>()
                .ReverseMap();

            CreateMap<Country, CountryDto>()
                .ReverseMap();

            //
           CreateMap<TeamRequest, Team>()
                .ReverseMap();

            CreateMap<Team, TeamDto>()
                .ReverseMap();

            //
            CreateMap<ResultRequest, Result>()
                .ReverseMap();

            CreateMap<Result, ResultDto>()
                .ForMember( dest => dest.CompetitonName, opt =>
                    opt.MapFrom(src => src.Competition.CompetitionName)) 
                .ReverseMap();

            //
            CreateMap<CompetitionRequest, Competition>()
                .ReverseMap();

            CreateMap<Competition, CompetitionDto>()
                .ForMember(dest => dest.AthleteName, opt =>
                    opt.MapFrom(src => src.Athlete.FullName))
                .ReverseMap();

        }
    }
}
