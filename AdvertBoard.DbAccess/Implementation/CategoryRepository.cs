using System.Collections.Generic;
using System.Linq;
using AdvertBoard.DbAccess.Interfaces;
using AdvertBoard.DbAccess.Models;

namespace AdvertBoard.DbAccess.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AdvertBoardContext _context;

        public CategoryRepository(AdvertBoardContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Advert> GetAllAdvertsFromCategory(string name, string userId)
        {
            return _context.Adverts
                .Where(x => x.Category.Name.Equals(name)
                        && !x.Owner.Id.Equals(userId))
                .ToList();
        }
    }
}