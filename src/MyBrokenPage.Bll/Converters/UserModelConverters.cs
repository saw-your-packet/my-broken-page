using MyBrokenPage.Dal.Models;
using MyBrokenPage.Models;
using System.Linq;

namespace MyBrokenPage.Bll.Converters
{
    public static class UserModelConverters
    {
        public static UserModel ToUserModel(this User user)
        {
            return new UserModel
            {
                Username = user.Username,
                Role = user.Role.ToRoleModel()
            };
        }

        public static User ToUser(this UserRegisterModel userRegisterModel)
        {
            return new User
            {
                Username = userRegisterModel.Username,
                Password = userRegisterModel.Password,
                Role = new Role { Id = 2 },
                SecurityAnswers = userRegisterModel.SecurityAnswers.Select(x => x.ToUserSecurityAnswer())
                                                                   .ToList()
            };
        }
    }
}
