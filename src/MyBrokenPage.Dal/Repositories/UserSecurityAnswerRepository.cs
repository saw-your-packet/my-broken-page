using Microsoft.EntityFrameworkCore;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Dal.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBrokenPage.Dal.Repositories
{
    public class UserSecurityAnswerRepository : GenericRepository<UserSecurityAnswer>, IUserSecurityAnswerRepository
    {
        public UserSecurityAnswerRepository(MyBrokenPageContext myBrokenPageContext) : base(myBrokenPageContext) { }

        public IEnumerable<UserSecurityAnswer> GetAnswersOfUser(int userId)
        {
            return _entities.Where(userSecurityAnswer => userSecurityAnswer.UserId == userId)
                            .Include(userSecurityAnswer => userSecurityAnswer.SecurityQuestion)
                            .ToList();
        }
    }
}
