using System;
using System.Collections.Generic;
using AdvertBoard.BusinessLogic.Services.Interfaces;
using AdvertBoard.DbAccess.Interfaces;
using AdvertBoard.DbAccess.Models;
using AdvertBoard.Dtos;
using AdvertBoard.Dtos.AdvertDtos;
using AutoMapper;

namespace AdvertBoard.BusinessLogic.Services
{
    public class AdvertService: IAdvertService
    {
        private readonly IAdvertRepository _advertRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public AdvertService(IAdvertRepository advertRepository, IUserRepository userRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _advertRepository = advertRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _categoryRepository = categoryRepository;
        }

        public AdvertDto AddAdvert(AddAdvertDto advertToAddDto, string userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return null;
            }
            var advertToAdd = _mapper.Map<AddAdvertDto, Advert>(advertToAddDto);
            advertToAdd.DateOfCreation = DateTime.UtcNow;
            advertToAdd.DateOfLastModification = DateTime.UtcNow;
            advertToAdd.Owner = user;
            advertToAdd.OwnerId = userId;
            advertToAdd.Category = _categoryRepository.GetCategory(advertToAdd.CategoryId);
            var addedAdvert = _advertRepository.AddAdvert(advertToAdd);
            var advertDto = _mapper.Map<Advert, AdvertDto>(addedAdvert);
            return advertDto;
        }

        public List<GetUserAdvertDto> GetAdvertsFromUser(string userId)
        {
            var advertsFromUser = _advertRepository.GetAdvertsFromUser(userId);
            var advertsDto = _mapper.Map<List<Advert>, List<GetUserAdvertDto>>(advertsFromUser);
            return advertsDto;
        }

        public EditAdvertDto GetAdvertToEdit(int id)
        {
            var advert = _advertRepository.GetAdvert(id);
            var advertDto = _mapper.Map<Advert, EditAdvertDto>(advert);
            return advertDto;
        }

        public void EditAdvert(EditAdvertDto advertToEdit)
        {
            advertToEdit.DateOfLastModification = DateTime.UtcNow;
            var advert = _mapper.Map<EditAdvertDto, Advert>(advertToEdit);
            _advertRepository.Update(advert);
        }

        public GetDetailedAdvertDto GetAdvertDetails(int id)
        {
            var advert = _advertRepository.GetAdvert(id);
            var advertDto = _mapper.Map<Advert, GetDetailedAdvertDto>(advert);
            return advertDto;
        }
    }
}