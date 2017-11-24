using AdvertBoard.DbAccess.Models;

namespace AdvertBoard.DbAccess.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(string userId);
    }
}