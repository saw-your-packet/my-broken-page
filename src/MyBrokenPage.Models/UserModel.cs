using System.Collections.Generic;

namespace MyBrokenPage.Models
{
    public class UserModel
    {
        public string Username { get; set; }

        public RoleModel Role { get; set; }

        public ICollection<UserSecurityAnswerModel> SecurityAnswers { get; set; }
    }
}
