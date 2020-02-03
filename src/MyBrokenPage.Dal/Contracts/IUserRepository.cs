using MyBrokenPage.Dal.Contratcs;
using MyBrokenPage.Dal.Models;

namespace MyBrokenPage.Dal.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool IsUsernameMatchingPassword(string username, string password);
    }
}
