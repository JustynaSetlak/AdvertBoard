using AdvertBoard.DbAccess.Models;
using AdvertBoard.Dtos;
using AdvertBoard.Dtos.AdvertDtos;
using AutoMapper;

namespace AdvertBoard.Configuration.AutoMapperConfig
{
    public class BuisinessLogicProfile: Profile
    {
        public BuisinessLogicProfile()
        {
            CreateMap<RegisterUserDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(dest => dest.Email));

            CreateMap<Advert, AdvertDto>();
            CreateMap<AddAdvertDto, Advert>();
            CreateMap<Advert, AdvertDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Category, CategoryDto>();
            CreateMap<EditAdvertDto, Advert>();
            CreateMap<Advert, GetDetailedAdvertDto>();
        }
    }
}