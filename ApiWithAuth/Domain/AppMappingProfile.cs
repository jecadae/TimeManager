using ApiWithAuth.DTOs;
using ApiWithAuth.Entity;
using AutoMapper;

namespace ApiWithAuth.Domain;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<AppPlan, AppPlanDto>().ReverseMap();
        CreateMap<AppQuest, AppQuestDto>().ReverseMap();
        CreateMap<AppUser, AppUserDto>().ReverseMap();
    }
}