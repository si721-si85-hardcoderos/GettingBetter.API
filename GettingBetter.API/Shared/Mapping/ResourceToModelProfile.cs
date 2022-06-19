using AutoMapper;
using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Resources;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Resources;

namespace GettingBetter.API.Shared.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCoachResource, Coach>();
        CreateMap<SaveStudentResource, Student>();
        CreateMap<SaveCyberResource, Cyber>();
        CreateMap<SaveTournamentResource, Tournament>();
        CreateMap<SaveRegisterTournamentResource, RegisterTournament>();
    }
}