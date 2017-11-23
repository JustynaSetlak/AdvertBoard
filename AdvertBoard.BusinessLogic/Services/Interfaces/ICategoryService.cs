using System.Collections.Generic;
using AdvertBoard.Dtos;

namespace AdvertBoard.BusinessLogic.Services.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategories();

        List<AdvertDto> GetAdvertsFromCategory(string categoryName, string userId);
    }
}