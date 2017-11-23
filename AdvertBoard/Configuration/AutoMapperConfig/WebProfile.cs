using AdvertBoard.Dtos;
using AdvertBoard.Models;
using AutoMapper;

namespace AdvertBoard.Configuration.AutoMapperConfig
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<RegisterViewModel, RegisterUserDto>();
            CreateMap<RegisterUserDto, RegisterViewModel>();
        }
    }
}