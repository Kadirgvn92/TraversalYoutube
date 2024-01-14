using AutoMapper;
using TraversalYoutube.DTOLayer.DTOs.AnnouncementDTOs;
using TraversalYoutube.DTOLayer.DTOs.AppUserDTOs;
using TraversalYoutube.DTOLayer.DTOs.CityDTOs;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Mapping.AutoMapperProfile;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<AnnouncementAddDTO,Announcement>().ReverseMap();
        CreateMap<CityAddDTO,City>().ReverseMap();
        CreateMap<AppUserRegisterDTO,AppUser>().ReverseMap();
        CreateMap<AppUserLoginDTO,AppUser>().ReverseMap();
    }
}
