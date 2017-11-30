using System.Collections.Generic;
using AdvertBoard.DbAccess.Models;
using AdvertBoard.Dtos;
using AdvertBoard.Dtos.AdvertDtos;

namespace AdvertBoard.BusinessLogic.Services.Interfaces
{
    public interface IAdvertService
    {
        AdvertDto AddAdvert(AddAdvertDto advertToAddDto, string userId);
        List<GetUserAdvertDto> GetAdvertsFromUser(string userId);
        EditAdvertDto GetAdvertToEdit(int id);
        void EditAdvert(EditAdvertDto advertToEdit);
        GetDetailedAdvertDto GetAdvertDetails(int id);
        bool DeleteAdvert(int id, string userId);
    }
}