using MyBrokenPage.Dal.Contratcs;
using MyBrokenPage.Dal.Models;

namespace MyBrokenPage.Dal.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByCredentials(string username, string password);
        bool IsUsernameUsed(string username);
        User GetUserByUsername(string username);
    }
}
