using MyBrokenPage.Models;
using MyBrokenPage.UI.ViewModels;
using System.Linq;

namespace MyBrokenPage.UI.Converters
{
    public static class UserViewModelConverters
    {
        public static UserLoginModel ToUserLoginModel(this UserLoginViewModel userLoginViewModel)
        {
            return new UserLoginModel
            {
                Username = userLoginViewModel.Username,
                Password = userLoginViewModel.Password
            };
        }

        public static UserCredentialsModel ToUserCredentialsModel(this UserCredentialsViewModel userCredentialsViewModel)
        {
            return new UserCredentialsModel
            {
                Username = userCredentialsViewModel.Username,
                Password = userCredentialsViewModel.Password,
                SecurityAnswers = userCredentialsViewModel.SecurityAnswers.Select(x => x.ToUserSecurityAnswerModel())
                                                                       .ToList()
            };
        }
    }
}
