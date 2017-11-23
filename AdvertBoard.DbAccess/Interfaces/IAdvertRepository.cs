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
        List<Advert> GetAdvertsFromUser();
        Advert ModifyAdvert();
        void DeleteAdvert();
        Advert AddAdvert();
    }
}
