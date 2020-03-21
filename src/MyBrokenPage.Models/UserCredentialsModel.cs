using System.Collections.Generic;

namespace MyBrokenPage.Models
{
    public class UserCredentialsModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<UserSecurityAnswerModel> SecurityAnswers { get; set; }
    }
}
