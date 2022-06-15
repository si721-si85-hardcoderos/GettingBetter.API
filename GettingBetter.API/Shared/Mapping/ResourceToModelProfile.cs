﻿using AutoMapper;
using GettingBetter.API.GettingBetter_System.Domain.Models;
using GettingBetter.API.GettingBetter_System.Resources;
using GettingBetter.API.Tournaments_System.Domain.Models;
using GettingBetter.API.Tournaments_System.Resources;

namespace GettingBetter.API.Shared.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveCoachResource, Coach>();
        CreateMap<SaveStudentResource, Student>();
        CreateMap<SaveCyberResource, Cyber>();
        CreateMap<SaveTournamentResource, Tournament>();
    }
}