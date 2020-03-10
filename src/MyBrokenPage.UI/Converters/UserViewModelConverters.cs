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

        public static UserRegisterModel ToUserRegisterModel(this UserRegisterViewModel userRegisterViewModel)
        {
            return new UserRegisterModel
            {
                Username = userRegisterViewModel.Username,
                Password = userRegisterViewModel.Password,
                SecurityAnswers = userRegisterViewModel.SecurityAnswers.Select(x => x.ToUserSecurityAnswerModel())
                                                                       .ToList()
            };
        }
    }
}
