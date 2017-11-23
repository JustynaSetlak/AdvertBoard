using AdvertBoard.DbAccess.Models;
using AdvertBoard.Dtos;
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
        }
    }
}