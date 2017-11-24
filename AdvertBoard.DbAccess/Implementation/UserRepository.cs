using System.Linq;
using AdvertBoard.DbAccess.Interfaces;
using AdvertBoard.DbAccess.Models;

namespace AdvertBoard.DbAccess.Implementation
{
    public class UserRepository: IUserRepository
    {
        private readonly AdvertBoardContext _context;

        public UserRepository(AdvertBoardContext context)
        {
            _context = context;
        }
        public User GetUserById(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            return user;
        }
    }
}