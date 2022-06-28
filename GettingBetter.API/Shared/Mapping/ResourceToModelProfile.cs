using AutoMapper;
using GettingBetter.API.Advertisement_System.Domain.Models;
using GettingBetter.API.Advertisement_System.Resources;
//using GettingBetter.API.Advertisement_System.Domain.Models;
//using GettingBetter.API.Advertisement_System.Resources;
using GettingBetter.API.Advisory_System.Domain.Models;
using GettingBetter.API.Advisory_System.Resources;
using GettingBetter.API.Event_System.Domain.Models;
using GettingBetter.API.Event_System.Resources;
//using GettingBetter.API.Event_System.Domain;
using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Resources;
using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Learning_System.Resources;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Resources;

namespace GettingBetter.API.Shared.Mapping
{

    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCoachResource, Coach>();
            CreateMap<SaveStudentResource, Student>();
            CreateMap<SaveCyberResource, Cyber>();
            CreateMap<SaveTournamentResource, Tournament>();
            CreateMap<SaveRegisterTournamentResource, RegisterTournament>();
            CreateMap<SaveEventResource, Event>();
            CreateMap<SaveAdvertisementResource, Advertisement>();
            CreateMap<SaveAdvisoryResource, Advisory>();
            CreateMap<SaveLearningResource, Learning>();
                
        }
    }
}