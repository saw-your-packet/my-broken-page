using MyBrokenPage.Bll.Contracts;
using MyBrokenPage.Bll.Converters;
using MyBrokenPage.Bll.Exceptions;
using MyBrokenPage.Dal.Contracts;
using MyBrokenPage.Models;

namespace MyBrokenPage.Bll.Logic
{
    public class UserBll : IUserBll
    {
        private readonly IUserRepository _userRepository;

        public UserBll(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel RetrieveUserByCredentials(UserLoginModel userLoginModel)
        {
            if (userLoginModel == null)
            {
                return null;
            }

            var user = _userRepository.GetUserByCredentials(userLoginModel.Username, userLoginModel.Password);

            return user?.ToUserModel();
        }

        public void CreateAccount(UserRegisterModel userRegisterModel)
        {
            var isUsernameUsed = _userRepository.IsUsernameUsed(userRegisterModel.Username);

            if (isUsernameUsed)
            {
                throw new ExceptionResourceConflict("Username used");
            }

            userRegisterModel.Password = PasswordManager.HashPassword(userRegisterModel.Password);
            var user = userRegisterModel.ToUser();

            _userRepository.Add(user);
            _userRepository.SaveChanges();
        }
    }
}
