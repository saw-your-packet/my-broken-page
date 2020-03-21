using MyBrokenPage.Dal.Contratcs;
using MyBrokenPage.Dal.Models;
using System.Collections.Generic;

namespace MyBrokenPage.Dal.Contracts
{
    public interface IUserSecurityAnswerRepository : IGenericRepository<UserSecurityAnswer>
    {
        IEnumerable<UserSecurityAnswer> GetAnswersOfUser(int userId);
    }
}
