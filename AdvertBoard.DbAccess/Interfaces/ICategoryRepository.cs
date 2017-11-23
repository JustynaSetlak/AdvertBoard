using System.Collections.Generic;
using System.Linq;
using AdvertBoard.DbAccess.Models;

namespace AdvertBoard.DbAccess.Interfaces
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        List<Advert> GetAllAdvertsFromCategory(string name, string userId);
    }
}