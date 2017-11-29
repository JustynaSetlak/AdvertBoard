using AdvertBoard.Dtos;
using AdvertBoard.Dtos.AdvertDtos;
using AdvertBoard.Dtos.CommentDtos;
using AdvertBoard.Models;
using AdvertBoard.Models.Advert;
using AdvertBoard.Models.Comment;
using AutoMapper;

namespace AdvertBoard.Configuration.AutoMapperConfig
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<RegisterViewModel, RegisterUserDto>();
            CreateMap<RegisterUserDto, RegisterViewModel>();
            CreateMap<AddAdvertViewModel, AddAdvertDto>();
            CreateMap<EditAdvertDto, EditAdvertViewModel>();
            CreateMap<EditAdvertViewModel, EditAdvertDto>();
            CreateMap<UserDto, UserViewModel>();
            CreateMap<GetDetailedAdvertDto, GetDetailedAdvertViewModel>();
            CreateMap<CommentDto, CommentViewModel>();
        }
    }
}