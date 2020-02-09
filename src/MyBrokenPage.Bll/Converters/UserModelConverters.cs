using MyBrokenPage.Dal.Models;
using MyBrokenPage.Models;

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
    }
}
