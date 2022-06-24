using AutoMapper;
using GettingBetter.API.Advisory_System.Domain.Models;
using GettingBetter.API.Advisory_System.Resources;
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
        CreateMap<SaveAdvisoryResource, Advisory>();
        CreateMap<SaveRegisterTournamentResource, RegisterTournament>();
    }
}