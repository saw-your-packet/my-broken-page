using MyBrokenPage.Bll.Contracts;
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

        public bool VerifyCredentials(UserModel userModel)
        {
            if(userModel == null)
            {
                return false;
            }

            return _userRepository.IsUsernameMatchingPassword(userModel.Username, userModel.Password);
        }
    }
}
