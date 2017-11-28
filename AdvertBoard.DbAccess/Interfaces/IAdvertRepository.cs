using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertBoard.DbAccess.Models;

namespace AdvertBoard.DbAccess.Interfaces
{
    public interface IAdvertRepository
    {
        List<Advert> GetAdvertsFromUser(string userId);
        void Update(Advert advert);
        void DeleteAdvert();
        Advert AddAdvert(Advert advert);
        Advert GetAdvert(int id);
    }
}
