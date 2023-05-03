using ApiWithAuth.DTOs;
using ApiWithAuth.Entity;
using AutoMapper;

namespace ApiWithAuth;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<AppPlan, AppPlanDto>().ReverseMap();
        CreateMap<AppQuest, AppQuestDto>().ReverseMap();
    }
}