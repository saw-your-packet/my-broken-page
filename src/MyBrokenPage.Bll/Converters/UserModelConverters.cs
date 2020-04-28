using MyBrokenPage.Dal.Models;
using MyBrokenPage.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBrokenPage.Bll.Converters
{
    public static class UserModelConverters
    {
        public static UserModel ToUserModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToRoleModel()
            };
        }

        public static User ToUser(this UserCredentialsModel userRegisterModel, Role role, IEnumerable<SecurityQuestion> securityQuestions)
        {
            return new User
            {
                Username = userRegisterModel.Username,
                Password = userRegisterModel.Password,
                Role = role,
                SecurityAnswers = userRegisterModel.SecurityAnswers.ConvertAndMapSecurityAnswers(securityQuestions)
                                                                   .ToList()
            };
        }
    }
}
