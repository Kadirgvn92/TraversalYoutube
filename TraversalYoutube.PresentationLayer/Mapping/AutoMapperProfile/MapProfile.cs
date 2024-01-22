using AutoMapper;
using TraversalYoutube.DTOLayer.DTOs.AnnouncementDTOs;
using TraversalYoutube.DTOLayer.DTOs.AppUserDTOs;
using TraversalYoutube.DTOLayer.DTOs.CityDTOs;
using TraversalYoutube.DTOLayer.DTOs.ContactDTOs;
using TraversalYoutube.DTOLayer.DTOs.DestinationDTOs;
using TraversalYoutube.DTOLayer.DTOs.ReservaitonDTOs;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Areas.Admin.Models;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Mapping.AutoMapperProfile;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();
        CreateMap<AnnouncementListDTO,Announcement>().ReverseMap();
        CreateMap<AnnouncementUpdateDTO,Announcement>().ReverseMap();
        CreateMap<CreateDestinationViewModel,Destination>().ReverseMap();
        CreateMap<UpdateDestinationViewModel,Destination>().ReverseMap();

        CreateMap<ResetPasswordDTO, AppUser>().ReverseMap();

        CreateMap<DestinationDTO,Destination>().ReverseMap();

        CreateMap<CommentModel,Comment>().ReverseMap();
        CreateMap<GuideModel,Guide>().ReverseMap();
        CreateMap<UserModel,AppUser>().ReverseMap();

        CreateMap<CreateReservationDTO,Reservation>().ReverseMap();

        CreateMap<SendMessageDTO,Contact>().ReverseMap();
        CreateMap<CityAddDTO,City>().ReverseMap();
        CreateMap<AppUserRegisterDTO,AppUser>().ReverseMap();
        CreateMap<AppUserLoginDTO,AppUser>().ReverseMap();
    }
}
