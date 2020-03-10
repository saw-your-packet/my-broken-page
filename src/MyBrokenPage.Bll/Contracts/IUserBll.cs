using MyBrokenPage.Models;

namespace MyBrokenPage.Bll.Contracts
{
    public interface IUserBll
    {
        UserModel RetrieveUserByCredentials(UserLoginModel userLoginModel);
        void CreateAccount(UserRegisterModel userRegisterModel);
    }
}
