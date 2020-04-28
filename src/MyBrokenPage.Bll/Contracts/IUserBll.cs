using MyBrokenPage.Models;

namespace MyBrokenPage.Bll.Contracts
{
    public interface IUserBll
    {
        UserModel RetrieveUserByCredentials(UserLoginModel userLoginModel);
        void CreateAccount(UserCredentialsModel userCredentialsModel);
        bool IsUsernameUsed(string username);
        bool ResetForgottenPassword(UserCredentialsModel userCredentialsModel);
        UserModel GetByUsername(string username);
    }
}
