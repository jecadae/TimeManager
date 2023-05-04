using ApiWithAuth.DTOs;
using ApiWithAuth.Domain.Models;
using AutoMapper;

namespace ApiWithAuth.Domain;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<AppQuest, AppQuestDto>().ReverseMap();
        CreateMap<AppPlan, AppPlanDto>()
            .ForMember(dest=>dest.QuestsDto,a=>a.MapFrom(src=> src.Quests))
            .ReverseMap();
        CreateMap<AppUser, AppUserDto>().ReverseMap();
    }
}