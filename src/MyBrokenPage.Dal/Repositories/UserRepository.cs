using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Dal.Models;
using System.Linq;

namespace MyBrokenPage.Dal.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyBrokenPageContext myBrokenPageContext) : base(myBrokenPageContext) { }

        public User GetUserByCredentials(string username, string password)
        {
            var query = $"SELECT * FROM dbo.Users WHERE Username = '{username}' and Password = '{password}'";

            return _entities.FromSqlRaw(query)
                            .Include(x => x.Role)
                            .FirstOrDefault();
        }
    }
}
