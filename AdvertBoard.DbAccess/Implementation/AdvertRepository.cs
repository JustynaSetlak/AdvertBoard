using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AdvertBoard.DbAccess.Interfaces;
using AdvertBoard.DbAccess.Models;

namespace AdvertBoard.DbAccess.Implementation
{
    public class AdvertRepository: IAdvertRepository
    {
        private readonly AdvertBoardContext _context;
        public AdvertRepository(AdvertBoardContext context)
        {
            _context = context;
        }

        public List<Advert> GetAdvertsFromUser(string userId)
        {
            var adverts = _context.Adverts
                .Where(x => x.OwnerId == userId
                         && x.IsDeleted == false)
                .Include(x => x.Category)
                .ToList();

            return adverts;
        }

        public void Update(Advert advert)
        {
            _context.Entry(advert).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool DeleteAdvert(int id, string userId)
        {
            var advert = GetAdvert(id);
            if (advert == null || advert.OwnerId!=userId)
            {
                return false;
            }
            advert.IsDeleted = true;

            return _context.SaveChanges() > 0;
        }

        public Advert AddAdvert(Advert advert)
        {
            _context.Adverts.Add(advert);
            _context.SaveChanges();
            return advert;
        }

        public Advert GetAdvert(int id)
        {
            var advert = _context.Adverts
                .Include(x => x.Owner)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == id
                                  && x.IsDeleted == false);
                                         
            return advert;
        }
    }
}