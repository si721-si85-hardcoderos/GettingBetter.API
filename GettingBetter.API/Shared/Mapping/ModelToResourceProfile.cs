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
//using GettingBetter.API.Event_System.Resources;
using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Resources;
using GettingBetter.API.Learning_System.Domain.Models;
using GettingBetter.API.Learning_System.Persistence.Repositories;
using GettingBetter.API.Learning_System.Resources;
using GettingBetter.API.Tournament_System.Domain.Models;
using GettingBetter.API.Tournament_System.Resources;

namespace GettingBetter.API.Shared.Mapping
{

    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Coach, CoachResource>();
            CreateMap<Student, StudentResource>();
            CreateMap<Cyber, CyberResource>();
            CreateMap<Tournament, TournamentResource>();
            CreateMap<RegisterTournament, RegisterTournamentResource>();
            CreateMap<Advertisement, AdvertisementResource>();
            CreateMap<Advisory, AdvisoryResource>();
            CreateMap<Event, EventResource>();
            CreateMap<Tournament, TournamentResource>();
            CreateMap<Learning, LearningResource>();
        }
    }
}