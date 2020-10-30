using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Dal.Models;

namespace MyBrokenPage.Dal.Repositories
{
    public class SecurityQuestionRepository : GenericRepository<SecurityQuestion>, ISecurityQuestionRepository
    {
        public SecurityQuestionRepository(MyBrokenPageContext myBrokenPageContext) : base(myBrokenPageContext) { }
    }
}
