using AdvertBoard.Dtos;
using AdvertBoard.Dtos.AdvertDtos;
using AdvertBoard.Models;
using AdvertBoard.Models.Advert;
using AutoMapper;

namespace AdvertBoard.Configuration.AutoMapperConfig
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<RegisterViewModel, RegisterUserDto>();
            CreateMap<RegisterUserDto, RegisterViewModel>();
            CreateMap<AdvertToAddViewModel, AddAdvertDto>();
        }
    }
}