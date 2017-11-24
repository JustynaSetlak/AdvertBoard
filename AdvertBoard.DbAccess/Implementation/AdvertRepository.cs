﻿using System.Collections.Generic;
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
                .Where(x => x.OwnerId == userId)
                .Include(x => x.Category)
                .ToList();

            return adverts;
        }

        public Advert ModifyAdvert()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAdvert()
        {
            throw new System.NotImplementedException();
        }

        public Advert AddAdvert(Advert advert)
        {
            _context.Adverts.Add(advert);
            _context.SaveChanges();
            return advert;
        }
    }
}