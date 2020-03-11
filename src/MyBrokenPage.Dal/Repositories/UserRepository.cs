using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Dal.Models;
using System.Linq;

namespace MyBrokenPage.Dal.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MyBrokenPageContext myBrokenPageContext) : base(myBrokenPageContext) { }

        public new void Add(User user)
        {
            _myBrokenPageContext.Attach(user.Role);

            user.SecurityAnswers.Select(x => _myBrokenPageContext.Attach(x.SecurityQuestion));

            _myBrokenPageContext.Add(user);
        }

        public User GetUserByCredentials(string username, string password)
        {
            var query = $"SELECT * FROM dbo.Users WHERE Username = '{username}' and Password = '{password}'";

            return _entities.FromSqlRaw(query)
                            .Include(x => x.Role)
                            .FirstOrDefault();
        }

        public bool IsUsernameUsed(string username)
        {
            var query = $"SELECT * FROM dbo.Users WHERE Username = '{username}'";

            return _entities.FromSqlRaw(query).Count() == 1;
        }
    }
}
