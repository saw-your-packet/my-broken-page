using MyBrokenPage.Models;
using MyBrokenPage.UI.ViewModels;

namespace MyBrokenPage.UI.Converters
{
    public static class UserViewModelConverters
    {
        public static UserModel ToUserModel(this UserLoginViewModel userLoginViewModel)
        {
            return new UserModel
            {
                Username = userLoginViewModel.Username,
                Password = userLoginViewModel.Password
            };
        }
    }
}
