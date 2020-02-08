using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Dal.Models;
using System.Linq;

namespace MyBrokenPage.Dal.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyBrokenPageContext myPageContext) : base(myPageContext) { }

        public bool IsUsernameMatchingPassword(string username, string password)
        {
            var query = $"SELECT * FROM dbo.Users WHERE Username = '{username}' and Password = '{password}'";
            var result = _entities.FromSqlRaw(query)
                                  .FirstOrDefault();

            return result != null;
        }
    }
}
