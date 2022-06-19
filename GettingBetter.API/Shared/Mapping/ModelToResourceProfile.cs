using AutoMapper;
using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Resources;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Resources;

namespace GettingBetter.API.Shared.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Coach, CoachResource>();
        CreateMap<Student, StudentResource>();
        CreateMap<Cyber, CyberResource>();
        CreateMap<Tournament, TournamentResource>();
        CreateMap<RegisterTournament, RegisterTournamentResource>();
    } 
}