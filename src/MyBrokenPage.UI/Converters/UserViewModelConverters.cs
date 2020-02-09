using MyBrokenPage.Models;
using MyBrokenPage.UI.ViewModels;

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
    }
}
