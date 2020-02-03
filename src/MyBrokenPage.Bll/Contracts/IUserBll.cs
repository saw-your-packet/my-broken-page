using MyBrokenPage.Models;

namespace MyBrokenPage.Bll.Contracts
{
    public interface IUserBll
    {
        bool VerifyCredentials(UserModel userModel);
    }
}
